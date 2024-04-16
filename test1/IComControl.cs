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
    //define the interface of setting control
    interface IComControl
    {
        //main view control
        AxMapControl AxMapControl1 { get; set; }

        //Hawk-eye view
        AxMapControl AxMapControl2 { get; set; }

        //Layout view control
        AxPageLayoutControl AxPageLayoutControl1 { get; set; }

        //define a way to set colors
        IRgbColor GetRGB(int r, int g, int b);
    }
}
