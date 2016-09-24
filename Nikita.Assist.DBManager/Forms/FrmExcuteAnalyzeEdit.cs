using Nikita.Base.DbSchemaReader.DataSchema;
 
using Nikita.Assist.DBManager.DAL;
using Nikita.Assist.DBManager.Model;
using System;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;


namespace Nikita.Assist.DBManager
{
    public partial class FrmExcuteAnalyzeEdit : Form
    {
        private Bse_ExcuteAnalyzeDAL dal = new Bse_ExcuteAnalyzeDAL();

        public FrmExcuteAnalyzeEdit()
        {
            InitializeComponent();
            txtSql.ShowEOLMarkers = false;
            txtSql.ShowHRuler = false;
            txtSql.ShowInvalidLines = false;
            txtSql.ShowMatchingBracket = true;
            txtSql.ShowSpaces = false;
            txtSql.ShowTabs = false;
            txtSql.ShowVRuler = false;
            txtSql.AllowCaretBeyondEOL = false;
            txtSql.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("SQL");
            txtSql.Encoding = Encoding.GetEncoding("GB2312");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入脚本名称");
                return;
            }
            if (cboType.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请选择数据库类型");
                return;
            }
            if (cboRunType.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请选择执行类型");
                return;
            }
            if (txtSql.Text.Trim() == string.Empty)
            {
                MessageBox.Show("请输入脚本信息");
                return;
            }
            Bse_ExcuteAnalyze model = new Bse_ExcuteAnalyze();
            model.DbType = cboType.Text.Trim();
            model.ExcuteName = txtName.Text.Trim();
            model.ExcuteSql = txtSql.Text.Trim();
            model.ExcuteType = cboRunType.Text.Trim();
            model.Remark = string.Empty;
            int intResult = dal.Add(model);
            if (intResult > 0)
            {
                MessageBox.Show("保存成功");
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }

        private void FrmExcuteAnalyzeEdit_Load(object sender, EventArgs e)
        {
            foreach (var item in Enum.GetValues(typeof(SqlType)))
            {
                cboType.Items.Add(item.ToString());
            }
            cboType.SelectedIndex = 0;
            cboRunType.SelectedIndex = 0;
        }
    }
}