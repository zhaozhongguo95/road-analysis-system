

using System;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.NetworkAnalyst;
using ESRI.ArcGIS.Geodatabase;


// This is the main form of the application.

namespace NAEngine
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Splitter splitter1;

		// Context menu objects for NAWindow's context menu
		private System.Windows.Forms.ContextMenu contextMenu1;
		private System.Windows.Forms.MenuItem miLoadLocations;
		private System.Windows.Forms.MenuItem miClearLocations;
		private System.Windows.Forms.MenuItem miAddItem;

		// ArcGIS Controls on the form
		private ESRI.ArcGIS.Controls.AxMapControl axMapControl1;
		private ESRI.ArcGIS.Controls.AxLicenseControl axLicenseControl1;
		private ESRI.ArcGIS.Controls.AxToolbarControl axToolbarControl1;
		private ESRI.ArcGIS.Controls.AxTOCControl axTOCControl1;

		// Listen for context menu on NAWindow
		private IEngineNAWindowEventsEx_OnContextMenuEventHandler m_onContextMenu;

		// Reference to Network Analyst Environment
		private IEngineNetworkAnalystEnvironment m_naEnv;

		// Reference to NAWindow.  Need to hold on to reference for events to work.
		private IEngineNAWindow m_naWindow;

		// Menu for our commands on the TOC context menu
		private IToolbarMenu m_menuLayer;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem �ļ�ToolStripMenuItem;
        private ToolStripMenuItem ToolStripMenuItemQueryByAttribute;
        private ToolStripMenuItem ToolStripMenuItemQueryBySpatial;
        private ToolStripMenuItem ToolStripMenuItemOpen;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusMessage;
        private ToolStripStatusLabel toolStripStatusBlank;
        private ToolStripStatusLabel toolStripStatusScale;
        private ToolStripStatusLabel toolStripStatusCoordinates;

		// incrementor for auto generated names
		private static int autogenInt = 0;

		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			ESRI.ArcGIS.ADF.COMSupport.AOUninitialize.Shutdown();

			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.axMapControl1 = new ESRI.ArcGIS.Controls.AxMapControl();
            this.axLicenseControl1 = new ESRI.ArcGIS.Controls.AxLicenseControl();
            this.axToolbarControl1 = new ESRI.ArcGIS.Controls.AxToolbarControl();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.axTOCControl1 = new ESRI.ArcGIS.Controls.AxTOCControl();
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();
            this.miLoadLocations = new System.Windows.Forms.MenuItem();
            this.miClearLocations = new System.Windows.Forms.MenuItem();
            this.miAddItem = new System.Windows.Forms.MenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.�ļ�ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemQueryByAttribute = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemQueryBySpatial = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusBlank = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusScale = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusCoordinates = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // axMapControl1
            // 
            this.axMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMapControl1.Location = new System.Drawing.Point(173, 53);
            this.axMapControl1.Name = "axMapControl1";
            this.axMapControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMapControl1.OcxState")));
            this.axMapControl1.Size = new System.Drawing.Size(706, 454);
            this.axMapControl1.TabIndex = 2;
            this.axMapControl1.OnMouseMove += new ESRI.ArcGIS.Controls.IMapControlEvents2_Ax_OnMouseMoveEventHandler(this.axMapControl1_OnMouseMove);
            // 
            // axLicenseControl1
            // 
            this.axLicenseControl1.Enabled = true;
            this.axLicenseControl1.Location = new System.Drawing.Point(797, 0);
            this.axLicenseControl1.Name = "axLicenseControl1";
            this.axLicenseControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axLicenseControl1.OcxState")));
            this.axLicenseControl1.Size = new System.Drawing.Size(32, 32);
            this.axLicenseControl1.TabIndex = 1;
            // 
            // axToolbarControl1
            // 
            this.axToolbarControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.axToolbarControl1.Location = new System.Drawing.Point(0, 25);
            this.axToolbarControl1.Name = "axToolbarControl1";
            this.axToolbarControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axToolbarControl1.OcxState")));
            this.axToolbarControl1.Size = new System.Drawing.Size(879, 28);
            this.axToolbarControl1.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(170, 53);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 454);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // axTOCControl1
            // 
            this.axTOCControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.axTOCControl1.Location = new System.Drawing.Point(0, 53);
            this.axTOCControl1.Name = "axTOCControl1";
            this.axTOCControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axTOCControl1.OcxState")));
            this.axTOCControl1.Size = new System.Drawing.Size(170, 454);
            this.axTOCControl1.TabIndex = 1;
            this.axTOCControl1.OnMouseDown += new ESRI.ArcGIS.Controls.ITOCControlEvents_Ax_OnMouseDownEventHandler(this.axTOCControl1_OnMouseDown);
            // 
            // contextMenu1
            // 
            this.contextMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miLoadLocations,
            this.miClearLocations});
            // 
            // miLoadLocations
            // 
            this.miLoadLocations.Index = 0;
            this.miLoadLocations.Text = "Load Locations...";
            this.miLoadLocations.Click += new System.EventHandler(this.miLoadLocations_Click);
            // 
            // miClearLocations
            // 
            this.miClearLocations.Index = 1;
            this.miClearLocations.Text = "Clear Locations";
            this.miClearLocations.Click += new System.EventHandler(this.miClearLocations_Click);
            // 
            // miAddItem
            // 
            this.miAddItem.Index = -1;
            this.miAddItem.Text = "Add Item";
            this.miAddItem.Click += new System.EventHandler(this.miAddItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.�ļ�ToolStripMenuItem,
            this.ToolStripMenuItemQueryByAttribute,
            this.ToolStripMenuItemQueryBySpatial});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(879, 25);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // �ļ�ToolStripMenuItem
            // 
            this.�ļ�ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemOpen});
            this.�ļ�ToolStripMenuItem.Name = "�ļ�ToolStripMenuItem";
            this.�ļ�ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.�ļ�ToolStripMenuItem.Text = "�ļ�";
            // 
            // ToolStripMenuItemOpen
            // 
            this.ToolStripMenuItemOpen.Name = "ToolStripMenuItemOpen";
            this.ToolStripMenuItemOpen.Size = new System.Drawing.Size(100, 22);
            this.ToolStripMenuItemOpen.Text = "��";
            this.ToolStripMenuItemOpen.Click += new System.EventHandler(this.ToolStripMenuItemOpen_Click);
            // 
            // ToolStripMenuItemQueryByAttribute
            // 
            this.ToolStripMenuItemQueryByAttribute.Name = "ToolStripMenuItemQueryByAttribute";
            this.ToolStripMenuItemQueryByAttribute.Size = new System.Drawing.Size(68, 21);
            this.ToolStripMenuItemQueryByAttribute.Text = "���Բ�ѯ";
            this.ToolStripMenuItemQueryByAttribute.Click += new System.EventHandler(this.ToolStripMenuItemQueryByAttribute_Click);
            // 
            // ToolStripMenuItemQueryBySpatial
            // 
            this.ToolStripMenuItemQueryBySpatial.Name = "ToolStripMenuItemQueryBySpatial";
            this.ToolStripMenuItemQueryBySpatial.Size = new System.Drawing.Size(68, 21);
            this.ToolStripMenuItemQueryBySpatial.Text = "�ռ��ѯ";
            this.ToolStripMenuItemQueryBySpatial.Click += new System.EventHandler(this.ToolStripMenuItemQueryBySpatial_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusMessage,
            this.toolStripStatusBlank,
            this.toolStripStatusScale,
            this.toolStripStatusCoordinates});
            this.statusStrip1.Location = new System.Drawing.Point(173, 485);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(706, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusMessage
            // 
            this.toolStripStatusMessage.Name = "toolStripStatusMessage";
            this.toolStripStatusMessage.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusMessage.Text = "����";
            // 
            // toolStripStatusBlank
            // 
            this.toolStripStatusBlank.Name = "toolStripStatusBlank";
            this.toolStripStatusBlank.Size = new System.Drawing.Size(535, 17);
            this.toolStripStatusBlank.Spring = true;
            // 
            // toolStripStatusScale
            // 
            this.toolStripStatusScale.Name = "toolStripStatusScale";
            this.toolStripStatusScale.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusScale.Text = "��ǰ����";
            // 
            // toolStripStatusCoordinates
            // 
            this.toolStripStatusCoordinates.Name = "toolStripStatusCoordinates";
            this.toolStripStatusCoordinates.Size = new System.Drawing.Size(68, 17);
            this.toolStripStatusCoordinates.Text = "��ǰ������";
            this.toolStripStatusCoordinates.Click += new System.EventHandler(this.toolStripStatusCoordinates_Click);
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(879, 507);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.axLicenseControl1);
            this.Controls.Add(this.axMapControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.axTOCControl1);
            this.Controls.Add(this.axToolbarControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Road analysis System";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.axMapControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axLicenseControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axToolbarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axTOCControl1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			if (!ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Engine))
			{
				if (!ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.Desktop))
				{
					if (ESRI.ArcGIS.RuntimeManager.ActiveRuntime.Version == "") // "" is less than 10
					{
						System.Windows.Forms.MessageBox.Show("Loading ArcGIS Version Failed");
						return;
					}
				}
			}

			Application.Run(new frmMain());
		}

		private void frmMain_Load(object sender, System.EventArgs e)
		{
			// Add commands to the NALayer context menu
                  // ��Nalayer�����Ĳ˵��������
			m_menuLayer = new ToolbarMenuClass();

			int nItem = -1;
			m_menuLayer.AddItem(new cmdLoadLocations(), -1, ++nItem, false, esriCommandStyles.esriCommandStyleTextOnly);
			m_menuLayer.AddItem(new cmdRemoveLayer(), -1, ++nItem, false, esriCommandStyles.esriCommandStyleTextOnly);
			m_menuLayer.AddItem(new cmdClearAnalysisLayer(), -1, ++nItem, true, esriCommandStyles.esriCommandStyleTextOnly);
			m_menuLayer.AddItem(new cmdNALayerProperties(), -1, ++nItem, true, esriCommandStyles.esriCommandStyleTextOnly);
			m_menuLayer.SetHook(axMapControl1);

			// Add command for Network Analyst env properties to end of "Network Analyst" dropdown menu
                  // ���������env���Ե�������ӵ����������ʦ�������˵���ĩβ
			nItem = -1;
			for (int i = 0; i < axToolbarControl1.Count; ++i)
			{
				IToolbarItem item = axToolbarControl1.GetItem(i);
				IToolbarMenu mnu = item.Menu;

				if (mnu == null)
					continue;

				IMenuDef mnudef = mnu.GetMenuDef();
				string name = mnudef.Name;
				if (name == "ControlToolsNetworkAnalyst_SolverMenu")
				{
					nItem = i;
					break;
				}
			}

			if (nItem >= 0)
			{
				IToolbarItem item = axToolbarControl1.GetItem(nItem);
				IToolbarMenu mnu = item.Menu;
				if (mnu != null)
					mnu.AddItem(new cmdNAProperties(), -1, mnu.Count, true, esriCommandStyles.esriCommandStyleTextOnly);
			}

			// Initialize naEnv variables
                  // ��ʼ��naEnv����
			m_naEnv = new EngineNetworkAnalystEnvironmentClass();
			m_naEnv.ZoomToResultAfterSolve = false;
			m_naEnv.ShowAnalysisMessagesAfterSolve = (int)(esriEngineNAMessageType.esriEngineNAMessageTypeInformative | esriEngineNAMessageType.esriEngineNAMessageTypeWarning);

			// Explicitly setup buddy control and initialize NA extension 
			// so we can get to NAWindow to listen to window events
			// This is necessary the various controls are not yet setup and they
			// need to be in order to get the NAWindow's events.
                  // ��ʽ���û��ؼ�����ʼ��na��չ���Ա����ǿ��Է���na window�����������¼���
                  // ���Ǳ���ģ����ֿؼ���δ���ã�������Ҫ���ڻ�ȡnawindow���¼���
			axToolbarControl1.SetBuddyControl(axMapControl1);
			IExtension ext = m_naEnv as IExtension;
			object obj = axToolbarControl1.Object;
			ext.Startup(ref obj);
			m_naWindow = m_naEnv.NAWindow;
			m_onContextMenu = new IEngineNAWindowEventsEx_OnContextMenuEventHandler(OnContextMenu);
			((IEngineNAWindowEventsEx_Event)m_naWindow).OnContextMenu += m_onContextMenu;
		}

		//  Show the TOC context menu when an NALayer is right-clicked on
		private void axTOCControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.ITOCControlEvents_OnMouseDownEvent e)
		{
			if (e.button != 2) return;

			esriTOCControlItem item = esriTOCControlItem.esriTOCControlItemNone;
			IBasicMap map = null;
			ILayer layer = null;
			object other = null;
			object index = null;

			//Determine what kind of item has been clicked on
			axTOCControl1.HitTest(e.x, e.y, ref item, ref map, ref layer, ref other, ref index);

			// Only implemented a context menu for NALayers.  Exit if the layer is anything else.
			if ((layer as INALayer) == null)
				return;

			axTOCControl1.SelectItem(layer);

			// Set the layer into the CustomProperty.
			// This is used by the other commands to know what layer was right-clicked on
			// in the table of contents.			
			axMapControl1.CustomProperty = layer;

			//Popup the correct context menu and update the TOC when it's done.
			if (item == esriTOCControlItem.esriTOCControlItemLayer)
			{
				m_menuLayer.PopupMenu(e.x, e.y, axTOCControl1.hWnd);
				ITOCControl toc = axTOCControl1.Object as ITOCControl;
				toc.Update();
			}
		}

		public bool OnContextMenu(int x, int y)
		{
			System.Drawing.Point pt = this.PointToClient(System.Windows.Forms.Cursor.Position);

			//Get the active category
			IEngineNAWindowCategory2 activeCategory = m_naWindow.ActiveCategory as IEngineNAWindowCategory2;
			if (activeCategory == null)
				return false;

			MenuItem separator = new MenuItem("-");

			miLoadLocations.Enabled = false;
			miClearLocations.Enabled = false;

			// in order for the AddItem choice to appear in the context menu, the class
			// should be an input class, and it should not be editable
			INAClassDefinition pNAClassDefinition = activeCategory.NAClass.ClassDefinition;
			if (pNAClassDefinition.IsInput)
			{

				miLoadLocations.Enabled = true;
				miClearLocations.Enabled = true;

				// canEditShape should be false for AddItem to Apply (default is false)
				// if it's a StandaloneTable canEditShape is implicitly false (there's no shape to edit)
				bool canEditShape = false;
				IFields pFields = pNAClassDefinition.Fields;
				int nField = -1;
				nField = pFields.FindField("Shape");
				if (nField >= 0)
				{
					int naFieldType = 0;
					naFieldType = pNAClassDefinition.get_FieldType("Shape");

					// determining whether or not the shape field can be edited consists of running a bitwise comparison
					// on the FieldType of the shape field.  See the online help for a list of the possible field types.
					// For our case, we want to verify that the shape field is an input field.  If it is an input field, 
					// then we do NOT want to display the Add Item menu option.
					canEditShape = ((naFieldType & (int)esriNAFieldType.esriNAFieldTypeInput) == (int)esriNAFieldType.esriNAFieldTypeInput) ? true : false;
				}

				if (!canEditShape)
				{
					contextMenu1.MenuItems.Add(separator);
					contextMenu1.MenuItems.Add(miAddItem);
				}
			}

			contextMenu1.Show(this, pt);

			// even if the miAddItem menu item has not been added, Remove() won't crash.
			contextMenu1.MenuItems.Remove(separator);
			contextMenu1.MenuItems.Remove(miAddItem);

			return true;
		}

		private void miLoadLocations_Click(object sender, System.EventArgs e)
		{
			IMapControl3 mapControl = (IMapControl3)axMapControl1.Object;

			// ��ʾ�������������ҳ����
			frmLoadLocations loadLocations = new frmLoadLocations();
			if (loadLocations.ShowModal(mapControl, m_naEnv))
			{
				// �������Ѹ��ģ��ѽ�λ����ӵ����е�һ��naclass
				INAContextEdit contextEdit = m_naEnv.NAWindow.ActiveAnalysis.Context as INAContextEdit;
				contextEdit.ContextChanged();

				// ������أ�ˢ��NAWindow��Ļ
				INALayer naLayer = m_naWindow.ActiveAnalysis;
				mapControl.Refresh(esriViewDrawPhase.esriViewGeography, naLayer, mapControl.Extent);
				m_naWindow.UpdateContent(m_naWindow.ActiveCategory);
			}
		}

		private void miClearLocations_Click(object sender, System.EventArgs e)
		{
			IMapControl3 mapControl = (IMapControl3)axMapControl1.Object;

			IEngineNetworkAnalystHelper naHelper = m_naEnv as IEngineNetworkAnalystHelper;
			IEngineNAWindow naWindow = m_naWindow;
			INALayer naLayer = naWindow.ActiveAnalysis;
			naHelper.DeleteAllNetworkLocations();
			mapControl.Refresh(esriViewDrawPhase.esriViewGeography, naLayer, mapControl.Extent);
		}

		private void miAddItem_Click(object sender, System.EventArgs e)
		{
			//����˫���������༭����
                  //ֻΪ�������initDefaultValues�����е�Ĭ��ֵ���Զ����ɵ�����ֵ��

			IMapControl3 mapControl = (IMapControl3)axMapControl1.Object;

			IEngineNAWindowCategory2 activeCategory = m_naWindow.ActiveCategory as IEngineNAWindowCategory2;
			IDataLayer pDataLayer = activeCategory.DataLayer;
			// �����д���һ�����в���䲢��ʼĬ��ֵ
			ITable table = pDataLayer as ITable;
			IRow row = table.CreateRow();
			IRowSubtypes rowSubtypes = row as IRowSubtypes;
			rowSubtypes.InitDefaultValues();
			// �Զ�������ʾ����			
			IFeatureLayer ipFeatureLayer = activeCategory.Layer as IFeatureLayer;
			IStandaloneTable ipStandaloneTable = pDataLayer as IStandaloneTable;
			string name = "";
			if (ipFeatureLayer != null)
				name = ipFeatureLayer.DisplayField;
			else if (ipStandaloneTable != null)
				name = ipStandaloneTable.DisplayField;
			//�����ʾ�ֶ�Ϊ���ַ����򲻴���NaClass�ϵ�ʵ���ֶΣ��������Զ�����
			string currentName = "";
			int fieldIndex = row.Fields.FindField(name);
			if (fieldIndex >= 0)
			{
				currentName = row.get_Value(fieldIndex) as string;
				if (currentName.Length <= 0)
					row.set_Value(fieldIndex, "Item" + ++autogenInt);
			}	
          		INAClassDefinition naClassDef = activeCategory.NAClass.ClassDefinition;
			if (naClassDef.Name == "OrderPairs")
			{
				fieldIndex = row.Fields.FindField("SecondOrderName");
				if (fieldIndex >= 0)
				{
					string secondName = row.get_Value(fieldIndex) as string;
					if (secondName.Length <= 0)
						row.set_Value(fieldIndex, "Item" + ++autogenInt);
				}
			}
			row.Store();

			// ��naclass�����
			INAContextEdit contextEdit = m_naEnv.NAWindow.ActiveAnalysis.Context as INAContextEdit;
			contextEdit.ContextChanged();

			// ˢ�� NAWindow ����Ļ����
			INALayer naLayer = m_naWindow.ActiveAnalysis;
			mapControl.Refresh(esriViewDrawPhase.esriViewGeography, naLayer, mapControl.Extent);
			m_naWindow.UpdateContent(m_naWindow.ActiveCategory);
		}


        //���ĵ�
        private void ToolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            //ʹ�öԻ���ѡ��Ҫ�򿪵�mxd�ĵ�
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "ArcMap Documents (*.mxd)|*.mxd";
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    axMapControl1.LoadMxFile(filePath);
                }
            }
        }        

        //���Բ�ѯ&�ռ��ѯ

        private void ToolStripMenuItemQueryBySpatial_Click(object sender, EventArgs e)
        {
            //�´����ռ��ѯ����
            FormQueryBySpatial formQueryBySpatial = new FormQueryBySpatial();
            //����ǰ��������MapControl�ؼ��е�Map����ֵ��FormSelection�����CurrentMap����
            formQueryBySpatial.CurrentMap = axMapControl1.Map;
            //��ʾ�ռ��ѯ����
            formQueryBySpatial.Show();
        }

        private void ToolStripMenuItemQueryByAttribute_Click(object sender, EventArgs e)
        {
            //�´������Բ�ѯ����
            FormQueryByAttribute formQueryByAttribute = new FormQueryByAttribute();
            //����ǰ��������MapControl�ؼ��е�Map����ֵ��FormQueryByAttribute�����CurrentMap����
            formQueryByAttribute.CurrentMap = axMapControl1.Map;
            //��ʾ���Բ�ѯ����
            formQueryByAttribute.Show();
        }                   

        //�ű� ����ϵ����Ϣ  
       
        private void toolStripStatusCoordinates_Click(object sender, EventArgs e)
        {

        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            // ��ʾ��ǰ������,����
            toolStripStatusScale.Text = " ������ 1:" + axMapControl1.MapScale.ToString("f0");

            // ��ʾ��ǰ���꣬����С�������λ
            toolStripStatusCoordinates.Text = String.Format(" ��ǰ���� X = {0}, Y={1} {2}",e.mapX.ToString("f4"),e.mapY.ToString("f4"),
                                                                                                YCMap.Utils.SystemHelper.ConvertEsriUnit(axMapControl1.MapUnits));
        }

        private void axToolbarControl_OnMouseMove(object sender, IToolbarControlEvents_OnMouseMoveEvent e)
        {
            // ȡ��������ڹ��ߵ�������
            int index = axToolbarControl1.HitTest(e.x, e.y, false);
            if (index != -1)
            {
                // ȡ��������ڹ��ߵ� ToolbarItem
                IToolbarItem toolbarItem = axToolbarControl1.GetItem(index);
                // ����״̬����Ϣ
                toolStripStatusMessage.Text = toolbarItem.Command.Message;
            }
            else
            {
                toolStripStatusMessage.Text = " ���� ";
            }
        }
	}
}
