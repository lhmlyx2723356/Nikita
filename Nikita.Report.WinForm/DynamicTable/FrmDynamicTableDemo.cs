using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using Microsoft.Reporting.WinForms;

 namespace Nikita.Report.WinForm
{
    public partial class FrmDynamicTableDemo : Form
    {
        private DataSet m_dataSet;
        private MemoryStream m_rdl;

        public FrmDynamicTableDemo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            OpenFileDialog dialog=new OpenFileDialog();
            if (dialog.ShowDialog()==DialogResult.OK)
            { 
                OpenDataFile(dialog.FileName, false);
            }
        }

        private void ShowReport()
        {
            this.reportViewer1.Reset();
            this.reportViewer1.LocalReport.LoadReportDefinition(m_rdl);
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("MyData", m_dataSet.Tables[0]));
            this.reportViewer1.RefreshReport();
        }

        private MemoryStream GenerateRdl(List<string> allFields, List<string> selectedFields)
        {
            MemoryStream ms = new MemoryStream();
            RdlGeneratorTable gen = new RdlGeneratorTable();
            gen.AllFields = allFields;
            gen.SelectedFields = selectedFields;
            gen.WriteXml(ms);
            ms.Position = 0;
            return ms;
        }

        private void DumpRdl(MemoryStream rdl)
        {
#if DEBUG_RDLC
            using (FileStream fs = new FileStream(@"c:\test.rdlc", FileMode.Create))
            {
                rdl.WriteTo(fs);
            }
#endif
        }

        private List<string> GetAvailableFields()
        {
            DataTable dataTable = m_dataSet.Tables[0];
            List<string> availableFields = new List<string>();
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                availableFields.Add(dataTable.Columns[i].ColumnName);
            }
            return availableFields;
        }

        private void OpenDataFile(string filename, bool showOptionsDialog)
        {
            try
            {
                m_dataSet = new DataSet();
                m_dataSet.ReadXml(filename);

                List<string> allFields = GetAvailableFields();
                ReportOptionsDialog dlg = new ReportOptionsDialog(allFields);
                if (showOptionsDialog)
                {
                    if (dlg.ShowDialog() != DialogResult.OK)
                        return;
                }
                List<string> selectedFields = dlg.GetSelectedFields();

                if (m_rdl != null)
                    m_rdl.Dispose();
                m_rdl = GenerateRdl(allFields, selectedFields);
                DumpRdl(m_rdl);

                ShowReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OpenDataFile(openFileDialog1.FileName, true);
            }
        }
    }
}
