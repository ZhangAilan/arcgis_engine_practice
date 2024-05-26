using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;


namespace test1
{
    public partial class Form1 : Form
    {
        string GeoOpType = string.Empty;

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


    }
}
