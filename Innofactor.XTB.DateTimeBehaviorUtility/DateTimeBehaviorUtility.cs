using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System.Diagnostics;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;

namespace Innofactor.XTB.DateTimeBehaviorUtility
{
    public partial class DateTimeBehaviorUtility : PluginControlBase, IGitHubPlugin
    {
        public string RepositoryName { get { return "XrmToolBox.DateTimeBehaviorUtility"; } }

        public string UserName { get { return "Innofactor"; } }

        public DateTimeBehaviorUtility()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void DateTimeBehaviorUtility_ConnectionUpdated(object sender, ConnectionUpdatedEventArgs e)
        {
            var orgver = new Version(e.ConnectionDetail.OrganizationVersion);
            var orgok = orgver >= new Version(7, 1);
            btnLoadAttributes.Enabled = orgok;
            if (orgok)
            {
                listAttributes.Items.Clear();
                listAttributes.Groups.Clear();
            }
            else
            {
                MessageBox.Show("DateTime Behavior was introduced in\nMicrosoft Dynamics CRM 2015 Update 1 (7.1.0.0)\n\nPlease connect to a newer organization to use this cool tool.", "Organization too old", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLoadAttributes_Click(object sender, EventArgs e)
        {
            LoadAttributes();
        }

        private void LoadAttributes()
        {
            Enabled = false;
            listAttributes.Items.Clear();
            listAttributes.Groups.Clear();
            var asyncinfo = new WorkAsyncInfo()
            {
                Message = "Loading entities and attributes",
                Work = (a, args) =>
                {
                    var eqe = new EntityQueryExpression();
                    eqe.Properties = new MetadataPropertiesExpression("DisplayName", "Attributes");
                    eqe.Criteria.Conditions.Add(new MetadataConditionExpression("IsCustomizable", MetadataConditionOperator.Equals, true));
                    var aqe = new AttributeQueryExpression();
                    aqe.Properties = new MetadataPropertiesExpression();
                    aqe.Properties.AllProperties = true;
                    aqe.Criteria.Conditions.Add(new MetadataConditionExpression("AttributeType", MetadataConditionOperator.Equals, AttributeTypeCode.DateTime));
                    aqe.Criteria.Conditions.Add(new MetadataConditionExpression("CanChangeDateTimeBehavior", MetadataConditionOperator.Equals, true));
                    eqe.AttributeQuery = aqe;
                    var req = new RetrieveMetadataChangesRequest()
                    {
                        Query = eqe,
                        ClientVersionStamp = null
                    };
                    args.Result = Service.Execute(req) as RetrieveMetadataChangesResponse;
                },
                PostWorkCallBack = (args) =>
                {
                    if (args.Error != null)
                    {
                        MessageBox.Show($"Failed to load metadata:\n{args.Error.Message}", "Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!(args.Result is RetrieveMetadataChangesResponse))
                    {
                        MessageBox.Show($"Unexpected result:\n{args.Result}", "Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    var entities = ((RetrieveMetadataChangesResponse)args.Result).EntityMetadata;
                    PopulateAttributes(entities);
                }
            };
            WorkAsync(asyncinfo);
        }

        private void PopulateAttributes(EntityMetadataCollection entities)
        {
            foreach (var entity in entities.Where(e => e.Attributes.Any()).OrderBy(e => e.DisplayName.UserLocalizedLabel.Label))
            {
                var group = listAttributes.Groups.Add(entity.LogicalName, $"{entity.DisplayName.UserLocalizedLabel.Label} ({entity.LogicalName})");
                foreach (var attr in entity.Attributes.Where(a => a is DateTimeAttributeMetadata).OrderBy(a => a.LogicalName))
                {
                    var attribute = attr as DateTimeAttributeMetadata;
                    if (attribute != null)
                    {
                        var item = new ListViewItem(group);
                        item.Name = attribute.LogicalName;
                        item.Text = attribute.DisplayName.UserLocalizedLabel.Label;
                        item.SubItems.Add(attribute.LogicalName);
                        item.SubItems.Add(attribute.Format.Value.ToString());
                        item.SubItems.Add(attribute.DateTimeBehavior?.Value);
                        listAttributes.Items.Add(item);
                    }
                }
            }
            Enabled = true;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.messages.convertdateandtimebehaviorrequest.aspx");
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            Analyze();
        }

        private void Analyze()
        {
            // TODO: Make this work async
            // TODO: Query selected attributes
            txtAnalysis.Text = "";
            var fetch = @"<fetch aggregate='true' >
  <entity name='contact' >
    <attribute name='createdon' alias='First' aggregate='min' />
    <attribute name='createdon' alias='Last' aggregate='max' />
    <attribute name='contactid' alias='Count' aggregate='count' />
    <attribute name='birthdate' alias='Births' aggregate='countcolumn' />
  </entity>
</fetch>";
            var result = Service.RetrieveMultiple(new FetchExpression(fetch));
            txtAnalysis.Text = 
                $"Records: {((AliasedValue)result.Entities[0].Attributes["Count"]).Value}\n"+
                $"With value: {((AliasedValue)result.Entities[0].Attributes["Births"]).Value}\n";
        }

        private void listAttributes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            btnAnalyze.Enabled = listAttributes.CheckedItems.Count > 0;
            btnConvertDateOnly.Enabled = listAttributes.CheckedItems.Count > 0;
        }

        private void btnConvertDateOnly_Click(object sender, EventArgs e)
        {
            // TODO: Read selected attributes instead
            var req = new ConvertDateAndTimeBehaviorRequest();
            req.Attributes = new EntityAttributeCollection();
            var contactattributes = new System.Collections.Specialized.StringCollection();
            contactattributes.Add("birthdate");
            contactattributes.Add("new_datetime");
            req.Attributes.Add("contact", contactattributes);
            req.ConversionRule = DateTimeBehaviorConversionRule.OwnerTimeZone.Value;
            req.AutoConvert = true;
            var resp = Service.Execute(req) as ConvertDateAndTimeBehaviorResponse;
            linkConvertJob.Text = resp.JobId.ToString();
        }

        private void linkConvertJob_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var url = GetEntityReferenceUrl(new EntityReference("asyncoperation", new Guid(linkConvertJob.Text)));
            if (!string.IsNullOrEmpty(url))
            {
                Process.Start(url);
            }
        }

        private string GetEntityReferenceUrl(EntityReference entref)
        {
            if (!string.IsNullOrEmpty(entref.LogicalName) && !entref.Id.Equals(Guid.Empty))
            {
                var url = ConnectionDetail.WebApplicationUrl;
                if (string.IsNullOrEmpty(url))
                {
                    url = string.Concat(ConnectionDetail.ServerName, "/", ConnectionDetail.Organization);
                    if (!url.ToLower().StartsWith("http"))
                    {
                        url = string.Concat("http://", url);
                    }
                }
                url = string.Concat(url,
                    "/main.aspx?etn=",
                    entref.LogicalName,
                    "&pagetype=entityrecord&id=",
                    entref.Id.ToString());
                return url;
            }
            return string.Empty;
        }
    }
}
