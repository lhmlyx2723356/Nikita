using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Nikita.WinForm.ExtendControl;

namespace Nikita.Applications.WinFramework
{
    public sealed partial class FrmTreeMainForm : Form
    {
        private readonly FrmLeft m_solutionExplorer;
        public FrmTreeMainForm()
        {
            InitializeComponent();

            m_solutionExplorer = new FrmLeft { RightToLeftLayout = RightToLeftLayout };
            m_solutionExplorer.Show(dockPanel);
            vS2012ToolStripExtender1.DefaultRenderer = _system;
            vS2012ToolStripExtender1.VS2012Renderer = _custom;
        }

        #region Methods

        private readonly ToolStripRenderer _custom = new VS2012ToolStripRenderer();

        private readonly ToolStripRenderer _system = new ToolStripProfessionalRenderer();

        private void CloseAllContents()
        { 
            m_solutionExplorer.DockPanel = null; 
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

        #region Event Handlers

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