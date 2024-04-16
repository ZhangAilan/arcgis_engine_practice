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
    interface IGeoDataOper : IComControl
    {
        //types of map operations
        string StrOperType { get; set; }

        //mouse-down event parameters
        IMapControlEvents2_OnMouseDownEvent E { get; set; }

        //Implement map interactive operation
        void OperMap();  

        //Implement map document operation
        void OperateMapDoc();
    }
}
