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
            this.openCADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTINToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.operateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lKZoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawPointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawPolygonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.movemapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveDocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.synbolMapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.simpleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.classicBreakRenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uniqueBreakRenderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proportionalSymbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barChartSymbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stackedChartSymbolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pieChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dotDensityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.点查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.线查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.面查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.刷新ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.axMapControl2 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.固定查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.认识查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.属性查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.空间查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清空选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.operateToolStripMenuItem,
            this.synbolMapToolStripMenuItem,
            this.查询ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1209, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.addShpToolStripMenuItem,
            this.addRasterToolStripMenuItem,
            this.openCADToolStripMenuItem,
            this.addTINToolStripMenuItem,
            this.openToolStripMenuItem1});
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
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(177, 30);
            this.openToolStripMenuItem1.Text = "OpenDB";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // operateToolStripMenuItem
            // 
            this.operateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lKZoomInToolStripMenuItem,
            this.drawPointToolStripMenuItem,
            this.drawLineToolStripMenuItem,
            this.drawPolygonToolStripMenuItem,
            this.labelMapToolStripMenuItem,
            this.movemapToolStripMenuItem,
            this.openDocToolStripMenuItem,
            this.saveDocToolStripMenuItem});
            this.operateToolStripMenuItem.Name = "operateToolStripMenuItem";
            this.operateToolStripMenuItem.Size = new System.Drawing.Size(88, 29);
            this.operateToolStripMenuItem.Text = "Operate";
            // 
            // lKZoomInToolStripMenuItem
            // 
            this.lKZoomInToolStripMenuItem.Name = "lKZoomInToolStripMenuItem";
            this.lKZoomInToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.lKZoomInToolStripMenuItem.Text = "LKZoomIn";
            this.lKZoomInToolStripMenuItem.Click += new System.EventHandler(this.lKZoomInToolStripMenuItem_Click);
            // 
            // drawPointToolStripMenuItem
            // 
            this.drawPointToolStripMenuItem.Name = "drawPointToolStripMenuItem";
            this.drawPointToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.drawPointToolStripMenuItem.Text = "DrawPoint";
            this.drawPointToolStripMenuItem.Click += new System.EventHandler(this.drawPointToolStripMenuItem_Click);
            // 
            // drawLineToolStripMenuItem
            // 
            this.drawLineToolStripMenuItem.Name = "drawLineToolStripMenuItem";
            this.drawLineToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.drawLineToolStripMenuItem.Text = "DrawLine";
            this.drawLineToolStripMenuItem.Click += new System.EventHandler(this.drawLineToolStripMenuItem_Click);
            // 
            // drawPolygonToolStripMenuItem
            // 
            this.drawPolygonToolStripMenuItem.Name = "drawPolygonToolStripMenuItem";
            this.drawPolygonToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.drawPolygonToolStripMenuItem.Text = "DrawPolygon";
            this.drawPolygonToolStripMenuItem.Click += new System.EventHandler(this.drawPolygonToolStripMenuItem_Click);
            // 
            // labelMapToolStripMenuItem
            // 
            this.labelMapToolStripMenuItem.Name = "labelMapToolStripMenuItem";
            this.labelMapToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.labelMapToolStripMenuItem.Text = "LabelMap";
            this.labelMapToolStripMenuItem.Click += new System.EventHandler(this.labelMapToolStripMenuItem_Click);
            // 
            // movemapToolStripMenuItem
            // 
            this.movemapToolStripMenuItem.Name = "movemapToolStripMenuItem";
            this.movemapToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.movemapToolStripMenuItem.Text = "Movemap";
            this.movemapToolStripMenuItem.Click += new System.EventHandler(this.movemapToolStripMenuItem_Click);
            // 
            // openDocToolStripMenuItem
            // 
            this.openDocToolStripMenuItem.Name = "openDocToolStripMenuItem";
            this.openDocToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.openDocToolStripMenuItem.Text = "OpenDoc";
            this.openDocToolStripMenuItem.Click += new System.EventHandler(this.openDocToolStripMenuItem_Click);
            // 
            // saveDocToolStripMenuItem
            // 
            this.saveDocToolStripMenuItem.Name = "saveDocToolStripMenuItem";
            this.saveDocToolStripMenuItem.Size = new System.Drawing.Size(191, 30);
            this.saveDocToolStripMenuItem.Text = "SaveDoc";
            this.saveDocToolStripMenuItem.Click += new System.EventHandler(this.saveDocToolStripMenuItem_Click);
            // 
            // synbolMapToolStripMenuItem
            // 
            this.synbolMapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.simpleToolStripMenuItem,
            this.classicBreakRenderToolStripMenuItem,
            this.uniqueBreakRenderToolStripMenuItem,
            this.proportionalSymbolToolStripMenuItem,
            this.barChartSymbolToolStripMenuItem,
            this.stackedChartSymbolToolStripMenuItem,
            this.pieChartToolStripMenuItem,
            this.dotDensityToolStripMenuItem});
            this.synbolMapToolStripMenuItem.Name = "synbolMapToolStripMenuItem";
            this.synbolMapToolStripMenuItem.Size = new System.Drawing.Size(177, 29);
            this.synbolMapToolStripMenuItem.Text = "SymbolMapRender";
            this.synbolMapToolStripMenuItem.Click += new System.EventHandler(this.synbolMapToolStripMenuItem_Click);
            // 
            // simpleToolStripMenuItem
            // 
            this.simpleToolStripMenuItem.Name = "simpleToolStripMenuItem";
            this.simpleToolStripMenuItem.Size = new System.Drawing.Size(249, 30);
            this.simpleToolStripMenuItem.Text = "Simple";
            this.simpleToolStripMenuItem.Click += new System.EventHandler(this.simpleToolStripMenuItem_Click);
            // 
            // classicBreakRenderToolStripMenuItem
            // 
            this.classicBreakRenderToolStripMenuItem.Name = "classicBreakRenderToolStripMenuItem";
            this.classicBreakRenderToolStripMenuItem.Size = new System.Drawing.Size(249, 30);
            this.classicBreakRenderToolStripMenuItem.Text = "ClassicBreak";
            this.classicBreakRenderToolStripMenuItem.Click += new System.EventHandler(this.classicBreakRenderToolStripMenuItem_Click);
            // 
            // uniqueBreakRenderToolStripMenuItem
            // 
            this.uniqueBreakRenderToolStripMenuItem.Name = "uniqueBreakRenderToolStripMenuItem";
            this.uniqueBreakRenderToolStripMenuItem.Size = new System.Drawing.Size(249, 30);
            this.uniqueBreakRenderToolStripMenuItem.Text = "UniqueValue";
            this.uniqueBreakRenderToolStripMenuItem.Click += new System.EventHandler(this.uniqueBreakRenderToolStripMenuItem_Click);
            // 
            // proportionalSymbolToolStripMenuItem
            // 
            this.proportionalSymbolToolStripMenuItem.Name = "proportionalSymbolToolStripMenuItem";
            this.proportionalSymbolToolStripMenuItem.Size = new System.Drawing.Size(249, 30);
            this.proportionalSymbolToolStripMenuItem.Text = "ProportionalSymbol";
            this.proportionalSymbolToolStripMenuItem.Click += new System.EventHandler(this.proportionalSymbolToolStripMenuItem_Click);
            // 
            // barChartSymbolToolStripMenuItem
            // 
            this.barChartSymbolToolStripMenuItem.Name = "barChartSymbolToolStripMenuItem";
            this.barChartSymbolToolStripMenuItem.Size = new System.Drawing.Size(249, 30);
            this.barChartSymbolToolStripMenuItem.Text = "BarChartSymbol";
            this.barChartSymbolToolStripMenuItem.Click += new System.EventHandler(this.barChartSymbolToolStripMenuItem_Click);
            // 
            // stackedChartSymbolToolStripMenuItem
            // 
            this.stackedChartSymbolToolStripMenuItem.Name = "stackedChartSymbolToolStripMenuItem";
            this.stackedChartSymbolToolStripMenuItem.Size = new System.Drawing.Size(249, 30);
            this.stackedChartSymbolToolStripMenuItem.Text = "StackedChartSymbol";
            this.stackedChartSymbolToolStripMenuItem.Click += new System.EventHandler(this.stackedChartSymbolToolStripMenuItem_Click);
            // 
            // pieChartToolStripMenuItem
            // 
            this.pieChartToolStripMenuItem.Name = "pieChartToolStripMenuItem";
            this.pieChartToolStripMenuItem.Size = new System.Drawing.Size(249, 30);
            this.pieChartToolStripMenuItem.Text = "PieChart";
            this.pieChartToolStripMenuItem.Click += new System.EventHandler(this.pieChartToolStripMenuItem_Click);
            // 
            // dotDensityToolStripMenuItem
            // 
            this.dotDensityToolStripMenuItem.Name = "dotDensityToolStripMenuItem";
            this.dotDensityToolStripMenuItem.Size = new System.Drawing.Size(249, 30);
            this.dotDensityToolStripMenuItem.Text = "DotDensity";
            this.dotDensityToolStripMenuItem.Click += new System.EventHandler(this.dotDensityToolStripMenuItem_Click);
            // 
            // 查询ToolStripMenuItem
            // 
            this.查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询工具ToolStripMenuItem,
            this.刷新ToolStripMenuItem,
            this.固定查询ToolStripMenuItem,
            this.清空选择ToolStripMenuItem,
            this.刷新ToolStripMenuItem1});
            this.查询ToolStripMenuItem.Name = "查询ToolStripMenuItem";
            this.查询ToolStripMenuItem.Size = new System.Drawing.Size(114, 29);
            this.查询ToolStripMenuItem.Text = "查询与属性";
            this.查询ToolStripMenuItem.Click += new System.EventHandler(this.查询ToolStripMenuItem_Click);
            // 
            // 查询工具ToolStripMenuItem
            // 
            this.查询工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.点查询ToolStripMenuItem,
            this.线查询ToolStripMenuItem,
            this.面查询ToolStripMenuItem});
            this.查询工具ToolStripMenuItem.Name = "查询工具ToolStripMenuItem";
            this.查询工具ToolStripMenuItem.Size = new System.Drawing.Size(174, 30);
            this.查询工具ToolStripMenuItem.Text = "查询工具";
            // 
            // 点查询ToolStripMenuItem
            // 
            this.点查询ToolStripMenuItem.Name = "点查询ToolStripMenuItem";
            this.点查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.点查询ToolStripMenuItem.Text = "点查询";
            this.点查询ToolStripMenuItem.Click += new System.EventHandler(this.点查询ToolStripMenuItem_Click);
            // 
            // 线查询ToolStripMenuItem
            // 
            this.线查询ToolStripMenuItem.Name = "线查询ToolStripMenuItem";
            this.线查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.线查询ToolStripMenuItem.Text = "线查询";
            this.线查询ToolStripMenuItem.Click += new System.EventHandler(this.线查询ToolStripMenuItem_Click);
            // 
            // 面查询ToolStripMenuItem
            // 
            this.面查询ToolStripMenuItem.Name = "面查询ToolStripMenuItem";
            this.面查询ToolStripMenuItem.Size = new System.Drawing.Size(152, 30);
            this.面查询ToolStripMenuItem.Text = "面查询";
            this.面查询ToolStripMenuItem.Click += new System.EventHandler(this.面查询ToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(174, 30);
            this.刷新ToolStripMenuItem.Text = "获得属性表";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.刷新ToolStripMenuItem_Click);
            // 
            // 刷新ToolStripMenuItem1
            // 
            this.刷新ToolStripMenuItem1.Name = "刷新ToolStripMenuItem1";
            this.刷新ToolStripMenuItem1.Size = new System.Drawing.Size(174, 30);
            this.刷新ToolStripMenuItem1.Text = "刷新";
            this.刷新ToolStripMenuItem1.Click += new System.EventHandler(this.刷新ToolStripMenuItem1_Click);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(312, 36);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(897, 712);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.axMapControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(889, 679);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "地图";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // axMapControl1
            // 
            this.axMapControl1.Location = new System.Drawing.Point(0, 3);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(886, 676);
            this.axMapControl1.TabIndex = 0;
            this.axMapControl1.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl1_OnMouseDown_1);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(889, 679);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "属性表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(886, 680);
            this.dataGridView1.TabIndex = 0;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Location = new System.Drawing.Point(12, 36);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(294, 340);
            this.axTOCControl1.TabIndex = 2;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            this.axTOCControl1.OnMouseUp += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseUpEventHandler(this.axTOCControl1_OnMouseUp_1);
            // 
            // axMapControl2
            // 
            this.axMapControl2.Location = new System.Drawing.Point(12, 382);
            this.axMapControl2.Name = "axMapControl2";
            this.axMapControl2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl2.OcxState")));
            this.axMapControl2.Size = new System.Drawing.Size(294, 366);
            this.axMapControl2.TabIndex = 4;
            this.axMapControl2.OnMouseDown += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseDownEventHandler(this.axMapControl2_OnMouseDown);
            // 
            // 固定查询ToolStripMenuItem
            // 
            this.固定查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.认识查询ToolStripMenuItem,
            this.属性查询ToolStripMenuItem,
            this.空间查询ToolStripMenuItem});
            this.固定查询ToolStripMenuItem.Name = "固定查询ToolStripMenuItem";
            this.固定查询ToolStripMenuItem.Size = new System.Drawing.Size(174, 30);
            this.固定查询ToolStripMenuItem.Text = "固定查询";
            // 
            // 认识查询ToolStripMenuItem
            // 
            this.认识查询ToolStripMenuItem.Name = "认识查询ToolStripMenuItem";
            this.认识查询ToolStripMenuItem.Size = new System.Drawing.Size(156, 30);
            this.认识查询ToolStripMenuItem.Text = "认识查询";
            this.认识查询ToolStripMenuItem.Click += new System.EventHandler(this.认识查询ToolStripMenuItem_Click);
            // 
            // 属性查询ToolStripMenuItem
            // 
            this.属性查询ToolStripMenuItem.Name = "属性查询ToolStripMenuItem";
            this.属性查询ToolStripMenuItem.Size = new System.Drawing.Size(156, 30);
            this.属性查询ToolStripMenuItem.Text = "属性查询";
            this.属性查询ToolStripMenuItem.Click += new System.EventHandler(this.属性查询ToolStripMenuItem_Click);
            // 
            // 空间查询ToolStripMenuItem
            // 
            this.空间查询ToolStripMenuItem.Name = "空间查询ToolStripMenuItem";
            this.空间查询ToolStripMenuItem.Size = new System.Drawing.Size(156, 30);
            this.空间查询ToolStripMenuItem.Text = "空间查询";
            this.空间查询ToolStripMenuItem.Click += new System.EventHandler(this.空间查询ToolStripMenuItem_Click);
            // 
            // 清空选择ToolStripMenuItem
            // 
            this.清空选择ToolStripMenuItem.Name = "清空选择ToolStripMenuItem";
            this.清空选择ToolStripMenuItem.Size = new System.Drawing.Size(174, 30);
            this.清空选择ToolStripMenuItem.Text = "清空选择";
            this.清空选择ToolStripMenuItem.Click += new System.EventHandler(this.清空选择ToolStripMenuItem_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 760);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axMapControl2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem operateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lKZoomInToolStripMenuItem;
        private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl2;
        private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
        private System.Windows.Forms.ToolStripMenuItem addShpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addRasterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCADToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addTINToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveDocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawPointToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawLineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drawPolygonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem labelMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movemapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem synbolMapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem simpleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem classicBreakRenderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uniqueBreakRenderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proportionalSymbolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem barChartSymbolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stackedChartSymbolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pieChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dotDensityToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem 查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 点查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 线查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 面查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 固定查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 认识查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 属性查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 空间查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清空选择ToolStripMenuItem;
    }
}

