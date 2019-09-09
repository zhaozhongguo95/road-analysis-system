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


// This command brings up the property pages for the Network Analyst environment.

namespace NAEngine
{
	[Guid("7E98FE97-DA7A-4069-BC85-091D75B1AF65")]
	[ClassInterface(ClassInterfaceType.None)]
	[ProgId("NAEngine.NAProperties")]
	public sealed class cmdNAProperties : BaseCommand
	{
		private IMapControl3 m_mapControl;

		public cmdNAProperties()
		{
			base.m_caption = "Properties...";
		}

		public override void OnClick()
		{
			// Get the network analyst environment
			IEngineNetworkAnalystEnvironment naEnv = new EngineNetworkAnalystEnvironmentClass();

			// Show the Property Page form for Network Analyst
			frmNAProperties props = new frmNAProperties();
			props.ShowModal(naEnv);
		}

		public override void OnCreate(object hook)
		{
			//m_mapControl = (IMapControl3)hook;
		}
	}
}
