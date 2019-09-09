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
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.Controls;


// This command brings up the property pages for the NALayer.

namespace NAEngine
{
	[Guid("04B67C95-96DD-4afe-AF62-942255ACBA71")]
	[ClassInterface(ClassInterfaceType.None)]
	[ProgId("NAEngine.NALayerProperties")]
	public sealed class cmdNALayerProperties : BaseCommand
	{
		private IMapControl3 m_mapControl;

		public cmdNALayerProperties()
		{
			base.m_caption = "Properties...";
		}

		public override void OnClick()
		{
			// Show the Property Page form for the NALayer

			// Get the NALayer that was right-clicked on in the table of contents
			// m_MapControl.CustomProperty was set in frmMain.axTOCControl1_OnMouseDown
			INALayer naLayer = (INALayer)m_mapControl.CustomProperty;
			frmNALayerProperties props = new frmNALayerProperties();
			if (props.ShowModal(naLayer))
			{
				// Notify the ActiveView that the contents have changed so the TOC and NAWindow know to refresh themselves.
				m_mapControl.ActiveView.ContentsChanged();
			}
		}

		public override void OnCreate(object hook)
		{
			m_mapControl = (IMapControl3)hook;
		}
	}
}
