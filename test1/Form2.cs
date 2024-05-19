using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;

namespace test1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private string m_tool = "no";
        
        private void button4_Click(object sender, EventArgs e)
        {
            //在地图上动态地添加一个表示地图中心点的标记元素，并显示一个消息框来确认中心点的坐标
            IMap pMap = this.axMapControl1.Map;
            IActiveView pActiveView = this.axMapControl1.ActiveView;
            IGraphicsContainer pGraphicsContainer = this.axMapControl1.Map as IGraphicsContainer;

            double xMax = pActiveView.Extent.XMax;
            double xMin = pActiveView.Extent.XMin;
            double yMax = pActiveView.Extent.XMax;
            double yMin = pActiveView.Extent.YMin;
            double xCenter = xMin + (xMax - xMin) / 2;
            double yCenter = yMin + (yMax - yMin) / 2;

            IPoint pt = new ESRI.ArcGIS.Geometry.PointClass();
            pt.X = xCenter;
            pt.Y = yCenter;

            IMarkerElement pMarkerElement;
            pMarkerElement = new MarkerElementClass();
            IElement pElement;
            pElement = pMarkerElement as IElement;
            pElement.Geometry = pt;
            pGraphicsContainer.AddElement((IElement)pMarkerElement, 0);
            this.axMapControl1.Refresh();
            MessageBox.Show("x=" + xCenter.ToString() + ",y=" + yCenter.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_tool = "point";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_tool = "polyline";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            m_tool = "polygon";
        }

        private void axMapControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            IMap pMap = this.axMapControl1.Map;
            IActiveView pActiveView = this.axMapControl1.ActiveView;
            IGraphicsContainer pGraphicsContainer = this.axMapControl1.Map as IGraphicsContainer;


            if (m_tool == "point") //实现绘制点状元素
            {
                IPoint pt;
                pt = axMapControl1.ToMapPoint(e.x, e.y);
                IMarkerElement pMarkerElement;
                pMarkerElement = new MarkerElementClass();
                IElement pElement;
                pElement = pMarkerElement as IElement;
                pElement.Geometry = pt;
                pGraphicsContainer.AddElement((IElement)pMarkerElement, 0);
                this.axMapControl1.Refresh();
            }

            else if (m_tool == "polyline")  //实现绘制线状元素  
            {
                IGeometry polyline;
                polyline = axMapControl1.TrackLine();
                ILineElement pLineElement; pLineElement = new LineElementClass();
                IElement pElement;
                pElement = pLineElement as IElement;
                pElement.Geometry = polyline;
                pGraphicsContainer.AddElement((IElement)pLineElement, 0);
                pActiveView.Refresh();
            }
            else if (m_tool == "polygon")
            {
                IPolygon pPolygion = axMapControl1.TrackPolygon() as IPolygon;
                //产生一个 SimpleFillSymbol 符号
                ISimpleFillSymbol pSimpleFillSym = new SimpleFillSymbolClass();
                pSimpleFillSym.Style = esriSimpleFillStyle.esriSFSDiagonalCross;
                //产生一个 PolygonElement 对象
                IFillShapeElement pPolygonEle = new PolygonElementClass();
                pPolygonEle.Symbol = pSimpleFillSym;
                IElement pEle = pPolygonEle as IElement;
                pEle.Geometry = pPolygion;
                //将元素添加到Map对象之中
                //IGraphicsContainer pGraphicsContainer = pMap as IGraphicsContainer;
                pGraphicsContainer.AddElement(pEle, 0);
                pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            }
        }
    }
}
