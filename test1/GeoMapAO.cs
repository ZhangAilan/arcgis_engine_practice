using System;
using System.Collections.Generic;
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
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;

namespace test1
{
    class GeoMapAO : IAddGeoData, IGeoDataOper
    {
        //implement map control interface
        AxMapControl axMapControl1;
        public AxMapControl AxMapControl1
        {
            get { return axMapControl1; }
            set { axMapControl1 = value; }
        }

        AxMapControl axMapControl2;
        public AxMapControl AxMapControl2
        {
            get { return axMapControl2; }
            set { axMapControl2 = value; }
        }

        AxPageLayoutControl axPageLayoutControl1;
        public AxPageLayoutControl AxPageLayoutControl1
        {
            get { return axPageLayoutControl1; }
            set { axPageLayoutControl1 = value; }
        }

        //define the method that implements getting RGB colors
        public IRgbColor GetRGB(int r, int g, int b)
        {
            IRgbColor pColor = new RgbColorClass();
            pColor.Red = r;
            pColor.Green = g;
            pColor.Blue = b;
            return pColor;
        }

        //implement map loading interface
        string[] strFileName;  //save user selected geographic data file name
        public string[] StrFileName
        {
            get { return strFileName; }
            set { strFileName = value; }
        }

        //define the method to load the map
        //OpenShp
        public void AddGeoMap()
        {
            for (int i = 0; i < strFileName.Length; i++)
            {
                string strExt = System.IO.Path.GetExtension(strFileName[i]);
                switch (strExt)  //determine the file type and load the file in different ways
                {
                    case ".shp":  //vector data format
                        {
                            //the user select *shp file
                            string strPath = System.IO.Path.GetDirectoryName(strFileName[i]);
                            string strFile = System.IO.Path.GetFileNameWithoutExtension(strFileName[i]);

                            //load a map to the control
                            AxMapControl1.AddShapeFile(strPath, strFile);
                            AxMapControl2.ClearLayers();
                            AxMapControl2.AddShapeFile(strPath, strFile);
                            AxMapControl2.Extent = axMapControl2.FullExtent;  //full screen to display
                            break;
                        }
                    case ".bmp":
                    case ".tif":
                    case ".jpg":
                    case ".img":
                        {
                            IRasterLayer pRasterLayer = new RasterLayerClass();
                            string pathName = System.IO.Path.GetDirectoryName(strFileName[i]);
                            string fileName = System.IO.Path.GetFileName(strFileName[i]);
                            IWorkspaceFactory pWSF = new RasterWorkspaceFactoryClass();
                            IWorkspace pWS = pWSF.OpenFromFile(pathName, 0);
                            IRasterWorkspace pRWS = pWS as IRasterWorkspace;
                            IRasterDataset pRasterDataset = pRWS.OpenRasterDataset(fileName);
                            //Image pyramid judgment and creation
                            IRasterPyramid pRasPyrmid = pRasterDataset as IRasterPyramid;
                            if (pRasPyrmid != null)
                            {
                                if (!(pRasPyrmid.Present))
                                {
                                    pRasPyrmid.Create();  //Indicate in the progress bar that the pyramid is being created
                                }
                            }
                            IRaster pRaster = pRasterDataset.CreateDefaultRaster();
                            pRasterLayer.CreateFromRaster(pRaster);
                            ILayer pLayer = pRasterLayer as ILayer;
                            //Adds an image to the master view
                            AxMapControl1.AddLayer(pLayer, 0);
                            AxMapControl2.ClearLayers();
                            AxMapControl2.AddLayer(pLayer, 0);
                            AxMapControl2.Extent = axMapControl2.FullExtent;
                            break;
                        }
                    case ".dwg":
                        {
                            string strFilePath = System.IO.Path.GetDirectoryName(strFileName[i]);
                            string strSeleFileName = System.IO.Path.GetFileName(strFileName[i]);
                            AddCADFeatures(strFilePath, strSeleFileName);
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        //load the .dwg CAD file
        private void AddCADFeatures(string strPath, string strCAD)
        {
            IWorkspaceFactory pCADWorkspacefactory = new CadWorkspaceFactoryClass();
            IFeatureWorkspace pFeatureWorkspace;
            pFeatureWorkspace = pCADWorkspacefactory.OpenFromFile(strPath, 0) as IFeatureWorkspace;
            //open an feature dataset
            IFeatureDataset pFeatDataset = pFeatureWorkspace.OpenFeatureDataset(strCAD);
            //pFeatClassContainer can manage each element in the pFeatureDataset
            IFeatureClassContainer pFeatClassContainer = pFeatDataset as IFeatureClassContainer;
            IFeatureClass pFeatureClass;
            IFeatureLayer pFeatureLayer;
            //loop the CAD dataset
            for (int i = 0; i < pFeatClassContainer.ClassCount - 1; i++)
            {
                pFeatureClass = pFeatClassContainer.get_Class(i);
                if (pFeatureClass.FeatureType == esriFeatureType.esriFTCoverageAnnotation)
                {
                    //label the type, the annotation layer must be set to unitized
                    pFeatureLayer = new CadAnnotationLayerClass();
                }
                else
                {
                    pFeatureLayer = new FeatureLayerClass();
                }
                pFeatureLayer.Name = pFeatureClass.AliasName;
                pFeatureLayer.FeatureClass = pFeatureClass;
                AxMapControl1.AddLayer(pFeatureLayer, 0);
                //halk eye view
                AxMapControl2.ClearLayers();
                AxMapControl2.AddLayer(pFeatureLayer, 0);
                AxMapControl2.Extent = axMapControl2.FullExtent;
            }
        }

        public void AddTINDataset()
        {
            FolderBrowserDialog openFolder = new FolderBrowserDialog();
            if (openFolder.ShowDialog() == DialogResult.OK)
            {
                string strFullPath = openFolder.SelectedPath;
                string strPath=System.IO.Path.GetDirectoryName(strFullPath);
                string strTin = System.IO.Path.GetFileName(strFullPath);
                IWorkspaceFactory pTinWorkspaceFactory = new TinWorkspaceFactoryClass();
                IWorkspace pWorkspace = pTinWorkspaceFactory.OpenFromFile(strPath, 0);
                ITinWorkspace pTinWorkspace = pWorkspace as ITinWorkspace;
                ITin pTin = pTinWorkspace.OpenTin(strTin);
                ITinLayer pTinLayer = new TinLayerClass();
                pTinLayer.Dataset = pTin;
                AxMapControl1.AddLayer(pTinLayer as ILayer, 0);
            }
        }

        public void OperateMapDoc()
        {
            OpenFileDialog OpenFileDlg = new OpenFileDialog();
            SaveFileDialog SaveFileDlg = new SaveFileDialog();
            OpenFileDlg.Filter = "Map Doc File(*.mxd)|*.mxd";
            SaveFileDlg.Filter = "Map Doc File(*.mxd)|*.mxd";
            string strDocFileN = string.Empty;
            IMapDocument pMapDocument = new MapDocumentClass();

            switch (StrOperType)
            {
                case "NewDoc":
                    {
                        SaveFileDlg.Title = "Choose the map document!";
                        SaveFileDlg.ShowDialog();
                        strDocFileN = SaveFileDlg.FileName;
                        if (strDocFileN == string.Empty)
                            return;
                        pMapDocument.New(strDocFileN);
                        pMapDocument.Open(strDocFileN, "");
                        AxMapControl1.Map = pMapDocument.get_Map(0);
                        break;
                    }
                case "OpenDoc":
                    {
                        OpenFileDlg.Title = "Choose the map document!";
                        OpenFileDlg.ShowDialog();
                        strDocFileN = OpenFileDlg.FileName;
                        if (strDocFileN == string.Empty)
                            return;
                        //Load the data into te pMapDocument and associate it with the map control
                        pMapDocument.Open(strDocFileN, "");
                        for (int i = 0; i < pMapDocument.MapCount; i++)
                        {
                            AxMapControl1.Map = pMapDocument.get_Map(i); //loop all the possible map objects
                        }
                        AxMapControl1.Refresh();
                        break;
                    }
                case "SaveDoc":
                    {
                        //Determine whether the document is read-only
                        if (pMapDocument.get_IsReadOnly(pMapDocument.DocumentFilename) == true)
                        {
                            MessageBox.Show("This map document is read only", "Warning!");
                            return;
                        }
                        //save with the relative path
                        pMapDocument.Save(pMapDocument.UsesRelativePaths, true);
                        MessageBox.Show("Save Successfully!", "Info");
                        break;
                    }
                case "SaveDocAs":
                    {
                        SaveFileDlg.Title = "Save the map file with new path.";
                        SaveFileDlg.ShowDialog();
                        strDocFileN = SaveFileDlg.FileName;
                        if (strDocFileN == string.Empty)
                            return;
                        if (strDocFileN == pMapDocument.DocumentFilename)
                        {
                            //Save the modified map document in the original file
                            //Save with the relative path
                            pMapDocument.Save(pMapDocument.UsesRelativePaths, true);
                            MessageBox.Show("Save successfully!", "Info");
                            break;
                        }
                        else
                        {
                            //Svae the modified map document in the new file
                            pMapDocument.SaveAs(strDocFileN, true, true);
                            MessageBox.Show("Save successfully!", "Info");
                            break;
                        }
                    }
                default:
                    break;
            }
        }



        //the interface of mouse and map interaction
        string strOperType;  //define map operation types
        public string StrOperType
        {
            get { return strOperType; }
            set { strOperType = value; }
        }

        //define a variable for the mouse press event
        IMapControlEvents2_OnMouseDownEvent e;
        public IMapControlEvents2_OnMouseDownEvent E
        {
            get { return e; }
            set { e = value; }
        }

        //define how the mouse interacts with the maps
        public void OperMap()
        {
            switch (strOperType)
            {
                case "LKZoomIn":
                    {
                        axMapControl1.Extent = axMapControl1.TrackRectangle();
                        axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                    }
                    break;
                default:
                    break;
            }
        }

    }
}
