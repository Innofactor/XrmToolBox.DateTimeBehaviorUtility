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
using System.Collections.Specialized;

namespace Innofactor.XTB.DateTimeBehaviorUtility
{
    public partial class DateTimeBehaviorUtility : PluginControlBase, IGitHubPlugin
    {
        private EntityMetadataCollection metadata;

        public string RepositoryName { get { return "XrmToolBox.DateTimeBehaviorUtility"; } }

        public string UserName { get { return "Innofactor"; } }

        public Dictionary<string, Int32> CountryCodes = new Dictionary<string, Int32>();

        public DateTimeBehaviorUtility()
        {
            InitializeComponent();
            //Add items to comboBox
            LoadConversionRules();
            LoadCountryCodes();
            cmbFltBehavior.SelectedIndex = 0;
            cmbFltFormat.SelectedIndex = 0;
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
                metadata = null;
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
            if (Service == null)
            {
                return;
            }
            Enabled = false;
            if (metadata == null)
            {
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
                        //aqe.Criteria.Conditions.Add(new MetadataConditionExpression("CanChangeDateTimeBehavior", MetadataConditionOperator.Equals, true));
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
                        metadata = ((RetrieveMetadataChangesResponse)args.Result).EntityMetadata;
                        PopulateAttributes();
                    }
                };
                WorkAsync(asyncinfo);
            }
            else
            {
                PopulateAttributes();
            }
        }

        private void LoadConversionRules()
        {
            cmbConversionRule.Items.Add(DateTimeBehaviorConversionRule.CreatedByTimeZone.Value);
            cmbConversionRule.Items.Add(DateTimeBehaviorConversionRule.LastUpdatedByTimeZone.Value);
            cmbConversionRule.Items.Add(DateTimeBehaviorConversionRule.OwnerTimeZone.Value);
            cmbConversionRule.Items.Add(DateTimeBehaviorConversionRule.SpecificTimeZone.Value);
        }

        private void LoadCountryCodes()
        {
            cmbCountryCodes.Items.Clear();
            cmbCountryCodes.Items.Add(" - select -");
            cmbCountryCodes.Items.AddRange(new CRMTimeZoneList().ToArray());
        }

        private void PopulateAttributes()
        {
            listAttributes.Items.Clear();
            listAttributes.Groups.Clear();
            if (metadata == null)
            {
                LoadAttributes();
                return;
            }
            var entityFilter = txtFltEntity.Text;
            var behavior = cmbFltBehavior.Text.Replace("All", "");
            var format = cmbFltFormat.Text.Replace("All", "");
            var canChange = chkFltCanChangeBehavior.Checked;
            foreach (var entity in metadata
                .Where(e => FilterEntity(e, entityFilter) && e.Attributes
                    .Any(a => FilterAttribute(a as DateTimeAttributeMetadata, behavior, format, canChange)))
                .OrderBy(e => e.DisplayName?.UserLocalizedLabel?.Label))
            {
                var group = listAttributes.Groups.Add(entity.LogicalName, "");
                group.Tag = entity;
                group.Header = GetGroupHeader(group);
                foreach (var attr in entity.Attributes
                    .Where(a => a is DateTimeAttributeMetadata && FilterAttribute(a as DateTimeAttributeMetadata, behavior, format, canChange))
                    .OrderBy(a => a.LogicalName))
                {
                    var attribute = attr as DateTimeAttributeMetadata;
                    if (attribute != null)
                    {
                        var item = new ListViewItem(group);
                        item.Tag = attribute;
                        item.Name = attribute.LogicalName;
                        item.Text = attribute.DisplayName.UserLocalizedLabel.Label;
                        item.UseItemStyleForSubItems = false;
                        item.SubItems.Add(attribute.LogicalName);
                        item.SubItems.Add(attribute.DateTimeBehavior?.Value);
                        item.SubItems.Add(attribute.Format.Value.ToString());
                        listAttributes.Items.Add(item);
                    }
                }
            }
            Enabled = true;
        }

        private bool FilterEntity(EntityMetadata entity, string entityFilter)
        {
            if (entity == null)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(entityFilter))
            {   // No filter
                return true;
            }
            var logicalName = entity.LogicalName.ToLowerInvariant();
            var displayName = entity.DisplayName?.UserLocalizedLabel?.Label?.ToLowerInvariant();
            entityFilter = entityFilter.ToLowerInvariant();
            if (string.IsNullOrEmpty(displayName))
            {
                displayName = logicalName;
            }
            if (!entityFilter.Contains("*"))
            {   // Exact match
                return
                    logicalName.Equals(entityFilter, StringComparison.InvariantCulture) ||
                    displayName.Equals(entityFilter, StringComparison.InvariantCulture);
            }
            else if (entityFilter.StartsWith("*") && entityFilter.EndsWith("*"))
            {   // Contains
                entityFilter = entityFilter.Replace("*", "");
                return
                    logicalName.Contains(entityFilter) ||
                    displayName.Contains(entityFilter);
            }
            else if (entityFilter.StartsWith("*"))
            {   // Leading wildcard
                entityFilter = entityFilter.Replace("*", "");
                return
                    logicalName.EndsWith(entityFilter, StringComparison.InvariantCulture) ||
                    displayName.EndsWith(entityFilter, StringComparison.InvariantCulture);
            }
            else if (entityFilter.EndsWith("*"))
            {   // Leading wildcard
                entityFilter = entityFilter.Replace("*", "");
                return
                    logicalName.StartsWith(entityFilter, StringComparison.InvariantCulture) ||
                    displayName.StartsWith(entityFilter, StringComparison.InvariantCulture);
            }
            return false;
        }

        private bool FilterAttribute(DateTimeAttributeMetadata attribute, string behavior, string format, bool canchange)
        {
            return
                attribute != null &&
                (string.IsNullOrWhiteSpace(behavior) || behavior == attribute.DateTimeBehavior?.Value) &&
                (string.IsNullOrWhiteSpace(format) || format == attribute.Format.Value.ToString()) &&
                (!canchange || attribute.CanChangeDateTimeBehavior.Value);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://msdn.microsoft.com/en-us/library/microsoft.xrm.sdk.messages.convertdateandtimebehaviorrequest.aspx");
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            Analyze();
        }

        private void UpdateUI(Action action)
        {
            MethodInvoker mi = delegate
            {
                action();
            };
            if (InvokeRequired)
            {
                Invoke(mi);
            }
            else
            {
                mi();
            }
        }

        private void Analyze()
        {
            var groups = listAttributes.Groups.Cast<ListViewGroup>().Where(g => g.Items.Cast<ListViewItem>().Any(i => i.Checked));

            foreach (ListViewGroup entity in groups)
            {
                var asyncinfo = new WorkAsyncInfo
                {
                    Message = $"Counting records for\n  {entity.Name}",
                    AsyncArgument = entity,
                    Work = (worker, args) =>
                    {
                        var group = args.Argument as ListViewGroup;
                        var entityName = group.Name;
                        var fetchAll = $"<fetch aggregate='true' ><entity name='{entityName}' ><attribute name='createdon' alias='Count' aggregate='count' /></entity></fetch>";
                        EntityCollection fetchResult = null;
                        try
                        {
                            fetchResult = Service.RetrieveMultiple(new FetchExpression(fetchAll));
                        }
                        finally
                        {
                            var value = ((AliasedValue)fetchResult.Entities[0].Attributes["Count"]).Value as int?;
                            args.Result = new Tuple<ListViewGroup, int?>(group, value);
                        }
                    },
                    PostWorkCallBack = (args) =>
                    {
                        var result = args.Result as Tuple<ListViewGroup, int?>;
                        if (result == null)
                        {
                            MessageBox.Show($"Error while counting total record count for {entity.Header}", "Analyze", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                            return;
                        }
                        var group = result.Item1;
                        var value = result.Item2;
                        if (value == null)
                        {
                            group.Header = $"{GetGroupHeader(group)} - Unable to retrieve record count";
                            if (args.Error != null)
                            {
                                AddItemToGroup(group, "error", args.Error.Message);
                            }
                        }
                        else
                        {
                            group.Header = $"{GetGroupHeader(group)} - {value} records";
                            foreach (ListViewItem attribute in group.Items.Cast<ListViewItem>().Where(i => i.Checked))
                            {
                                AnalyzeAttribute(attribute);
                            }
                        }
                    }
                };
                WorkAsync(asyncinfo);
            }
        }

        private static string GetGroupHeader(ListViewGroup group)
        {
            var entity = group.Tag as EntityMetadata;
            if (entity != null)
            {
                return $"{entity.DisplayName?.UserLocalizedLabel?.Label} ({entity.LogicalName})";
            }
            return group.Name;
        }

        private ListViewItem AddItemToGroup(ListViewGroup group, string name, string text)
        {
            var item = new ListViewItem(group);
            item.Name = name;
            item.Text = text;
            UpdateUI(() => { group.ListView.Items.Add(item); });
            return item;
        }

        private void AnalyzeAttribute(ListViewItem item)
        {
            var group = item?.Group;
            if (item != null && group != null)
            {
                while (item.SubItems.Count < 5)
                {
                    item.SubItems.Add("");
                }
                item.SubItems[4].Text = "Counting...";
                item.SubItems[4].BackColor = Color.Yellow;
                var fetchAttr = $"<fetch aggregate='true' ><entity name='{group.Name}' ><attribute name='{item.Name}' alias='Count' aggregate='countcolumn' /></entity></fetch>";

                var asyncinfo = new WorkAsyncInfo
                {
                    Message = $"Analyzing {group.Name}.{item.Name}",
                    Work = (worker, args) =>
                    {
                        try
                        {
                            var resultAttr = Service.RetrieveMultiple(new FetchExpression(fetchAttr));
                            var value = ((AliasedValue)resultAttr.Entities[0].Attributes["Count"]).Value as int?;
                            args.Result = new Tuple<ListViewItem, int?, Exception>(item, value, null);
                        }
                        catch (Exception ex)
                        {
                            args.Result = new Tuple<ListViewItem, int?, Exception>(item, null, ex);
                        }
                    },
                    PostWorkCallBack = (args) =>
                    {
                        var result = args.Result as Tuple<ListViewItem, int?, Exception>;
                        if (result == null)
                        {
                            MessageBox.Show("Fatal unknown error while counting records", "Analyze", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        var attributeItem = result.Item1;
                        var value = result.Item2;
                        var ex = result.Item3;
                        if (value == null)
                        {
                            if (ex != null)
                            {
                                attributeItem.SubItems[4].Text = ex.Message;
                            }
                            else
                            {
                                attributeItem.SubItems[4].Text = "failed";
                            }
                            attributeItem.SubItems[4].BackColor = Color.Red;
                        }
                        else
                        {
                            attributeItem.SubItems[4].Text = value.ToString();
                            attributeItem.SubItems[4].Tag = value;
                            attributeItem.SubItems[4].BackColor = Color.LightGreen;
                        }
                    }
                };
                WorkAsync(asyncinfo);
            }
        }

        private void listAttributes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                cmbConversionRule.Enabled = listAttributes.CheckedItems.Count > 0;
                cbAutoConvert.Enabled = listAttributes.CheckedItems.Count > 0;
                EnableAnalyzeBtn();
                EnableConvertBtn();
            }
            catch { }
        }

        private void EnableConvertBtn()
        {
            btnConvertDateOnly.Enabled =
                listAttributes.CheckedItems.Count > 0 &&
                cmbConversionRule.SelectedItem != null &&
                (cmbCountryCodes.SelectedItem is CRMTimeZone || cmbConversionRule.SelectedItem.ToString() != DateTimeBehaviorConversionRule.SpecificTimeZone.Value);
        }

        private void EnableAnalyzeBtn()
        {
            btnAnalyze.Enabled = listAttributes.CheckedItems.Count > 0;
        }

        private void btnConvertDateOnly_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("This action will update data on all records for selected attributes in connected organization.\n\nUse with caution!\n\nContinue?", "Convert data", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation))
            {
                var tz = cmbCountryCodes.SelectedItem as CRMTimeZone;

                var req = new ConvertDateAndTimeBehaviorRequest();
                req.Attributes = GetSelectedEntityAttributes();
                req.ConversionRule = cmbConversionRule.SelectedItem.ToString();
                if (tz != null)
                {
                    req.TimeZoneCode = tz.TimeZoneCode;
                }
                req.AutoConvert = cbAutoConvert.Checked;

                //Execute
                var resp = Service.Execute(req) as ConvertDateAndTimeBehaviorResponse;
                linkConvertJob.Text = resp.JobId.ToString();
                MessageBox.Show("Conversion is performed asynchronously.\nClick the link on the form to open system job and verify the results.", "Convert data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private EntityAttributeCollection GetSelectedEntityAttributes()
        {
            var checkedEntityAttributes = new EntityAttributeCollection();

            foreach (ListViewItem item in listAttributes.CheckedItems)
            {
                var entity = item.Group.Name;
                var attribute = item.Name;
                if (!checkedEntityAttributes.ContainsKey(entity))
                {
                    checkedEntityAttributes.Add(entity, new StringCollection());
                }
                checkedEntityAttributes[entity].Add(attribute);
            }

            return checkedEntityAttributes;
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

        private void cmbConversionRule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConversionRule.Text == DateTimeBehaviorConversionRule.SpecificTimeZone.Value)
            {
                cmbCountryCodes.Enabled = true;
            }
            else
            {
                cmbCountryCodes.SelectedIndex = -1;
                cmbCountryCodes.Enabled = false;
            }
            EnableConvertBtn();
        }

        private void cmbCountryCodes_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableConvertBtn();
        }

        private void linkConvertJob_TextChanged(Object sender, EventArgs e)
        {
            Guid g;
            linkConvertJob.Enabled = Guid.TryParse(linkConvertJob.Text, out g);
        }

        private void linkNewIssue_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Innofactor/XrmToolBox.DateTimeBehaviorUtility/issues/new");
        }

        private void txtFltEntity_TextChanged(object sender, EventArgs e)
        {
            PopulateAttributes();
        }

        private void cmbFltBehavior_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateAttributes();
        }

        private void cmbFltFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateAttributes();
        }

        private void chkFltCanChangeBehavior_CheckedChanged(object sender, EventArgs e)
        {
            PopulateAttributes();
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Innofactor/XrmToolBox.DateTimeBehaviorUtility/issues/5");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/Innofactor/XrmToolBox.DateTimeBehaviorUtility/issues/6");
        }
    }
}
