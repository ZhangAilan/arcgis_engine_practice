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

        private void newDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IGeoDataOper pGeoMapOp = new GeoMapAO();
            pGeoMapOp.StrOperType = "NewDoc";
            pGeoMapOp.AxMapControl1 = axMapControl1;
            pGeoMapOp.AxMapControl2 = axMapControl2;
            pGeoMapOp.OperateMapDoc();
        }

        private void openDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IGeoDataOper pGeoMapOp = new GeoMapAO();
            pGeoMapOp.StrOperType = "OpenDoc";
            pGeoMapOp.AxMapControl1 = axMapControl1;
            pGeoMapOp.AxMapControl2 = axMapControl2;
            pGeoMapOp.OperateMapDoc();
        }

        private void saveDocToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IGeoDataOper pGeoMapOp = new GeoMapAO();
            pGeoMapOp.StrOperType = "SaveDoc";
            pGeoMapOp.AxMapControl1 = axMapControl1;
            pGeoMapOp.AxMapControl2 = axMapControl2;
            pGeoMapOp.OperateMapDoc();
        }

        private void saveDocAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IGeoDataOper pGeoMapOp = new GeoMapAO();
            pGeoMapOp.StrOperType = "SaveDocAs";
            pGeoMapOp.AxMapControl1 = axMapControl1;
            pGeoMapOp.AxMapControl2 = axMapControl2;
            pGeoMapOp.OperateMapDoc();
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
        private void axTOCControl1_OnMouseUp(object sender, ITOCControlEvents_OnMouseUpEvent e)
        {
            AdjLay.AxMapControl1 = axMapControl1;
            AdjLay.AxTOCControl1 = axTOCControl1;
            //adjust the order of the layer display
            AdjLay.Teu = e;
            AdjLay.AdjLayMu();
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


    }
}
