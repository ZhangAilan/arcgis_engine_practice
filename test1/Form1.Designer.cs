namespace test1
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addShpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addRasterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.operateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lKZoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.openCADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.openDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDocAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.operateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(910, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.addShpToolStripMenuItem,
            this.addRasterToolStripMenuItem,
            this.openCADToolStripMenuItem,
            this.addTINToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.openToolStripMenuItem.Text = "OpenShp";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // addShpToolStripMenuItem
            // 
            this.addShpToolStripMenuItem.Name = "addShpToolStripMenuItem";
            this.addShpToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.addShpToolStripMenuItem.Text = "AddShp";
            this.addShpToolStripMenuItem.Click += new System.EventHandler(this.addShpToolStripMenuItem_Click);
            // 
            // addRasterToolStripMenuItem
            // 
            this.addRasterToolStripMenuItem.Name = "addRasterToolStripMenuItem";
            this.addRasterToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.addRasterToolStripMenuItem.Text = "OpenRaster";
            this.addRasterToolStripMenuItem.Click += new System.EventHandler(this.addRasterToolStripMenuItem_Click);
            // 
            // operateToolStripMenuItem
            // 
            this.operateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lKZoomInToolStripMenuItem,
            this.newDocToolStripMenuItem,
            this.openDocToolStripMenuItem,
            this.saveDocToolStripMenuItem,
            this.saveDocAsToolStripMenuItem});
            this.operateToolStripMenuItem.Name = "operateToolStripMenuItem";
            this.operateToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.operateToolStripMenuItem.Text = "Operate";
            // 
            // lKZoomInToolStripMenuItem
            // 
            this.lKZoomInToolStripMenuItem.Name = "lKZoomInToolStripMenuItem";
            this.lKZoomInToolStripMenuItem.Size = new System.Drawing.Size(173, 30);
            this.lKZoomInToolStripMenuItem.Text = "LKZoomIn";
            this.lKZoomInToolStripMenuItem.Click += new System.EventHandler(this.lKZoomInToolStripMenuItem_Click);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(668, 418);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 5;
            // 
            // openCADToolStripMenuItem
            // 
            this.openCADToolStripMenuItem.Name = "openCADToolStripMenuItem";
            this.openCADToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.openCADToolStripMenuItem.Text = "OpenCAD";
            this.openCADToolStripMenuItem.Click += new System.EventHandler(this.openCADToolStripMenuItem_Click);
            // 
            // addTINToolStripMenuItem
            // 
            this.addTINToolStripMenuItem.Name = "addTINToolStripMenuItem";
            this.addTINToolStripMenuItem.Size = new System.Drawing.Size(177, 30);
            this.addTINToolStripMenuItem.Text = "AddTIN";
            this.addTINToolStripMenuItem.Click += new System.EventHandler(this.addTINToolStripMenuItem_Click);
            // 
            // newDocToolStripMenuItem
            // 
            this.newDocToolStripMenuItem.Name = "newDocToolStripMenuItem";
            this.newDocToolStripMenuItem.Size = new System.Drawing.Size(173, 30);
            this.newDocToolStripMenuItem.Text = "NewDoc";
            this.newDocToolStripMenuItem.Click += new System.EventHandler(this.newDocToolStripMenuItem_Click);
            // 
            // axMapControl2
            // 
            this.axMapControl2.Location = new System.Drawing.Point(12, 382);
            this.axMapControl2.Name = "axMapControl2";
            this.axMapControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl2.OcxState")));
            this.axMapControl2.Size = new System.Drawing.Size(294, 291);
            this.axMapControl2.TabIndex = 4;
            // 
            // axMapControl1
            // 
            this.axMapControl1.Location = new System.Drawing.Point(312, 70);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(586, 603);
            this.axMapControl1.TabIndex = 3;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown);
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Location = new System.Drawing.Point(12, 70);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(294, 306);
            this.axTOCControl1.TabIndex = 2;
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Location = new System.Drawing.Point(12, 36);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(886, 28);
            this.axToolbarControl1.TabIndex = 1;
            // 
            // openDocToolStripMenuItem
            // 
            this.openDocToolStripMenuItem.Name = "openDocToolStripMenuItem";
            this.openDocToolStripMenuItem.Size = new System.Drawing.Size(173, 30);
            this.openDocToolStripMenuItem.Text = "OpenDoc";
            this.openDocToolStripMenuItem.Click += new System.EventHandler(this.openDocToolStripMenuItem_Click);
            // 
            // saveDocToolStripMenuItem
            // 
            this.saveDocToolStripMenuItem.Name = "saveDocToolStripMenuItem";
            this.saveDocToolStripMenuItem.Size = new System.Drawing.Size(173, 30);
            this.saveDocToolStripMenuItem.Text = "SaveDoc";
            this.saveDocToolStripMenuItem.Click += new System.EventHandler(this.saveDocToolStripMenuItem_Click);
            // 
            // saveDocAsToolStripMenuItem
            // 
            this.saveDocAsToolStripMenuItem.Name = "saveDocAsToolStripMenuItem";
            this.saveDocAsToolStripMenuItem.Size = new System.Drawing.Size(173, 30);
            this.saveDocAsToolStripMenuItem.Text = "SaveDocAs";
            this.saveDocAsToolStripMenuItem.Click += new System.EventHandler(this.saveDocAsToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 685);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axMapControl2);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lKZoomInToolStripMenuItem;
        private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl2;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.ToolStripMenuItem addShpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCADToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTINToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDocAsToolStripMenuItem;
    }
}

