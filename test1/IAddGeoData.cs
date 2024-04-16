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
    //define the interface that manages the loading of geographic data
    interface IAddGeoData : IComControl
    {
        //store the geographic data file selected by the user
        string[] StrFileName { get; set; }

        //the method of loading the geographic data
        void AddGeoMap();

        //the method of loading the tin dataset
        void AddTINDataset();
    }
}
