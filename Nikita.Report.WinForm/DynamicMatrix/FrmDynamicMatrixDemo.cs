using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

 namespace Nikita.Report.WinForm
{
    public partial class FrmDynamicMatrixDemo : Form
    {
        private DataSet m_dataSet;
        private MemoryStream m_rdl;
        private List<string> m_allFields = new List<string>();
        private List<string> m_rowFields = new List<string>();
        private List<string> m_columnFields = new List<string>();
        private List<string> m_summarizedFields = new List<string>();

        public FrmDynamicMatrixDemo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void ShowReport()
        {
            if (m_rdl == null)
                return;
            this.reportViewer1.Reset();
            m_rdl.Position = 0;
            this.reportViewer1.LocalReport.LoadReportDefinition(m_rdl);
            if (m_dataSet != null)
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("MyData", m_dataSet.Tables[0]));
            this.reportViewer1.RefreshReport();
        }

        private void GenerateRdl()
        {
            if (m_rdl != null)
                m_rdl.Dispose();
            m_rdl = new MemoryStream();
            RdlGenerator generator = new RdlGenerator();
            generator.AllFields = m_allFields;
            generator.RowFields = m_rowFields;
            generator.ColumnFields = m_columnFields;
            generator.SummarizedFields = m_summarizedFields;
            using (Graphics g = this.CreateGraphics())
            {
                generator.WidthInches = (this.ClientRectangle.Width - 25) / g.DpiX;
            }
            generator.WriteXml(m_rdl);
        }

        private void SaveRdl(MemoryStream rdl, string filename)
        {
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                rdl.WriteTo(fs);
            }
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

        private void OpenDataFile(string filename)
        {
            try
            {
                m_dataSet = new DataSet();
                m_dataSet.ReadXml(filename);

                m_allFields = GetAvailableFields();
                m_columnFields.Clear();
                m_rowFields.Clear();
                m_summarizedFields.Clear();
                MatrixDialog matrixDialog = new MatrixDialog();
                matrixDialog.AllFields = m_allFields;
                matrixDialog.RowFields = m_rowFields;
                matrixDialog.ColumnFields = m_columnFields;
                matrixDialog.SummarizedFields = m_summarizedFields;
                if (matrixDialog.ShowDialog() != DialogResult.OK)
                    return;
                m_rowFields = matrixDialog.RowFields;
                m_columnFields = matrixDialog.ColumnFields;
                m_summarizedFields = matrixDialog.SummarizedFields;

                GenerateRdl();

                ShowReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeFields(List<string> rowFields, List<string> columnFields, List<string> summarizedFields)
        {
            m_rowFields = rowFields;
            m_columnFields = columnFields;
            m_summarizedFields = summarizedFields;

            GenerateRdl();

            ShowReport();
        }

        private void pivotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MatrixDialog matrixDialog = new MatrixDialog();
            matrixDialog.AllFields = m_allFields;
            matrixDialog.RowFields = m_rowFields;
            matrixDialog.ColumnFields = m_columnFields;
            matrixDialog.SummarizedFields = m_summarizedFields;
            matrixDialog.ApplyCallback = ChangeFields;
            if (matrixDialog.ShowDialog() == DialogResult.OK)
            {
                ChangeFields(matrixDialog.RowFields, matrixDialog.ColumnFields, matrixDialog.SummarizedFields);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                OpenDataFile(openFileDialog1.FileName);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveRDLCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_rdl == null)
            {
                MessageBox.Show("No rdl generated yet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                SaveRdl(m_rdl, saveFileDialog1.FileName);
        }
    }
}