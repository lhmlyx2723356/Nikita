using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Nikita.WinForm.ExtendControl;
using Nikita.WinForm.ExtendControl.WinControls;
using Nikita.Base.CacheStore;

namespace Nikita.Platform.BugClose
{
    public sealed partial class FrmBugCloseMainForm : Form
    {
        private readonly FrmBugCloseMenu m_bugCloseMenu;
        private readonly ToolStripRenderer m_custom = new VS2012ToolStripRenderer();
        private readonly ToolStripRenderer m_system = new ToolStripProfessionalRenderer();

        public FrmBugCloseMainForm()
        {
            InitializeComponent();
            m_bugCloseMenu = new FrmBugCloseMenu { RightToLeftLayout = RightToLeftLayout };
            OutlookBar outLookBarMenu = m_bugCloseMenu.OutlookBarMenu;
            outLookBarMenu.ItemClicked += OnOutlookBarItemClicked;
            m_bugCloseMenu.Show(dockPanel);
            vS2012ToolStripExtender1.DefaultRenderer = m_system;
            vS2012ToolStripExtender1.VS2012Renderer = m_custom;
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

        private void EnableVS2012Renderer(bool enable)
        {
            vS2012ToolStripExtender1.SetEnableVS2012Style(this.mainMenu, enable);
            //vS2012ToolStripExtender1.SetEnableVS2012Style(this.toolBar, enable);
        }

        private IDockContent FindDocument(string text)
        {
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                return (from form in MdiChildren where form.Text == text select form as IDockContent).FirstOrDefault();
            }
            return dockPanel.Documents.FirstOrDefault(content => content.DockHandler.TabText == text);
        }
        private void SetSchema(object sender, EventArgs e)
        {
            CloseAllContents();

            if (sender == menuItemSchemaVS2005)
            {
                dockPanel.Theme = vS2005Theme1;
                EnableVS2012Renderer(false);
            }
            else if (sender == menuItemSchemaVS2003)
            {
                dockPanel.Theme = vS2003Theme1;
                EnableVS2012Renderer(false);
            }
            else if (sender == menuItemSchemaVS2012Light)
            {
                dockPanel.Theme = vS2012LightTheme1;
                EnableVS2012Renderer(true);
            }

            menuItemSchemaVS2005.Checked = (sender == menuItemSchemaVS2005);
            menuItemSchemaVS2003.Checked = (sender == menuItemSchemaVS2003);
            menuItemSchemaVS2012Light.Checked = (sender == menuItemSchemaVS2012Light);
        }
        #endregion

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
        void OnOutlookBarItemClicked(OutlookBarBand band, OutlookBarItem item)
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
        #endregion
    }
}