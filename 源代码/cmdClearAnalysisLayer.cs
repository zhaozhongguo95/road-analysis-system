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


// This command deletes all the network locations and analysis results from the selected NALayer.

namespace NAEngine
{
	[Guid("773CCD44-C46A-42eb-A1B2-E00C7B765783")]
	[ClassInterface(ClassInterfaceType.None)]
	[ProgId("NAEngine.ClearAnalysisLayer")]
	public sealed class cmdClearAnalysisLayer : BaseCommand
	{
		private IMapControl3 m_mapControl;

		public cmdClearAnalysisLayer()
		{
			base.m_caption = "Clear Analysis Layer";
		}

		public override void OnClick()
		{
			IEngineNetworkAnalystEnvironment naEnv = new EngineNetworkAnalystEnvironmentClass();
			IEngineNetworkAnalystHelper naHelper = naEnv as IEngineNetworkAnalystHelper;
			IEngineNAWindow naWindow = naEnv.NAWindow;

			// Get the NALayer and corresponding NAContext of the layer that
			// was right-clicked on in the table of contents
			// m_MapControl.CustomProperty was set in frmMain.axTOCControl1_OnMouseDown
			INALayer naLayer = (INALayer)m_mapControl.CustomProperty;
			INAContext naContext = naLayer.Context;

			// Set the active Analysis layer
			if (naWindow.ActiveAnalysis != naLayer)
				naWindow.ActiveAnalysis = naLayer;

			// Remember what the current category is
			IEngineNAWindowCategory currentCategory = naWindow.ActiveCategory;

			// Loop through deleting all the items from all the categories
			INamedSet naClasses = naContext.NAClasses;
			for (int i = 0; i < naClasses.Count; i++)
			{
				IEngineNAWindowCategory category = naWindow.get_CategoryByNAClassName(naClasses.get_Name(i));
				naWindow.ActiveCategory = category;
				naHelper.DeleteAllNetworkLocations();
			}

			//Reset to the original category
			naWindow.ActiveCategory = currentCategory;

			m_mapControl.Refresh(esriViewDrawPhase.esriViewGeography, naLayer, m_mapControl.Extent);
		}

		public override void OnCreate(object hook)
		{
			m_mapControl = (IMapControl3)hook;
		}
	}
}
