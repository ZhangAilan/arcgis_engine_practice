using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.esriSystem;

namespace test1
{
    interface ILaySequAttr : IComControl
    {
        AxTOCControl AxTOCControl1 { get; set; }
        ITOCControl MTOCControl { get; set; }
        ITOCControlEvents_OnMouseDownEvent Ted { get; set; }
        ITOCControlEvents_OnMouseUpEvent Teu { get; set; }

        void AdjLayMd();  //Mouse down event
        void AdjLayMu();  //Mouse up event
    }
}
