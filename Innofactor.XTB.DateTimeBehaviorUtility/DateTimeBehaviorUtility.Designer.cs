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
            this.btnLoadAttributes = new System.Windows.Forms.ToolStripButton();
            this.pnlAttributes = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.listAttributes = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBehavior = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFormat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1.SuspendLayout();
            this.pnlAttributes.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClose,
            this.btnLoadAttributes});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(907, 25);
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
            // pnlAttributes
            // 
            this.pnlAttributes.Controls.Add(this.label1);
            this.pnlAttributes.Controls.Add(this.listAttributes);
            this.pnlAttributes.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAttributes.Location = new System.Drawing.Point(0, 25);
            this.pnlAttributes.Name = "pnlAttributes";
            this.pnlAttributes.Size = new System.Drawing.Size(555, 595);
            this.pnlAttributes.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(555, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 595);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
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
            this.colBehavior});
            this.listAttributes.Location = new System.Drawing.Point(7, 20);
            this.listAttributes.Name = "listAttributes";
            this.listAttributes.Size = new System.Drawing.Size(545, 572);
            this.listAttributes.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.listAttributes.TabIndex = 0;
            this.listAttributes.UseCompatibleStateImageBehavior = false;
            this.listAttributes.View = System.Windows.Forms.View.Details;
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
            // colName
            // 
            this.colName.Text = "Attribute";
            this.colName.Width = 139;
            // 
            // colBehavior
            // 
            this.colBehavior.Text = "Behavior";
            this.colBehavior.Width = 108;
            // 
            // colFormat
            // 
            this.colFormat.Text = "Format";
            this.colFormat.Width = 103;
            // 
            // colLogicalName
            // 
            this.colLogicalName.Text = "Logical Name";
            this.colLogicalName.Width = 168;
            // 
            // DateTimeBehaviorUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.pnlAttributes);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DateTimeBehaviorUtility";
            this.Size = new System.Drawing.Size(907, 620);
            this.ConnectionUpdated += new XrmToolBox.Extensibility.PluginControlBase.ConnectionUpdatedHandler(this.DateTimeBehaviorUtility_ConnectionUpdated);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlAttributes.ResumeLayout(false);
            this.pnlAttributes.PerformLayout();
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
    }
}
