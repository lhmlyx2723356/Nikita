using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Configuration;
using System.Drawing.Printing;

namespace Nikita.Report.WinForm
{
    public partial class FrmReportBase : Form
    {

        private readonly DataTable _dt;
        private readonly DataTable _dt2;
        private readonly string _rpt;
        private readonly string _caption;
        public FrmReportBase(DataTable dt, DataTable dt2, string caption, string rpt)
        {
            InitializeComponent();
            _dt = dt;
            _dt2 = dt2;
            _rpt = rpt;
            _caption = caption;
        }
        private void frmReportBase_Load(object sender, EventArgs e)
        {
            ReportViewerMain.ProcessingMode = ProcessingMode.Local;
            ReportViewerMain.LocalReport.DisplayName = _caption;
            //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //if (Rpt == "RptNew.rdlc")
            //{ 
            //    PageSetupDialog dlg = new PageSetupDialog();
            //    dlg.PageSettings = new PageSettings()
            //    {
            //        Landscape = false,
            //        Margins = new Margins { Left = 10, Top = 0, Bottom = 0, Right = 0 }
            //        //,
            //        //PaperSize = new PaperSize { RawKind = 11 }
            //        // ,
            //        //PaperSource = new PaperSource { RawKind = 11 }
            //    };
            //    reportViewer1.SetPageSettings(dlg.PageSettings);
            //}
            //else
            //{
            //    PageSetupDialog dlg = new PageSetupDialog();
            //    dlg.PageSettings = new PageSettings()
            //    {
            //        PaperSize = new PaperSize { RawKind = 9 }
            //        // ,
            //        //PaperSource = new PaperSource { RawKind = 9 }
            //    };
            //    reportViewer1.SetPageSettings(dlg.PageSettings);
            //} 
            string strFilePath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "SysRpt\\" + _rpt;//Rpt.rdlc
            ReportViewerMain.LocalReport.ReportPath = strFilePath;
            ReportViewerMain.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", _dt));
            ReportViewerMain.LocalReport.DataSources.Add(new ReportDataSource("DataSet2", _dt2));
            ReportViewerMain.RefreshReport();
            ReportViewerMain.RefreshReport();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
