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
    class GeoMapAO : IAddGeoData, IGeoDataOper,ILaySequAttr
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
        //load the shp file
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

        //load the TIN dataset
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

        //load the mapdocument
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
            IMap pMap = axMapControl1.Map;
            IActiveView pActiveView = pMap as IActiveView;
            
            //determine the type of map operation
            IEnvelope pEnv;
            switch (strOperType)
            {
                case "LKZoomIn":  //frame enlargement
                    {
                        pEnv = axMapControl1.TrackRectangle();
                        pActiveView.Extent = pEnv;
                        pActiveView.Refresh();
                        break;
                    }
                case "GeoMapLkShow":  //pull-frame display
                    {
                        axMapControl1.MousePointer = esriControlsMousePointer.esriPointerCrosshair;
                        axMapControl1.Extent = axMapControl1.TrackRectangle();
                        axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                        break;
                    }
                case "Movemap":
                    {
                        axMapControl1.Pan();
                        break;
                    }
                case "DrawPoint":
                    {
                        //new point object
                        IPoint pPt = new PointClass();
                        pPt.PutCoords(e.mapX, e.mapY);

                        //produce a marker element
                        IMarkerElement pMarkerElement = new MarkerElementClass();

                        //produce a symbol that modifies the Marker element
                        ISimpleMarkerSymbol pMarkerSymbol = new SimpleMarkerSymbolClass();
                        pMarkerSymbol.Color = GetRGB(220, 120, 60);
                        pMarkerSymbol.Size = 2;
                        pMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSDiamond;
                        IElement pElement = pMarkerElement as IElement;

                        //get the Element's interface object, which is used to set the element's Geometry
                        pElement.Geometry = pPt;
                        pMarkerElement.Symbol = pMarkerSymbol;
                        IGraphicsContainer pGraphicsContainer = pMap as IGraphicsContainer;

                        //add the element to the Map
                        pGraphicsContainer.AddElement(pMarkerElement as IElement, 0);
                        pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                        break;
                    }
                case "DrawLine":
                    {
                        IPolyline pPolyline = axMapControl1.TrackLine() as IPolyline;
                        //produce a SimplelineSymbol symbol
                        ISimpleLineSymbol pSimpleLineSym = new SimpleLineSymbolClass();

                        //require user dynamic selection
                        pSimpleLineSym.Style = esriSimpleLineStyle.esriSLSSolid;
                        pSimpleLineSym.Color = GetRGB(120, 200, 180);
                        pSimpleLineSym.Width = 1;

                        //produce a PolyLineElement object
                        ILineElement pLineEle = new LineElementClass();
                        IElement pEle = pLineEle as IElement;
                        pEle.Geometry = pPolyline;

                        //add the elements to the Map objects
                        IGraphicsContainer pGraphicsContainer = pMap as IGraphicsContainer;
                        pGraphicsContainer.AddElement(pEle, 0);
                        pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                        break;
                    }
                case "DrawPolygon":
                    {
                        IPolygon pPolygon = axMapControl1.TrackPolygon() as IPolygon;
                        //produce a SimpleFillSymbol symbol
                        ISimpleFillSymbol pSimpleFillSym = new SimpleFillSymbolClass();
                        pSimpleFillSym.Style = esriSimpleFillStyle.esriSFSDiagonalCross;
                        pSimpleFillSym.Color = GetRGB(220, 112, 60);

                        //produce a PolygonElement object
                        IFillShapeElement pPolygonEle = new PolygonElementClass();
                        pPolygonEle.Symbol = pSimpleFillSym;
                        IElement pEle = pPolygonEle as IElement;
                        pEle.Geometry = pPolygon;

                        //add the element to the Map object
                        IGraphicsContainer pGraphicsContainer = pMap as IGraphicsContainer;
                        pGraphicsContainer.AddElement(pEle, 0);
                        pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                        break;
                    }
                case "LabelMap":
                    {
                        //produce the text object, and set the corresponding attribute
                        ITextElement pTextEle = new TextElementClass();
                        pTextEle.Text = "Nanjing Tech University";
                        IElement pEles = pTextEle as IElement;

                        //sets the geometry properties of text characters
                        IPoint pPoint = new PointClass();
                        pPoint.PutCoords(e.mapX, e.mapY);
                        pEles.Geometry = pPoint;

                        //add to the Map object, and refresh to display
                        IGraphicsContainer pGraphicsContainer = pMap as IGraphicsContainer;
                        pGraphicsContainer.AddElement(pEles, 0);
                        pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

                        //the method to set the color
                        //to do...

                        break;
                    }
                default:
                    break;
            }
        }


        //drag the map layer up and down
        ILayer pMovelayer;
        int toIndex;
        AxTOCControl axTOCControl1;
        public AxTOCControl AxTOCControl1
        {
            get { return axTOCControl1; }
            set { axTOCControl1 = value; }
        }

        ITOCControl mTOCControl;
        public ITOCControl MTOCControl
        {
            get { return mTOCControl; }
            set { mTOCControl = value; }
        }

        ITOCControlEvents_OnMouseDownEvent ted;
        public ITOCControlEvents_OnMouseDownEvent Ted
        {
            get { return ted; }
            set { ted = value; }
        }

        ITOCControlEvents_OnMouseUpEvent teu;
        public ITOCControlEvents_OnMouseUpEvent Teu
        {
            get { return teu; }
            set { teu = value; }
        }

        public void AdjLayMd()
        {
            esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
            if (ted.button == 1)  //mouse left key down
            {
                IBasicMap map = null;
                ILayer layer = null;
                object other = null;
                object index = null;
                mTOCControl.HitTest(ted.x, ted.y, ref item, ref map, ref layer, ref other, ref index);
                if (item == esriTOCControlItem.esriTOCControlItemLayer)
                {
                    if (layer is IAnnotationSublayer)
                        return;
                    else
                    {
                        pMovelayer = layer;
                    }
                }
            }
            else if (ted.button == 2)  //mouse right key down
            {
                if (axMapControl1.LayerCount > 0)  //main view has the geo data
                {
                    esriTOCControlItem mItem = new esriTOCControlItem();
                    IBasicMap pMap = new MapClass();
                    ILayer pLayer = new FeatureLayerClass();
                    object pOther = new object();
                    object pIndex = new object();
                    axTOCControl1.HitTest(ted.x, ted.y, ref mItem, ref pMap, ref pLayer, ref pOther, ref pIndex);
                }
            }
        }

        public void AdjLayMu()
        {
            if (teu.button == 1)
            {
                esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap map = null;
                ILayer layer = null;
                object other = null;
                object index = null;
                mTOCControl.HitTest(teu.x, teu.y, ref item, ref map, ref layer, ref other, ref index);
                IMap pMap = axMapControl1.ActiveView.FocusMap;
                if (item == esriTOCControlItem.esriTOCControlItemLayer || layer != null)
                {
                    if (pMovelayer != layer)
                    {
                        ILayer pTempLayer;
                        for (int i = 0; i < pMap.LayerCount; i++)
                        {
                            pTempLayer = pMap.get_Layer(i);
                            if (pTempLayer == layer)
                                toIndex = i;  //access the index number where mouse down position
                        }
                        pMap.MoveLayer(pMovelayer, toIndex);  //move the raw layer to the target layer position
                        axMapControl1.ActiveView.Refresh();
                        mTOCControl.Update();
                    }
                }
            }
        }
    }
}
