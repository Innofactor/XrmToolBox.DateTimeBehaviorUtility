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
    }
}
