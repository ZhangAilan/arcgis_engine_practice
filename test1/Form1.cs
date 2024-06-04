using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.DisplayUI;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;


namespace test1
{
    public partial class Form1 : Form
    {
        string GeoOpType = string.Empty;
        private string tool = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            OpenDlg.Title = "Please choose your file.";
            OpenDlg.Filter = "Vector Files(*.shp)|*.shp";
            OpenDlg.Multiselect = true;
            OpenDlg.ShowDialog();
            string[] strFileName = OpenDlg.FileNames;
            if (strFileName.Length > 0)
            {
                IAddGeoData pAddGeoData = new GeoMapAO();
                pAddGeoData.StrFileName = strFileName;
                pAddGeoData.AxMapControl1 = axMapControl1;
                pAddGeoData.AxMapControl2 = axMapControl2;
                pAddGeoData.AddGeoMap();
            }
        }

        private void lKZoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeoOpType = "LKZoomIn";
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            if (GeoOpType == string.Empty)
                return;
            IGeoDataOper pGeoMapOp = new GeoMapAO();
            pGeoMapOp.StrOperType = GeoOpType;
            pGeoMapOp.AxMapControl1 = axMapControl1;
            pGeoMapOp.AxMapControl2 = axMapControl2;
            pGeoMapOp.E = e;
            pGeoMapOp.OperMap();
        }

        private void addShpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Use the file dialog box to get the path and name of the shp file
            OpenFileDialog OpenDlg = new OpenFileDialog();
            OpenDlg.Title = "Please choose your file.";
            OpenDlg.Filter = "Vector Files(*.shp)|*.shp";
            OpenDlg.Multiselect = true;
            OpenDlg.ShowDialog();
            string strFileName = OpenDlg.FileName;

            string pathName = System.IO.Path.GetDirectoryName(strFileName);
            string fileName = System.IO.Path.GetFileNameWithoutExtension(strFileName);  //extract the file name and remove the file extension

            //method 1
            //axMapControl1.AddShapeFile(pathName, fileName);
            //axMapControl1.Extent = axMapControl1.FullExtent;  //display the entire map range

            //method 2
            IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory();
            IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(pathName, 0);
            IFeatureWorkspace pFeatureWorkspace;
            pFeatureWorkspace = pWorkspace as IFeatureWorkspace;
            IFeatureClass pFeatureClass = pFeatureWorkspace.OpenFeatureClass(fileName);
            IDataset pDataset = pFeatureClass as IDataset;
            IFeatureLayer pFeatureLayer = new FeatureLayerClass();
            pFeatureLayer.FeatureClass = pFeatureClass;
            pFeatureLayer.Name = pDataset.Name;
            ILayer pLayer = pFeatureLayer as ILayer;
            axMapControl1.Map.AddLayer(pLayer);
        }



        private void addRasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            OpenDlg.Title = "Please choose your file.";
            OpenDlg.Filter = "Raster Files(*.bmp;*.tif;*.jps)|*.bmp;*.tif;*.jpg|All files(*.*)|*.*";
            OpenDlg.Multiselect = true;
            OpenDlg.ShowDialog();
            string[] strFileName = OpenDlg.FileNames;
            if (strFileName.Length > 0)
            {
                IAddGeoData pAddGeoData = new GeoMapAO();
                pAddGeoData.StrFileName = strFileName;
                pAddGeoData.AxMapControl1 = axMapControl1;
                pAddGeoData.AxMapControl2 = axMapControl2;
                pAddGeoData.AddGeoMap();
            }
        }

        private void openCADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDlg = new OpenFileDialog();
            OpenDlg.Title = "Please choose your file.";
            OpenDlg.Filter = "CAD Files(*.dwg)|*.dwg";
            OpenDlg.Multiselect = true;
            OpenDlg.ShowDialog();
            string[] strFileName = OpenDlg.FileNames;
            if (strFileName.Length > 0)
            {
                IAddGeoData pAddGeoData = new GeoMapAO();
                pAddGeoData.StrFileName = strFileName;
                pAddGeoData.AxMapControl1 = axMapControl1;
                pAddGeoData.AxMapControl2 = axMapControl2;
                pAddGeoData.AddGeoMap();
            }
        }

        private void addTINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IAddGeoData pAddGeoData = new GeoMapAO();
            pAddGeoData.AxMapControl1 = axMapControl1;
            pAddGeoData.AddTINDataset();
        }

        private void openDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDlg3 = new OpenFileDialog();
            OpenDlg3.Title = "请选择地理数据文件";
            OpenDlg3.Filter = "地图数据文件(*.mxd)|*.mxd";
            OpenDlg3.ShowDialog();

            string strFileName = OpenDlg3.FileName;
            if (axMapControl1.CheckMxFile(strFileName))
            {
                axMapControl1.MousePointer = esriControlsMousePointer.esriPointerHourglass;
                axMapControl1.LoadMxFile(strFileName, 0, Type.Missing);
                axMapControl1.MousePointer = esriControlsMousePointer.esriPointerDefault;
            }
            else
            {
                MessageBox.Show("该文件不是地图文档文件", "信息提示");
                return;

            }
        }

        private void saveDocToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        ILaySequAttr AdjLay = new GeoMapAO();
        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            AdjLay.AxMapControl1 = axMapControl1;
            AdjLay.AxTOCControl1 = axTOCControl1;
            AdjLay.Ted = e;
            AdjLay.MTOCControl = axTOCControl1.Object as ITOCControl;
            AdjLay.AdjLayMd();
        }
       

        private void Form1_Load(object sender, EventArgs e)
        {
            pMap = this.axMapControl1.Map;
            pActiveView = this.axMapControl1.ActiveView;
        }

        private void axMapControl2_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {

        }

        private void drawPointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeoOpType = "DrawPoint";
        }

        private void drawLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeoOpType = "DrawLine";
        }

        private void drawPolygonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeoOpType = "DrawPolygon";
        }

        private void labelMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeoOpType = "LabelMap";
        }

        private void movemapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeoOpType = "Movemap";
        }

        private void axTOCControl1_OnMouseUp_1(object sender, ITOCControlEvents_OnMouseUpEvent e)
        {
            AdjLay.AxMapControl1 = axMapControl1;
            AdjLay.AxTOCControl1 = axTOCControl1;
            //adjust the order of the layer display
            AdjLay.Teu = e;
            AdjLay.AdjLayMu();
        }


        /*---------------------------------------SymbolMapRender Functions----------------------------------------------------------*/
        //获取颜色对象
        private IRgbColor getRGB(int r, int g, int b)
        {
            IRgbColor pColor;
            pColor = new RgbColorClass();
            pColor.Red = r;
            pColor.Green = g;
            pColor.Blue = b;
            return pColor;
        }

        private IGeoFeatureLayer getGeoLayer(string layerName)
        {
            ILayer layer;
            IGeoFeatureLayer geoFeatureLayer;
            for (int i = 0; i < this.axMapControl1.LayerCount; i++)
            {
                layer = this.axMapControl1.get_Layer(i);
                if (layer != null && layer.Name == layerName)
                {
                    geoFeatureLayer = layer as IGeoFeatureLayer;
                    return geoFeatureLayer;
                }
            }
            return null;
        }

        //创建颜色带
        private IColorRamp CreateAlgorithmicColorRamp(int count)
        {
            //创建一个新AlgorithmicColorRampClass对象
            IAlgorithmicColorRamp algColorRamp = new AlgorithmicColorRampClass();
            IRgbColor fromColor = new RgbColorClass();
            IRgbColor toColor = new RgbColorClass();
            //创建起始颜色对象
            fromColor.Red = 255;
            fromColor.Green = 110;
            fromColor.Blue = 0;
            //创建终止颜色对象           
            toColor.Red = 0;
            toColor.Green = 20;
            toColor.Blue = 255;
            //设置AlgorithmicColorRampClass的起止颜色属性
            algColorRamp.ToColor = fromColor;
            algColorRamp.FromColor = toColor;
            //设置梯度类型
            algColorRamp.Algorithm = esriColorRampAlgorithm.esriCIELabAlgorithm;
            //设置颜色带颜色数量
            algColorRamp.Size = count;
            //创建颜色带
            bool bture = true;
            algColorRamp.CreateRamp(out bture);
            return algColorRamp;
        }

        private void simpleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //简单填充符号
            ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbolClass();
            simpleFillSymbol.Style = esriSimpleFillStyle.esriSFSDiagonalCross;
            simpleFillSymbol.Color = getRGB(255, 0, 0);
            //创建边线符号
            ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbolClass();
            simpleLineSymbol.Style = esriSimpleLineStyle.esriSLSDashDotDot;
            simpleLineSymbol.Color = getRGB(0, 255, 0);
            ISymbol symbol = simpleLineSymbol as ISymbol;
            symbol.ROP2 = esriRasterOpCode.esriROPNotXOrPen;
            simpleFillSymbol.Outline = simpleLineSymbol;

            ISimpleRenderer simpleRender = new SimpleRendererClass();
            simpleRender.Symbol = simpleFillSymbol as ISymbol;
            simpleRender.Label = "continent";
            simpleRender.Description = "简单渲染";

            IGeoFeatureLayer geoFeatureLayer;
            geoFeatureLayer = getGeoLayer("Continents");
            if (geoFeatureLayer != null)
            {
                geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
            }
            this.axMapControl1.Refresh();
        }

        private void synbolMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void classicBreakRenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int classCount = 6;
            ITableHistogram tableHistogram;
            IBasicHistogram basicHistogram;
            ITable table;
            IGeoFeatureLayer geoFeatureLayer;
            geoFeatureLayer = getGeoLayer("Continents");
            ILayer layer = geoFeatureLayer as ILayer;
            table = layer as ITable;
            tableHistogram = new BasicTableHistogramClass();
            //按照 数值字段分级
            tableHistogram.Table = table;
            tableHistogram.Field = "sqmi";
            basicHistogram = tableHistogram as IBasicHistogram;
            object values;
            object frequencys;
            //先统计每个值和各个值出现的次数
            basicHistogram.GetHistogram(out values, out frequencys);
            //创建平均分级对象
            IClassifyGEN classifyGEN = new QuantileClass();
            //用统计结果进行分级 ，级别数目为classCount
            classifyGEN.Classify(values, frequencys, ref classCount);
            //获得分级结果,是个 双精度类型数组 
            double[] classes;
            classes = classifyGEN.ClassBreaks as double[];

            IEnumColors enumColors = CreateAlgorithmicColorRamp(classes.Length).Colors;
            IColor color;

            IClassBreaksRenderer classBreaksRenderer = new ClassBreaksRendererClass();
            classBreaksRenderer.Field = "sqmi";
            classBreaksRenderer.BreakCount = classCount;
            classBreaksRenderer.SortClassesAscending = true;

            ISimpleFillSymbol simpleFillSymbol;
            for (int i = 0; i < classes.Length - 1; i++)
            {
                color = enumColors.Next();
                simpleFillSymbol = new SimpleFillSymbolClass();
                simpleFillSymbol.Color = color;
                simpleFillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;

                classBreaksRenderer.set_Symbol(i, simpleFillSymbol as ISymbol);
                classBreaksRenderer.set_Break(i, classes[i]);

            }

            if (geoFeatureLayer != null)
            {
                geoFeatureLayer.Renderer = classBreaksRenderer as IFeatureRenderer;
            }

            this.axMapControl1.ActiveView.Refresh();         
        }

        private void uniqueBreakRenderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IGeoFeatureLayer geoFeatureLayer;
            geoFeatureLayer = getGeoLayer("Continents");
            IUniqueValueRenderer uniqueValueRenderer = new UniqueValueRendererClass();
            uniqueValueRenderer.FieldCount = 1;
            uniqueValueRenderer.set_Field(0, "continent");

            //简单填充符号
            ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbolClass();
            simpleFillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;

            IFeatureCursor featureCursor = geoFeatureLayer.FeatureClass.Search(null, false);
            IFeature feature;

            if (featureCursor != null)
            {
                IEnumColors enumColors = CreateAlgorithmicColorRamp(8).Colors;
                int fieldIndex = geoFeatureLayer.FeatureClass.Fields.FindField("continent");
                for (int i = 0; i < 8; i++)
                {
                    feature = featureCursor.NextFeature();
                    string nameValue = feature.get_Value(fieldIndex).ToString();
                    simpleFillSymbol = new SimpleFillSymbolClass();
                    simpleFillSymbol.Color = enumColors.Next();
                    uniqueValueRenderer.AddValue(nameValue, "continent", simpleFillSymbol as ISymbol);
                }
            }

            geoFeatureLayer.Renderer = uniqueValueRenderer as IFeatureRenderer;
            this.axMapControl1.Refresh();
        }

        private void proportionalSymbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IGeoFeatureLayer geoFeatureLayer;
            IFeatureLayer featureLayer;
            IProportionalSymbolRenderer proportionalSymbolRenderer;
            ITable table;
            ICursor cursor;
            IDataStatistics dataStatistics;
            IStatisticsResults statisticsResult;
            stdole.IFontDisp fontDisp;

            geoFeatureLayer = getGeoLayer("Continents");
            featureLayer = geoFeatureLayer as IFeatureLayer;
            table = geoFeatureLayer as ITable;
            cursor = table.Search(null, true);
            dataStatistics = new DataStatisticsClass();
            dataStatistics.Cursor = cursor;
            dataStatistics.Field = "sqmi";
            statisticsResult = dataStatistics.Statistics;
            if (statisticsResult != null)
            {
                IFillSymbol fillSymbol = new SimpleFillSymbolClass();
                fillSymbol.Color = getRGB(0, 255, 0);
                ICharacterMarkerSymbol characterMarkerSymbol = new CharacterMarkerSymbolClass();
                fontDisp = new stdole.StdFontClass() as stdole.IFontDisp;
                fontDisp.Name = "arial";
                fontDisp.Size = 20;
                characterMarkerSymbol.Font = fontDisp;
                characterMarkerSymbol.CharacterIndex = 90;
                characterMarkerSymbol.Color = getRGB(255, 0, 0);
                characterMarkerSymbol.Size = 8;
                proportionalSymbolRenderer = new ProportionalSymbolRendererClass();
                proportionalSymbolRenderer.ValueUnit = esriUnits.esriUnknownUnits;
                proportionalSymbolRenderer.Field = "sqmi";
                proportionalSymbolRenderer.FlanneryCompensation = false;
                proportionalSymbolRenderer.MinDataValue = statisticsResult.Minimum;
                proportionalSymbolRenderer.MaxDataValue = statisticsResult.Maximum;
                proportionalSymbolRenderer.BackgroundSymbol = fillSymbol;
                proportionalSymbolRenderer.MinSymbol = characterMarkerSymbol as ISymbol;
                proportionalSymbolRenderer.LegendSymbolCount = 10;
                proportionalSymbolRenderer.CreateLegendSymbols();
                geoFeatureLayer.Renderer = proportionalSymbolRenderer as IFeatureRenderer;
            }
            this.axMapControl1.Refresh();
        }

        private void barChartSymbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IGeoFeatureLayer geoFeatureLayer;
            IFeatureLayer featureLayer;
            ITable table;
            ICursor cursor;
            IRowBuffer rowBuffer;
            //设置渲染要素
            string field1 = "sqmi";
            string field2 = "sqkm";
            //获取渲染图层
            geoFeatureLayer = getGeoLayer("Continents");
            featureLayer = geoFeatureLayer as IFeatureLayer;
            table = featureLayer as ITable;
            geoFeatureLayer.ScaleSymbols = true;
            IChartRenderer chartRenderer = new ChartRendererClass();
            IRendererFields rendererFields = chartRenderer as IRendererFields;
            rendererFields.AddField(field1, field1);
            rendererFields.AddField(field2, field2);
            int[] fieldIndexs = new int[2];
            fieldIndexs[0] = table.FindField(field1);
            fieldIndexs[1] = table.FindField(field2);
            //获取要素最大值
            double fieldValue = 0.0, maxValue = 0.0;
            cursor = table.Search(null, true);
            rowBuffer = cursor.NextRow();
            while (rowBuffer != null)
            {
                for (int i = 0; i < 2; i++)
                {
                    fieldValue = double.Parse(rowBuffer.get_Value(fieldIndexs[i]).ToString());
                    if (fieldValue > maxValue)
                    {
                        maxValue = fieldValue;
                    }
                }
                rowBuffer = cursor.NextRow();
            }
            //创建水平排列符号
            IBarChartSymbol barChartSymbol = new BarChartSymbolClass();
            barChartSymbol.Width = 10;
            IMarkerSymbol markerSymbol = barChartSymbol as IMarkerSymbol;
            markerSymbol.Size = 50;
            IChartSymbol chartSymbol = barChartSymbol as IChartSymbol;
            chartSymbol.MaxValue = maxValue;
            //添加渲染符号
            ISymbolArray symbolArray = barChartSymbol as ISymbolArray;
            IFillSymbol fillSymbol = new SimpleFillSymbolClass();
            fillSymbol.Color = getRGB(255, 0, 0);
            symbolArray.AddSymbol(fillSymbol as ISymbol);
            fillSymbol = new SimpleFillSymbolClass();
            fillSymbol.Color = getRGB(0, 255, 0);
            symbolArray.AddSymbol(fillSymbol as ISymbol);
            //设置柱状图符号
            chartRenderer.ChartSymbol = barChartSymbol as IChartSymbol;
            fillSymbol = new SimpleFillSymbolClass();
            fillSymbol.Color = getRGB(0, 0, 255);
            chartRenderer.BaseSymbol = fillSymbol as ISymbol;
            chartRenderer.UseOverposter = false;
            //创建图例
            chartRenderer.CreateLegend();
            geoFeatureLayer.Renderer = chartRenderer as IFeatureRenderer;
            this.axMapControl1.Refresh();
        }

        private void stackedChartSymbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IGeoFeatureLayer geoFeatureLayer;
            IFeatureLayer featureLayer;
            ITable table;
            ICursor cursor;
            IRowBuffer rowBuffer;
            //设置渲染要素
            string field1 = "sqmi";
            string field2 = "sqkm";
            //获取渲染图层
            geoFeatureLayer = getGeoLayer("Continents");
            featureLayer = geoFeatureLayer as IFeatureLayer;
            table = featureLayer as ITable;
            geoFeatureLayer.ScaleSymbols = true;
            IChartRenderer chartRenderer = new ChartRendererClass();
            IRendererFields rendererFields = chartRenderer as IRendererFields;
            rendererFields.AddField(field1, field1);
            rendererFields.AddField(field2, field2);
            int[] fieldIndexs = new int[2];
            fieldIndexs[0] = table.FindField(field1);
            fieldIndexs[1] = table.FindField(field2);
            //获取要素最大值
            double fieldValue = 0.0, maxValue = 0.0;
            cursor = table.Search(null, true);
            rowBuffer = cursor.NextRow();
            while (rowBuffer != null)
            {
                for (int i = 0; i < 2; i++)
                {
                    fieldValue = double.Parse(rowBuffer.get_Value(fieldIndexs[i]).ToString());
                    if (fieldValue > maxValue)
                    {
                        maxValue = fieldValue;
                    }
                }
                rowBuffer = cursor.NextRow();
            }
            //创建累积排列符号
            IStackedChartSymbol stackedChartSymbol = new StackedChartSymbolClass();

            stackedChartSymbol.Width = 10;
            IMarkerSymbol markerSymbol = stackedChartSymbol as IMarkerSymbol;
            markerSymbol.Size = 50;
            IChartSymbol chartSymbol = stackedChartSymbol as IChartSymbol;
            chartSymbol.MaxValue = maxValue;
            //添加渲染符号
            ISymbolArray symbolArray = stackedChartSymbol as ISymbolArray;
            IFillSymbol fillSymbol = new SimpleFillSymbolClass();
            fillSymbol.Color = getRGB(255, 0, 0);
            symbolArray.AddSymbol(fillSymbol as ISymbol);
            fillSymbol = new SimpleFillSymbolClass();
            fillSymbol.Color = getRGB(0, 255, 0);
            symbolArray.AddSymbol(fillSymbol as ISymbol);
            //设置柱状图符号
            chartRenderer.ChartSymbol = stackedChartSymbol as IChartSymbol;
            fillSymbol = new SimpleFillSymbolClass();
            fillSymbol.Color = getRGB(0, 0, 255);
            chartRenderer.BaseSymbol = fillSymbol as ISymbol;
            chartRenderer.UseOverposter = false;
            //创建图例
            chartRenderer.CreateLegend();
            geoFeatureLayer.Renderer = chartRenderer as IFeatureRenderer;
            this.axMapControl1.Refresh();
        }

        private void pieChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IGeoFeatureLayer geoFeatureLayer;
            IFeatureLayer featureLayer;
            ITable table;
            ICursor cursor;
            IRowBuffer rowBuffer;
            //设置饼图的要素
            string field1 = "sqmi";
            string field2 = "sqkm";
            //获取渲染图层
            geoFeatureLayer = getGeoLayer("Continents");
            featureLayer = geoFeatureLayer as IFeatureLayer;
            table = featureLayer as ITable;
            geoFeatureLayer.ScaleSymbols = true;
            IChartRenderer chartRenderer = new ChartRendererClass();
            IPieChartRenderer pieChartRenderer = chartRenderer as IPieChartRenderer;
            IRendererFields rendererFields = chartRenderer as IRendererFields;
            rendererFields.AddField(field1, field1);
            rendererFields.AddField(field2, field2);
            int[] fieldIndexs = new int[2];
            fieldIndexs[0] = table.FindField(field1);
            fieldIndexs[1] = table.FindField(field2);
            //获取渲染要素的最大值
            double fieldValue = 0.0, maxValue = 0.0;
            cursor = table.Search(null, true);
            rowBuffer = cursor.NextRow();
            while (rowBuffer != null)
            {
                for (int i = 0; i < 2; i++)
                {
                    fieldValue = double.Parse(rowBuffer.get_Value(fieldIndexs[i]).ToString());
                    if (fieldValue > maxValue)
                    {
                        maxValue = fieldValue;
                    }
                }
                rowBuffer = cursor.NextRow();
            }
            //设置饼图符号
            IPieChartSymbol pieChartSymbol = new PieChartSymbolClass();
            pieChartSymbol.Clockwise = true;
            pieChartSymbol.UseOutline = true;
            IChartSymbol chartSymbol = pieChartSymbol as IChartSymbol;
            chartSymbol.MaxValue = maxValue;
            ILineSymbol lineSymbol = new SimpleLineSymbolClass();
            lineSymbol.Color = getRGB(255, 0, 0);
            lineSymbol.Width = 2;
            pieChartSymbol.Outline = lineSymbol;
            IMarkerSymbol markerSymbol = pieChartSymbol as IMarkerSymbol;
            markerSymbol.Size = 30;
            //添加渲染符号
            ISymbolArray symbolArray = pieChartSymbol as ISymbolArray;
            IFillSymbol fillSymbol = new SimpleFillSymbolClass();
            fillSymbol.Color = getRGB(0, 255, 0);
            symbolArray.AddSymbol(fillSymbol as ISymbol);
            fillSymbol = new SimpleFillSymbolClass();
            fillSymbol.Color = getRGB(0, 0, 255);
            symbolArray.AddSymbol(fillSymbol as ISymbol);
            chartRenderer.ChartSymbol = pieChartSymbol as IChartSymbol;
            fillSymbol = new SimpleFillSymbolClass();
            fillSymbol.Color = getRGB(100, 100, 100);
            chartRenderer.BaseSymbol = fillSymbol as ISymbol;
            chartRenderer.UseOverposter = false;
            //创建图例
            chartRenderer.CreateLegend();
            geoFeatureLayer.Renderer = chartRenderer as IFeatureRenderer;
            this.axMapControl1.Refresh();
        }

        private void dotDensityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IGeoFeatureLayer geoFeatureLayer;
            IDotDensityFillSymbol dotDensityFillSymbol;
            IDotDensityRenderer dotDensityRenderer;
            //获取渲染图层
            geoFeatureLayer = getGeoLayer("Continents");
            dotDensityRenderer = new DotDensityRendererClass();
            IRendererFields rendererFields = dotDensityRenderer as IRendererFields;
            //设置渲染字段
            string field1 = "sqmi";
            rendererFields.AddField(field1, field1);
            //设置填充颜色和背景色
            dotDensityFillSymbol = new DotDensityFillSymbolClass();
            dotDensityFillSymbol.DotSize = 3;
            dotDensityFillSymbol.Color = getRGB(255, 0, 0);
            dotDensityFillSymbol.BackgroundColor = getRGB(0, 255, 0);
            //设置渲染符号
            ISymbolArray symbolArray = dotDensityFillSymbol as ISymbolArray;
            ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
            simpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
            simpleMarkerSymbol.Size = 2;
            simpleMarkerSymbol.Color = getRGB(0, 0, 255);
            symbolArray.AddSymbol(simpleMarkerSymbol as ISymbol);
            dotDensityRenderer.DotDensitySymbol = dotDensityFillSymbol;
            //设置渲染密度
            dotDensityRenderer.DotValue = 50000;
            //创建图例
            dotDensityRenderer.CreateLegend();
            geoFeatureLayer.Renderer = dotDensityRenderer as IFeatureRenderer;
            this.axMapControl1.Refresh();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void axMapControl1_OnMouseDown_1(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            switch (tool)
            {
                case "点查询":
                    double x = e.mapX;
                    double y = e.mapY;
                    string Re_Field = null;
                    Re_Field = GetField(x, y);
                    MessageBox.Show(Re_Field);
                    break;
                case "面查询":
                    IPolygon pPolygon = null;
                    pPolygon = (IPolygon)this.axMapControl1.TrackPolygon();
                    SelectMouseTrack(pPolygon);
                    axMapControl1.Refresh();
                    break;
                case "线查询":
                    IPolyline pPolyline = null;
                    pPolyline = (IPolyline)this.axMapControl1.TrackLine();
                    SelectMouseTrackLine(pPolyline);
                    axMapControl1.Refresh();
                    break;
                default:
                    break;
            }

            if (GeoOpType == string.Empty)
                return;
            IGeoDataOper pGeoMapOp = new GeoMapAO();
            pGeoMapOp.StrOperType = GeoOpType;
            pGeoMapOp.AxMapControl1 = axMapControl1;
            pGeoMapOp.AxMapControl2 = axMapControl2;
            pGeoMapOp.E = e;
            pGeoMapOp.OperMap();
        }

        //点查询并显示字段值，只能查询这一个图层
        string Layer_Name = "townshp";   //所需获取的图层的名称
        string FieldName = "CON_NAME";  // 所需获取的属性名称，为字符串类型
        public string GetField(double x, double y)//根据坐标图层名得到指定属性值，返回得到的属性值，获取失败则返回null
        {
            IMap pMap = this.axMapControl1.Map;  //为传递的参数，一个IMap地图接口类型的变量，为原始地图
            if (FieldName == null) return null;
            double CorX = x;
            double CorY = y;
            string Re_Field = null;//最后返回的变量值
            IActiveView pActiveView = pMap as IActiveView;
            int LayerCount = pMap.LayerCount;
            if (LayerCount == 0) return null;//地图中没有图层
            int i;

            bool IsHave = false;
            int findresult = -1;
            for (i = 0; i < LayerCount; i++)
            {
                IFeatureLayer pFeaturelayer = pMap.get_Layer(i) as IFeatureLayer;
                if (pFeaturelayer == null)
                {
                    continue;
                }
                IFeatureClass pFeatureClass = pFeaturelayer.FeatureClass;
                if (pFeaturelayer.Name != Layer_Name) continue;//找到指定获取的图层

                IsHave = true;
                IPoint point = new PointClass();//创建点
                point.X = CorX;
                point.Y = CorY;
                //ITopologicalOperator接口用来通过对已存在的几何对象做空间拓扑运算以产生新的结合对象。缓冲区分析，裁剪几何图形，几何图形差分操作，几何图形合并操作等都需要使用此接口。 
                ITopologicalOperator pTOpo = point as ITopologicalOperator;
                double length;
                length = ConvertPixelsToMapUnits(pActiveView, 4);

                IGeometry pBuffer = pTOpo.Buffer(length);
                IGeometry pGeo = pBuffer.Envelope;

                ISpatialFilter pSpatialFilter = new SpatialFilterClass();//空间滤过器
                pSpatialFilter.Geometry = pGeo;

                switch (pFeatureClass.ShapeType)//判断当前图层的类型、点？线？面？....
                {
                    case esriGeometryType.esriGeometryPoint:
                        pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelContains;
                        break;
                    case esriGeometryType.esriGeometryPolyline:
                        pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelCrosses;
                        break;
                    case esriGeometryType.esriGeometryPolygon:
                        pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                        break;
                }
                IFeatureSelection pFselection = pFeaturelayer as IFeatureSelection;
                pFselection.SelectFeatures(pSpatialFilter, esriSelectionResultEnum.esriSelectionResultNew, false);

                ISelectionSet pSelectionset = pFselection.SelectionSet;
                ICursor pCursor;
                pSelectionset.Search(null, true, out pCursor);
                IFeatureCursor pFeatCursor = pCursor as IFeatureCursor;//通过游标来查询
                IFeature pFeature = pFeatCursor.NextFeature();

                while (pFeature != null)
                {
                    pMap.SelectFeature(pFeaturelayer, pFeature);
                    findresult = pFeature.Fields.FindField(FieldName);

                    if (findresult == -1)
                    {
                        break;
                    }
                    else
                    {
                        Re_Field = pFeature.get_Value(findresult).ToString();//通过属性名来寻找属性，得到结果
                    }
                    //               count=pFeature.Fields.FieldCount;

                    pFeature = pFeatCursor.NextFeature();
                }

                //显示查找到得要素
                ILayer m_pCurrentLayer = pMap.get_Layer(i);
                IFeatureSelection pFeatSelection = m_pCurrentLayer as IFeatureSelection;
                IQueryFilter pFilter = pSpatialFilter;
                pFeatSelection.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
                pFilter = null;
                if (findresult != -1)
                {
                    break;
                }
            }

            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphicSelection, null, null);

            if (IsHave)
            {
                this.axMapControl1.Refresh();
                return Re_Field;
            }
            else
                return null;
        }

        //距离转换函数
        private double ConvertPixelsToMapUnits(IActiveView pActiveView, double pixelUnits)
        {
            // Uses the ratio of the size of the map in pixels to map units to do the conversion
            IPoint p1 = pActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds.UpperLeft;
            IPoint p2 = pActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds.UpperRight;
            int x1, x2, y1, y2;
            pActiveView.ScreenDisplay.DisplayTransformation.FromMapPoint(p1, out x1, out y1);
            pActiveView.ScreenDisplay.DisplayTransformation.FromMapPoint(p2, out x2, out y2);
            double pixelExtent = x2 - x1;
            double realWorldDisplayExtent = pActiveView.ScreenDisplay.DisplayTransformation.VisibleBounds.Width;
            double sizeOfOnePixel = realWorldDisplayExtent / pixelExtent;
            return pixelUnits * sizeOfOnePixel;
        }

        //面查询
        void SelectMouseTrack(IGeometry pGeo)
        {
            //IFeatureLayer m_pCurrentLayer = this.axMapControl1.Map.get_Layer(0) as IFeatureLayer;
            IFeatureLayer pFeatureLayer = this.axMapControl1.Map.get_Layer(0) as IFeatureLayer;

            ESRI.ArcGIS.Geodatabase.ISpatialFilter pSpatialFilter = new SpatialFilterClass();
            pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
            //设置Geometry属性
            pSpatialFilter.Geometry = pGeo;
            //设置GeometryField属性
            //pSpatialFilter.GeometryField = pFeatureLayer.FeatureClass.ShapeFieldName;

            //查询过滤器
            IQueryFilter pFilter = pSpatialFilter;
            //IFeatureCursor m_pCursor = pFeatureLayer.Search(pFilter, false);
            //IFeature m_pFeature = m_pCursor.NextFeature();

            //显示查找到得要素
            IFeatureSelection pFeatSelection = pFeatureLayer as IFeatureSelection;
            pFeatSelection.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
            pFilter = null;
            this.axMapControl1.Refresh();
        }

        //线查询
        void SelectMouseTrackLine(IGeometry pGeo)
        {
            //IFeatureLayer m_pCurrentLayer = this.axMapControl1.Map.get_Layer(0) as IFeatureLayer;
            IFeatureLayer pFeatureLayer = this.axMapControl1.Map.get_Layer(0) as IFeatureLayer;

            ESRI.ArcGIS.Geodatabase.ISpatialFilter pSpatialFilter = new SpatialFilterClass();
            pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelCrosses;
            //设置Geometry属性
            pSpatialFilter.Geometry = pGeo;
            //设置GeometryField属性
            //pSpatialFilter.GeometryField = pFeatureLayer.FeatureClass.ShapeFieldName;
            //查询过滤器
            IQueryFilter pFilter = pSpatialFilter;
            IFeatureCursor m_pCursor = pFeatureLayer.Search(pFilter, false);
            IFeature m_pFeature = m_pCursor.NextFeature();

            //显示查找到得要素
            IFeatureSelection pFeatSelection = pFeatureLayer as IFeatureSelection;
            pFeatSelection.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
            pFilter = null;
            this.axMapControl1.Refresh();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 点查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = "点查询";
            axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerCrosshair;
        }

        private void 面查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = "面查询";
            axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerCrosshair;
        }

        private void 线查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool = "线查询";
            axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerCrosshair;
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IFeatureLayer layer = this.axMapControl1.Map.get_Layer(0) as IFeatureLayer;
            System.Data.DataTable dt = new DataTable();
            dt = GetLayerData(layer);
            this.dataGridView1.DataSource = dt;
            this.tabControl1.SelectedIndex = 1;
        }
        //获得属性表
        static public DataTable GetLayerData(IFeatureLayer layer)
        {
            DataTable dt = new DataTable();
            Dictionary<string, int> columnKey = new Dictionary<string, int>();
            List<string> columns = new List<string>();
            for (int i = 0; i < layer.FeatureClass.Fields.FieldCount; i++)
            {
                string s = layer.FeatureClass.Fields.get_Field(i).Name;
                columns.Add(s);
            }
            // List<string> columns = Lib.Layer.getLayerField(layer);
            for (int i = 0; i < columns.Count; i++)
            {
                if (columns[i] != "FID" && columns[i] != "Shape")
                {
                    dt.Columns.Add(columns[i]);
                    columnKey.Add(columns[i], i);
                }
            }
            int fragFetureCount = layer.FeatureClass.FeatureCount(null);
            for (int i = 0; i < fragFetureCount; i++)
            {
                DataRow dr = dt.NewRow();
                IFeature pFeature = layer.FeatureClass.GetFeature(i);
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    int index = columnKey[dt.Columns[j].ColumnName];
                    dr[j] = pFeature.get_Value(index);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerDefault;
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenDB();
        }

        //打开DB
        void OpenDB()
        {
            IWorkspaceFactory pWorkspaceFactory;
            IFeatureWorkspace pFeatureWorkspace;
            //IFeatureClass pFeatureClass;

            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "GeoDatabase(*.mdb)|*.mdb";
            of.Multiselect = false;
            DialogResult pDialogResult = of.ShowDialog();
            if (pDialogResult == DialogResult.OK)
            {
                string pPath = of.FileName;
                //获得File Geodatabase类型数据库中的数据的工作空间工厂类 -- FileGDBWorkspaceFactoryClass
                //pWorkspaceFactory = new FileGDBWorkspaceFactoryClass();
                //获得Personal Geodatabase类型数据库中的数据的工作空间工厂类 -- AccessWorkspaceFactoryClass
                pWorkspaceFactory = new ESRI.ArcGIS.DataSourcesGDB.AccessWorkspaceFactoryClass();
                pFeatureWorkspace = pWorkspaceFactory.OpenFromFile(pPath, 0) as IFeatureWorkspace;

                //打开数据文件中的表
                //pFeatureClass = pFeatureWorkspace.OpenFeatureClass("wayshp");
                System.Collections.ArrayList arrayFtInFWS = new ArrayList();
                System.Collections.ArrayList arrayTab = new ArrayList();
                IWorkspace pWs = (IWorkspace)pFeatureWorkspace;
                IEnumDataset pEnumDs = pWs.get_Datasets(esriDatasetType.esriDTAny);
                IDataset pDs = pEnumDs.Next();
                while (pDs != null)
                {
                    esriDatasetType esriDSType = pDs.Type;
                    if (esriDSType == esriDatasetType.esriDTTable)
                    {
                        ITable pTable = (ITable)pDs;
                        arrayTab.Add(pTable);
                        pDs = pEnumDs.Next();
                    }
                    else if (esriDSType == esriDatasetType.esriDTFeatureClass) //找到要素类
                    {
                        IFeatureClass ipFtClass = (IFeatureClass)pDs;
                        IFeatureLayer pFeatureLayer = new FeatureLayer();
                        pFeatureLayer.FeatureClass = ipFtClass;
                        pFeatureLayer.Name = ipFtClass.AliasName;
                        arrayFtInFWS.Add(pFeatureLayer);
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(ipFtClass);
                        pDs = pEnumDs.Next();
                    }
                    else if (esriDSType == esriDatasetType.esriDTFeatureDataset) //找到要素集)
                    {
                        IFeatureDataset pFtDs = (IFeatureDataset)pDs;
                        //GetFcNameInDs(pFtDs, ref arrayFtInFWS); //获取IFeatureDataset中的所有featureclass
                        //利用IFeatureClassContainer对象遍历IFeatureDataset
                        IFeatureClassContainer m_FeatureClassContainer = (IFeatureClassContainer)pFtDs;
                        IEnumFeatureClass m_EnumFC = m_FeatureClassContainer.Classes;
                        IFeatureClass m_FeatureClass = m_EnumFC.Next();
                        while (m_FeatureClass != null)
                        {
                            IFeatureLayer m_FeatureLayer = new FeatureLayerClass();
                            m_FeatureLayer.FeatureClass = m_FeatureClass;
                            arrayFtInFWS.Add(m_FeatureLayer);
                            m_FeatureClass = m_EnumFC.Next();
                        }
                        pDs = pEnumDs.Next();
                    }
                }
                //IFeatureLayer pFLayer = new FeatureLayerClass();
                //pFLayer.FeatureClass = pFeatureClass;
                //pFLayer.Name = pFeatureClass.AliasName;
                //ILayer pLayer = pFLayer as ILayer;
                IMap pMap = axMapControl1.Map;
                //pMap.AddLayer(pLayer);                
                for (int i = 0; i < arrayFtInFWS.Count; i++)
                {
                    ILayer pLayer = arrayFtInFWS[i] as ILayer;
                    pMap.AddLayer(pLayer);
                }
                axMapControl1.ActiveView.Refresh();
                MessageBox.Show(axMapControl1.Map.LayerCount.ToString());
            }
        }

        IMap pMap;
        IActiveView pActiveView;

        public ILayer GetLyr(string lyrName)
        {
            ILayer lyr = null;
            for (int i = 0; i < this.axMapControl1.LayerCount; i++)
            {
                if (this.axMapControl1.get_Layer(i).Name == lyrName)
                {
                    lyr = this.axMapControl1.get_Layer(i);
                    break;
                }
            }
            return lyr;
        }

        private void 认识查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ILayer Lyr = GetLyr("townshp");
            IFeatureLayer pFeatureLayer = Lyr as IFeatureLayer;
            ESRI.ArcGIS.Geodatabase.IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;

            IQueryFilter pQueryFilter = new QueryFilter();//实例化一个查询条件对象   
            pQueryFilter.WhereClause = " CON_ID=18 ";//将查询条件赋值           
            IFeatureCursor pFeatureCursor = pFeatureClass.Search(pQueryFilter, false);
            IFeature pFeature = pFeatureCursor.NextFeature();
            //Map.ClearSelection();//清除地图的选择
            int num = 0;
            //IFields pFlds = pFeature.Fields;
            //int iType = pFlds.FindField("Type");
            while (pFeature != null)
            {

                pFeature = pFeatureCursor.NextFeature();
                num++;
            }
            MessageBox.Show("查询元素统计：" + num.ToString());
        }

        //利用QueryFilter属性查询
        private void 属性查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ILayer Lyr = GetLyr("townshp");
            IFeatureLayer pFeatureLayer = Lyr as IFeatureLayer;
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;

            IQueryFilter pQueryFilter = new QueryFilter();//实例化一个查询条件对象   
            pQueryFilter.WhereClause = " CON_ID=18";//将查询条件赋值           
            ESRI.ArcGIS.Carto.IFeatureSelection pFeatureSelection = pFeatureLayer as IFeatureSelection;
            pFeatureSelection.SelectFeatures(pQueryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
        }

        //利用SpatialFilterClass查询
        private void 空间查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ILayer Lyr = GetLyr("townshp");
            IFeatureLayer pFeatureLayer = Lyr as IFeatureLayer;
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;

            ISpatialFilter pFilter = new SpatialFilterClass();//设置空间过滤器的三个必须属性

            pFilter.Geometry = GetGeo(); //要素查询工具
            pFilter.GeometryField = "Shape";
            pFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;//设置过滤器的属性限制

            pFilter.WhereClause = "CON_ID=15";

            IFeatureSelection pFeatureSelection = pFeatureLayer as IFeatureSelection;
            pFeatureSelection.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, false);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
        }

        //获得shp图层的某一个图元
        public ESRI.ArcGIS.Geometry.IGeometry GetGeo()
        {
            ESRI.ArcGIS.Geometry.IGeometry geo;
            ILayer Lyr = GetLyr("wayshp");
            IFeatureLayer pFeatureLayer = Lyr as IFeatureLayer;
            IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
            IFeature pFeature = pFeatureClass.GetFeature(124);
            geo = pFeature.Shape;
            return geo;
        }

        //清除选择集
        private void 清空选择ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            pMap.ClearSelection();
            this.axMapControl1.Refresh();
        }

    }
}
