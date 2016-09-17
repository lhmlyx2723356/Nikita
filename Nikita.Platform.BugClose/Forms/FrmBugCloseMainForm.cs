using Nikita.Base.CacheStore;
using Nikita.WinForm.ExtendControl.WinControls;
using System;
using System.Linq;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Platform.BugClose
{
    public sealed partial class FrmBugCloseMainForm : Form
    {
        private readonly FrmBugCloseMenu m_bugCloseMenu;
        private readonly ToolStripRenderer m_system = new ToolStripProfessionalRenderer();

        public FrmBugCloseMainForm()
        {
            InitializeComponent();
            m_bugCloseMenu = new FrmBugCloseMenu { RightToLeftLayout = RightToLeftLayout };
            OutlookBar outLookBarMenu = m_bugCloseMenu.OutlookBarMenu;
            outLookBarMenu.ItemClicked += OnOutlookBarItemClicked;
            m_bugCloseMenu.Show(dockPanel);
        }

        #region Methods

        private void CloseAllContents()
        {
            m_bugCloseMenu.DockPanel = null;
            CloseAllDocuments();
        }

        private void CloseAllDocuments()
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                foreach (Form form in MdiChildren)
                    form.Close();
            }
            else
            {
                foreach (IDockContent document in dockPanel.DocumentsToArray())
                {
                    document.DockHandler.Close();
                }
            }
        }

        private IDockContent FindDocument(string text)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                return (from form in MdiChildren where form.Text == text select form as IDockContent).FirstOrDefault();
            }
            return dockPanel.Documents.FirstOrDefault(content => content.DockHandler.TabText == text);
        }

        #endregion Methods

        private void OpenForm(DockContent itemDockContent)
        {
            IDockContent iDockContent = FindDocument(itemDockContent.Text);
            if (iDockContent == null)
            {
                itemDockContent.Show(dockPanel);
            }
            else
            {
                var firstOrDefault = dockPanel.Documents.FirstOrDefault(t => t.DockHandler.TabText == itemDockContent.Text);
                if (firstOrDefault != null)
                    firstOrDefault.DockHandler.Show();
            }
        }

        #region Event Handlers

        private void OnOutlookBarItemClicked(OutlookBarBand band, OutlookBarItem item)
        {
            if (item.Text == "缺陷字典管理")
            {
                DockContent itemDockContent = new FrmBseDictionaryTreeQuery();
                OpenForm(itemDockContent);
            }
            else if (item.Text == "基础项目")
            {
                DockContent itemDockContent = new FrmBseProjectSimpleQuery();
                OpenForm(itemDockContent);
            }
            else if (item.Text == "项目版本")
            {
                DockContent itemDockContent = new FrmBseProjectMasterDetailQuery();
                OpenForm(itemDockContent);
            }
            else if (item.Text == "项目模块")
            {
                DockContent itemDockContent = new FrmBseProjectModuleMasterDetailQuery();
                OpenForm(itemDockContent);
            }
            else if (item.Text == "基础表设置")
            {
                Form itemDockContent = new FrmCacheTablesSimpleQuery();
                itemDockContent.ShowDialog();
            }
            else if (item.Text == "缓存设置")
            {
                Form itemDockContent = new FrmCacheConfigSimpleQuery();
                itemDockContent.ShowDialog();
            }
        }

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            //FrmAboutDialog aboutDialog = new FrmAboutDialog();
            //aboutDialog.ShowDialog(this);
        }

        private void menuItemClose_Click(object sender, EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                if (ActiveMdiChild != null) ActiveMdiChild.Close();
            }
            else if (dockPanel.ActiveDocument != null)
                dockPanel.ActiveDocument.DockHandler.Close();
        }

        private void menuItemCloseAll_Click(object sender, EventArgs e)
        {
            CloseAllDocuments();
        }

        private void menuItemCloseAllButThisOne_Click(object sender, EventArgs e)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                Form activeMdi = ActiveMdiChild;
                foreach (Form form in MdiChildren)
                {
                    if (form != activeMdi)
                        form.Close();
                }
            }
            else
            {
                foreach (IDockContent document in dockPanel.DocumentsToArray())
                {
                    if (!document.DockHandler.IsActivated)
                        document.DockHandler.Close();
                }
            }
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion Event Handlers

        private void EnableVSRenderer(VSToolStripExtender.VsVersion version)
        {
            vS2012ToolStripExtender1.SetStyle(this.mainMenu, version);
            //vS2012ToolStripExtender1.SetStyle(this.toolBar, version);
        }

        private void SetSchema(object sender, System.EventArgs e)
        {
            //// Persist settings when rebuilding UI
            //string configFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.temp.config");

            //dockPanel.SaveAsXml(configFile);
            //CloseAllContents();

            //if (sender == this.menuItemSchemaVS2005)
            //{
            //    this.dockPanel.Theme = this.vS2005Theme1;
            //    this.EnableVSRenderer(VSToolStripExtender.VsVersion.Vs2005);
            //}
            //else if (sender == this.menuItemSchemaVS2003)
            //{
            //    this.dockPanel.Theme = this.vS2003Theme1;
            //    this.EnableVSRenderer(VSToolStripExtender.VsVersion.Vs2003);
            //}
            if (sender == this.menuItemSchemaVS2012Light)
            {
                this.dockPanel.Theme = this.vS2012LightTheme1;
                this.EnableVSRenderer(VSToolStripExtender.VsVersion.Vs2012);
            }
            else if (sender == this.menuItemSchemaVS2012Blue)
            {
                this.dockPanel.Theme = this.vS2012BlueTheme1;
                this.EnableVSRenderer(VSToolStripExtender.VsVersion.Vs2012);
            }
            else if (sender == this.menuItemSchemaVS2012Dark)
            {
                this.dockPanel.Theme = this.vS2012DarkTheme1;
                this.EnableVSRenderer(VSToolStripExtender.VsVersion.Vs2012);
            }
            //else if (sender == this.menuItemSchemaVS2013Blue)
            //{
            //    this.dockPanel.Theme = this.vS2013BlueTheme1;
            //    this.EnableVSRenderer(VSToolStripExtender.VsVersion.Vs2013);
            //}
            //else if (sender == this.menuItemSchemaVS2013Light)
            //{
            //    this.dockPanel.Theme = this.vS2013LightTheme1;
            //    this.EnableVSRenderer(VSToolStripExtender.VsVersion.Vs2013);
            //}
            //else if (sender == this.menuItemSchemaVS2013Dark)
            //{
            //    this.dockPanel.Theme = this.vS2013DarkTheme1;
            //    this.EnableVSRenderer(VSToolStripExtender.VsVersion.Vs2013);
            //}
            //menuItemSchemaVS2005.Checked = (sender == menuItemSchemaVS2005);
            //menuItemSchemaVS2003.Checked = (sender == menuItemSchemaVS2003);
            menuItemSchemaVS2012Light.Checked = (sender == menuItemSchemaVS2012Light);
            menuItemSchemaVS2012Blue.Checked = (sender == menuItemSchemaVS2012Blue);
            menuItemSchemaVS2012Dark.Checked = (sender == menuItemSchemaVS2012Dark);
            //menuItemSchemaVS2013Light.Checked = (sender == menuItemSchemaVS2013Light);
            //menuItemSchemaVS2013Blue.Checked = (sender == menuItemSchemaVS2013Blue);
            //menuItemSchemaVS2013Dark.Checked = (sender == menuItemSchemaVS2013Dark);
            //topBar.Visible = (menuItemSchemaVS2012Blue.Checked || menuItemSchemaVS2012Dark.Checked
            //    || menuItemSchemaVS2012Light.Checked || menuItemSchemaVS2013Light.Checked
            //    || menuItemSchemaVS2013Blue.Checked || menuItemSchemaVS2013Dark.Checked);
            //bottomBar.Visible = menuItemSchemaVS2013Light.Checked || menuItemSchemaVS2013Blue.Checked || menuItemSchemaVS2013Dark.Checked;
            //topBar.BackColor = dockPanel.Theme.Skin.ColorPalette.MainWindowActive.Background;
            //bottomBar.BackColor = dockPanel.Theme.Skin.ColorPalette.MainWindowActive.Background;
            statusBar.BackColor = dockPanel.Theme.Skin.ColorPalette.MainWindowStatusBarDefault.Background;

            //if (File.Exists(configFile))
            //    dockPanel.LoadFromXml(configFile, m_deserializeDockContent);
        }
    }
}