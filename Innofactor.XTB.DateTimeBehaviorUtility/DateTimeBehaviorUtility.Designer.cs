namespace Innofactor.XTB.DateTimeBehaviorUtility
{
    partial class DateTimeBehaviorUtility
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateTimeBehaviorUtility));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLoadAttributes = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAnalyze = new System.Windows.Forms.ToolStripButton();
            this.pnlAttributes = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.listAttributes = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFormat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBehavior = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNotNull = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pnlActions = new System.Windows.Forms.Panel();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.gbDateOnly = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCountryCodes = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbConversionRule = new System.Windows.Forms.ComboBox();
            this.cbAutoConvert = new System.Windows.Forms.CheckBox();
            this.linkConvertJob = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnConvertDateOnly = new System.Windows.Forms.Button();
            this.linkConvertRequestUrl = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.linkNewIssue = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.pnlAttributes.SuspendLayout();
            this.pnlActions.SuspendLayout();
            this.gbDateOnly.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.toolStripSeparator2,
            this.btnLoadAttributes,
            this.toolStripSeparator1,
            this.btnAnalyze});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1000, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(56, 22);
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnLoadAttributes
            // 
            this.btnLoadAttributes.Enabled = false;
            this.btnLoadAttributes.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadAttributes.Image")));
            this.btnLoadAttributes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadAttributes.Name = "btnLoadAttributes";
            this.btnLoadAttributes.Size = new System.Drawing.Size(108, 22);
            this.btnLoadAttributes.Text = "Load Attributes";
            this.btnLoadAttributes.Click += new System.EventHandler(this.btnLoadAttributes_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAnalyze.Enabled = false;
            this.btnAnalyze.Image = ((System.Drawing.Image)(resources.GetObject("btnAnalyze.Image")));
            this.btnAnalyze.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(98, 22);
            this.btnAnalyze.Text = "Analyze selected";
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // pnlAttributes
            // 
            this.pnlAttributes.Controls.Add(this.label1);
            this.pnlAttributes.Controls.Add(this.listAttributes);
            this.pnlAttributes.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAttributes.Location = new System.Drawing.Point(0, 25);
            this.pnlAttributes.Name = "pnlAttributes";
            this.pnlAttributes.Size = new System.Drawing.Size(667, 459);
            this.pnlAttributes.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Entites and Attributes";
            // 
            // listAttributes
            // 
            this.listAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listAttributes.CheckBoxes = true;
            this.listAttributes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colLogicalName,
            this.colFormat,
            this.colBehavior,
            this.colNotNull});
            this.listAttributes.FullRowSelect = true;
            this.listAttributes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listAttributes.Location = new System.Drawing.Point(7, 20);
            this.listAttributes.Name = "listAttributes";
            this.listAttributes.Size = new System.Drawing.Size(657, 436);
            this.listAttributes.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listAttributes.TabIndex = 0;
            this.listAttributes.UseCompatibleStateImageBehavior = false;
            this.listAttributes.View = System.Windows.Forms.View.Details;
            this.listAttributes.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listAttributes_ItemChecked);
            // 
            // colName
            // 
            this.colName.Text = "Attribute";
            this.colName.Width = 139;
            // 
            // colLogicalName
            // 
            this.colLogicalName.Text = "Logical Name";
            this.colLogicalName.Width = 168;
            // 
            // colFormat
            // 
            this.colFormat.Text = "Format";
            this.colFormat.Width = 103;
            // 
            // colBehavior
            // 
            this.colBehavior.Text = "Behavior";
            this.colBehavior.Width = 108;
            // 
            // colNotNull
            // 
            this.colNotNull.Text = "Contains date";
            this.colNotNull.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colNotNull.Width = 87;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(667, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 459);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.label7);
            this.pnlActions.Controls.Add(this.label6);
            this.pnlActions.Controls.Add(this.linkNewIssue);
            this.pnlActions.Controls.Add(this.splitter2);
            this.pnlActions.Controls.Add(this.gbDateOnly);
            this.pnlActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActions.Location = new System.Drawing.Point(672, 25);
            this.pnlActions.Name = "pnlActions";
            this.pnlActions.Size = new System.Drawing.Size(328, 459);
            this.pnlActions.TabIndex = 3;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(0, 454);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(328, 5);
            this.splitter2.TabIndex = 2;
            this.splitter2.TabStop = false;
            // 
            // gbDateOnly
            // 
            this.gbDateOnly.Controls.Add(this.label5);
            this.gbDateOnly.Controls.Add(this.cmbCountryCodes);
            this.gbDateOnly.Controls.Add(this.label4);
            this.gbDateOnly.Controls.Add(this.cmbConversionRule);
            this.gbDateOnly.Controls.Add(this.cbAutoConvert);
            this.gbDateOnly.Controls.Add(this.linkConvertJob);
            this.gbDateOnly.Controls.Add(this.label3);
            this.gbDateOnly.Controls.Add(this.btnConvertDateOnly);
            this.gbDateOnly.Controls.Add(this.linkConvertRequestUrl);
            this.gbDateOnly.Controls.Add(this.label2);
            this.gbDateOnly.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDateOnly.Location = new System.Drawing.Point(0, 0);
            this.gbDateOnly.Name = "gbDateOnly";
            this.gbDateOnly.Size = new System.Drawing.Size(328, 218);
            this.gbDateOnly.TabIndex = 0;
            this.gbDateOnly.TabStop = false;
            this.gbDateOnly.Text = "DateOnly";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Country code";
            // 
            // cmbCountryCodes
            // 
            this.cmbCountryCodes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountryCodes.Enabled = false;
            this.cmbCountryCodes.FormattingEnabled = true;
            this.cmbCountryCodes.Location = new System.Drawing.Point(123, 91);
            this.cmbCountryCodes.Name = "cmbCountryCodes";
            this.cmbCountryCodes.Size = new System.Drawing.Size(188, 21);
            this.cmbCountryCodes.TabIndex = 8;
            this.cmbCountryCodes.SelectedIndexChanged += new System.EventHandler(this.cmbCountryCodes_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Conversion rule";
            // 
            // cmbConversionRule
            // 
            this.cmbConversionRule.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConversionRule.Enabled = false;
            this.cmbConversionRule.FormattingEnabled = true;
            this.cmbConversionRule.Location = new System.Drawing.Point(123, 64);
            this.cmbConversionRule.Name = "cmbConversionRule";
            this.cmbConversionRule.Size = new System.Drawing.Size(188, 21);
            this.cmbConversionRule.TabIndex = 6;
            this.cmbConversionRule.SelectedIndexChanged += new System.EventHandler(this.cmbConversionRule_SelectedIndexChanged);
            // 
            // cbAutoConvert
            // 
            this.cbAutoConvert.AutoSize = true;
            this.cbAutoConvert.Enabled = false;
            this.cbAutoConvert.Location = new System.Drawing.Point(123, 118);
            this.cbAutoConvert.Name = "cbAutoConvert";
            this.cbAutoConvert.Size = new System.Drawing.Size(87, 17);
            this.cbAutoConvert.TabIndex = 5;
            this.cbAutoConvert.Text = "Auto convert";
            this.cbAutoConvert.UseVisualStyleBackColor = true;
            // 
            // linkConvertJob
            // 
            this.linkConvertJob.AutoSize = true;
            this.linkConvertJob.Enabled = false;
            this.linkConvertJob.Location = new System.Drawing.Point(7, 189);
            this.linkConvertJob.Name = "linkConvertJob";
            this.linkConvertJob.Size = new System.Drawing.Size(87, 13);
            this.linkConvertJob.TabIndex = 4;
            this.linkConvertJob.TabStop = true;
            this.linkConvertJob.Text = "<no job created>";
            this.linkConvertJob.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkConvertJob_LinkClicked);
            this.linkConvertJob.TextChanged += new System.EventHandler(this.linkConvertJob_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Click to open system job record: ";
            // 
            // btnConvertDateOnly
            // 
            this.btnConvertDateOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertDateOnly.Enabled = false;
            this.btnConvertDateOnly.Location = new System.Drawing.Point(172, 139);
            this.btnConvertDateOnly.Name = "btnConvertDateOnly";
            this.btnConvertDateOnly.Size = new System.Drawing.Size(140, 23);
            this.btnConvertDateOnly.TabIndex = 2;
            this.btnConvertDateOnly.Text = "Convert attributes";
            this.btnConvertDateOnly.UseVisualStyleBackColor = true;
            this.btnConvertDateOnly.Click += new System.EventHandler(this.btnConvertDateOnly_Click);
            // 
            // linkConvertRequestUrl
            // 
            this.linkConvertRequestUrl.AutoSize = true;
            this.linkConvertRequestUrl.Location = new System.Drawing.Point(7, 33);
            this.linkConvertRequestUrl.Name = "linkConvertRequestUrl";
            this.linkConvertRequestUrl.Size = new System.Drawing.Size(191, 13);
            this.linkConvertRequestUrl.TabIndex = 1;
            this.linkConvertRequestUrl.TabStop = true;
            this.linkConvertRequestUrl.Text = "ConvertDateAndTimeBehaviorRequest";
            this.linkConvertRequestUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Convert DateOnly values in selected attributes using";
            // 
            // linkNewIssue
            // 
            this.linkNewIssue.AutoSize = true;
            this.linkNewIssue.Location = new System.Drawing.Point(7, 276);
            this.linkNewIssue.Name = "linkNewIssue";
            this.linkNewIssue.Size = new System.Drawing.Size(88, 13);
            this.linkNewIssue.TabIndex = 3;
            this.linkNewIssue.TabStop = true;
            this.linkNewIssue.Text = "Create new issue";
            this.linkNewIssue.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNewIssue_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(313, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Suggestions for more functionality related to DateTime attributes?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 258);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Submit an issue to the GitHub project!";
            // 
            // DateTimeBehaviorUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlAttributes);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Name = "DateTimeBehaviorUtility";
            this.Size = new System.Drawing.Size(1000, 484);
            this.ConnectionUpdated += new XrmToolBox.Extensibility.PluginControlBase.ConnectionUpdatedHandler(this.DateTimeBehaviorUtility_ConnectionUpdated);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlAttributes.ResumeLayout(false);
            this.pnlAttributes.PerformLayout();
            this.pnlActions.ResumeLayout(false);
            this.pnlActions.PerformLayout();
            this.gbDateOnly.ResumeLayout(false);
            this.gbDateOnly.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton btnLoadAttributes;
        private System.Windows.Forms.Panel pnlAttributes;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ListView listAttributes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colBehavior;
        private System.Windows.Forms.ColumnHeader colFormat;
        private System.Windows.Forms.ColumnHeader colLogicalName;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.GroupBox gbDateOnly;
        private System.Windows.Forms.LinkLabel linkConvertRequestUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnConvertDateOnly;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.LinkLabel linkConvertJob;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbAutoConvert;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbConversionRule;
        private System.Windows.Forms.ComboBox cmbCountryCodes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripButton btnAnalyze;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ColumnHeader colNotNull;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.LinkLabel linkNewIssue;
    }
}
