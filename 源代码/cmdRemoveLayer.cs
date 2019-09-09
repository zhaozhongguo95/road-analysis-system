// Copyright 2010 ESRI
// 
// All rights reserved under the copyright laws of the United States
// and applicable international laws, treaties, and conventions.
// 
// You may freely redistribute and use this sample code, with or
// without modification, provided you include the original copyright
// notice and use restrictions.
// 
// See the use restrictions at http://help.arcgis.com/en/sdk/10.0/usageRestrictions.htm
// 

using System.Windows.Forms;
using System.Runtime.InteropServices;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;

// This command removes the selected layer from the map

namespace NAEngine
{
	[Guid("53399A29-2B65-48d5-930F-804B88B85A34")]
	[ClassInterface(ClassInterfaceType.None)]
	[ProgId("NAEngine.RemoveLayer")]
	public sealed class cmdRemoveLayer : BaseCommand
	{
		private IMapControl3 m_mapControl;

		public cmdRemoveLayer()
		{
			base.m_caption = "Remove Layer";
		}

		public override void OnClick()
		{
			// Get the NALayer that was right-clicked on in the table of contents
			// m_MapControl.CustomProperty was set in frmMain.axTOCControl1_OnMouseDown
			ILayer layer = (ILayer)m_mapControl.CustomProperty;
			m_mapControl.Map.DeleteLayer(layer);
			m_mapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, layer.AreaOfInterest);
		}

		public override void OnCreate(object hook)
		{
			m_mapControl = (IMapControl3)hook;
		}
	}
}
