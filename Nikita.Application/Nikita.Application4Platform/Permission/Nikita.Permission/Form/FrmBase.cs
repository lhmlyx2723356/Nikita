using DevExpress.XtraEditors;
using Nikita.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Nikita.Permission
{
    public partial class FrmBase : Form
    {
        public bool BlInitBound = false;

        public DataRow FrmDataRow = null;

        public DataTable FrmDataTable = null;

        public string GetSpBackStrResult = string.Empty;

        public int Nextindex;

        public string StrBtnMode = string.Empty;

        public string StrCtrlAdd = string.Empty;

        public string StrCtrlMode = string.Empty;

        public List<string> StringArrary = new List<string>();

        public List<string> StringArraryCheckSave = new List<string>();

        //需要保存的控件ArrayList
        public List<string> StringBtnMode = new List<string>();

        public FrmBase()
        {
            InitializeComponent();
        }

        public Control FocusedControl
        {
            get;
            set;
        }

        //按钮控件ArrayList
        //新增成功后用于赋值
        public Control ParentControl
        {
            get;
            set;
        }

        public string StrFocusedContrName
        {
            get;
            set;
        }

        public bool DoCheck(string CtrlType, string CtrlName, Control ctl, string CtrlSaveArrayTxt)
        {
            Control ctrl = (TextEdit)ctl.Controls.Find(CtrlName, true)[0];
            switch (CtrlType)
            {
                case "DevExpress.XtraEditors.TextEdit":
                    if ((ctrl as TextEdit).Text.Trim().Length == 0)
                    {
                        MessageBox.Show("请输入" + CtrlSaveArrayTxt);
                        ctrl.Focus();
                        return false;
                    }
                    break;

                case "DevExpress.XtraEditors.MemoEdit":
                    if ((ctrl as MemoEdit).Text.Trim().Length == 0)
                    {
                        MessageBox.Show("请输入" + CtrlSaveArrayTxt);
                        ctrl.Focus();
                        return false;
                    }
                    break;

                case "DevExpress.XtraEditors.LookUpEdit":
                    if ((ctrl as LookUpEdit).EditValue == null)
                    {
                        MessageBox.Show("请选择" + CtrlSaveArrayTxt);
                        ctrl.Focus();
                        return false;
                    }
                    break;

                case "DevExpress.XtraEditors.CheckedComboBoxEdit":
                    if ((ctrl as CheckedComboBoxEdit).EditValue == null)
                    {
                        MessageBox.Show("请选择" + CtrlSaveArrayTxt);
                        ctrl.Focus();
                        return false;
                    }
                    break;

                case "DevExpress.XtraEditors.DateEdit":
                    if ((ctrl as DateEdit).EditValue == null)
                    {
                        MessageBox.Show("请选择" + CtrlSaveArrayTxt);
                        ctrl.Focus();
                        (ctrl as DateEdit).ShowPopup();
                        return false;
                    }
                    break;

                case "DevExpress.XtraEditors.ComboBoxEdit":
                    if ((ctrl as ComboBoxEdit).EditValue == null)
                    {
                        MessageBox.Show("请选择" + CtrlSaveArrayTxt);
                        ctrl.Focus();
                        (ctrl as ComboBoxEdit).ShowPopup();
                        return false;
                    }
                    break;

                case "DevExpress.XtraEditors.ImageComboBoxEdit":
                    if ((ctrl as ImageComboBoxEdit).EditValue == null)
                    {
                        MessageBox.Show("请选择" + CtrlSaveArrayTxt);
                        ctrl.Focus();
                        (ctrl as ImageComboBoxEdit).ShowPopup();
                        return false;
                    }
                    break;

                default:
                    break;
            }
            return true;
        }

        public void DoFocus(Control ctrl)
        {
            switch (ctrl.GetType().ToString())
            {
                case "System.Windows.Forms.TextBox":
                    (ctrl as TextBox).Focus();
                    break;

                case "DevExpress.XtraEditors.TextEdit":
                    (ctrl as TextEdit).Focus();
                    break;

                case "DevExpress.XtraEditors.ComboBoxEdit":
                    (ctrl as ComboBoxEdit).Focus();
                    (ctrl as ComboBoxEdit).ShowPopup();
                    break;

                case "DevExpress.XtraEditors.CheckEdit":
                    (ctrl as CheckEdit).Checked = (ctrl as CheckEdit).Checked == true ? false : true;
                    break;

                case "DevExpress.XtraEditors.MemoEdit":
                    (ctrl as MemoEdit).Focus();
                    break;

                case "DevExpress.XtraEditors.LookUpEdit":
                    (ctrl as LookUpEdit).Focus();

                    (ctrl as LookUpEdit).ShowPopup();
                    break;

                case "DevExpress.XtraEditors.CheckedComboBoxEdit":
                    (ctrl as CheckedComboBoxEdit).Focus();
                    (ctrl as CheckedComboBoxEdit).Select();
                    (ctrl as CheckedComboBoxEdit).ShowPopup();
                    break;

                case "DevExpress.XtraEditors.DateEdit":
                    (ctrl as DateEdit).Focus();
                    (ctrl as DateEdit).ShowPopup();
                    break;

                    break;

                case "DevExpress.XtraEditors.ImageComboBoxEdit":
                    (ctrl as ImageComboBoxEdit).Focus();
                    (ctrl as ImageComboBoxEdit).Select();
                    (ctrl as ImageComboBoxEdit).ShowPopup();
                    break;

                default:
                    break;
            }
        }

        /// <summary>编辑区获取按钮控件列表
        ///
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        ///
        public Hashtable GetBtnInfoArray(Control ct)
        {
            Hashtable Values = new Hashtable();
            try
            {
                foreach (Control ctl in ct.Controls)
                {
                    switch (ctl.GetType().ToString())
                    {
                        case "DevExpress.XtraEditors.SimpleButton":
                            SimpleButton btn = new SimpleButton();
                            btn = (SimpleButton)ct.Controls.Find(ctl.Name, false)[0];
                            if (btn.Visible != false && btn.Enabled != false)
                            {
                                StringBtnMode.Add(ctl.Name);
                            }
                            break;

                        default:
                            break;
                    }
                }
                Values["GetControlInofo_BtnMode"] = StringBtnMode;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Values;
        }

        /// <summary>判断编辑区是否有必填项未填写
        ///
        /// </summary>
        /// <param name="CheckSaveStringArrary"></param>
        /// <param name="StrArrayList"></param>
        /// <param name="ctl"></param>
        /// <returns></returns>
        public bool GetCheckSaveCtl(List<string> CheckSaveStringArrary, List<string> StrArrayList, Control ctl)
        {
            String[] StrArray;
            String[] StrArraySave;
            for (int i = 0; i < CheckSaveStringArrary.Count; i++)
            {
                StrArraySave = CheckSaveStringArrary[i].Split(',');
                for (int j = 0; j < StrArrayList.Count; j++)
                {
                    StrArray = StrArrayList[j].Split(',');
                    switch (StrArray[2].ToString())
                    {
                        case "DevExpress.XtraEditors.TextEdit":
                            TextEdit txt = new TextEdit();
                            txt = (TextEdit)ctl.Controls.Find(StrArray[1].ToString(), true)[0];
                            if (txt.Name.Substring(3, txt.Name.Length - 3) == StrArraySave[1].ToString() && txt.Text.Trim().Length == 0)
                            {
                                MessageBox.Show(StrArraySave[2].ToString() + "不能为空！");
                                txt.Focus();
                                return false;
                            }
                            break;

                        case "DevExpress.XtraEditors.MemoEdit":
                            MemoEdit mTxt = new MemoEdit();
                            mTxt = (MemoEdit)ctl.Controls.Find(StrArray[1].ToString(), false)[0];
                            if (mTxt.Name.Substring(3, mTxt.Name.Length - 3) == StrArraySave[1].ToString() && mTxt.EditValue.ToString().Trim().Length == 0)
                            {
                                MessageBox.Show(StrArraySave[2].ToString() + "不能为空！");
                                mTxt.Focus();
                                return false;
                            }
                            break;

                        case "DevExpress.XtraEditors.LookUpEdit":
                            LookUpEdit dpl = new LookUpEdit();
                            dpl = (LookUpEdit)ctl.Controls.Find(StrArray[1].ToString(), false)[0];
                            if (dpl.Name.Substring(3, dpl.Name.Length - 3) == StrArraySave[1].ToString() && dpl.EditValue.ToString().Trim().Length == 0)
                            {
                                MessageBox.Show(StrArraySave[2].ToString() + "不能为空！");
                                dpl.Focus();
                                dpl.ShowPopup();
                                return false;
                            }
                            break;

                        case "DevExpress.XtraEditors.CheckedComboBoxEdit":
                            CheckedComboBoxEdit ckcob = new CheckedComboBoxEdit();
                            ckcob = (CheckedComboBoxEdit)ctl.Controls.Find(StrArray[1].ToString(), false)[0];
                            if (ckcob.Name.Substring(3, ckcob.Name.Length - 3) == StrArraySave[1].ToString() && ckcob.EditValue.ToString().Trim().Length == 0)
                            {
                                MessageBox.Show(StrArraySave[2].ToString() + "为必选！");
                                return false;
                            }
                            break;

                        case "DevExpress.XtraEditors.DateEdit":
                            DateEdit dt = new DateEdit();
                            dt = (DateEdit)ctl.Controls.Find(StrArray[1].ToString(), false)[0];
                            if (dt.Name.Substring(3, dt.Name.Length - 3) == StrArraySave[1].ToString() && dt.EditValue.ToString().Trim().Length == 0)
                            {
                                MessageBox.Show(StrArraySave[2].ToString() + "不能为空！");
                                dt.Focus();
                                dt.ShowPopup();
                                return false;
                            }
                            break;

                        case "DevExpress.XtraEditors.ComboBoxEdit":
                            ComboBoxEdit Comb = new ComboBoxEdit();
                            Comb = (ComboBoxEdit)ctl.Controls.Find(StrArray[1].ToString(), false)[0];
                            if (Comb.Name.Substring(3, Comb.Name.Length - 3) == StrArraySave[1].ToString() && Comb.EditValue.ToString().Trim().Length == 0)
                            {
                                MessageBox.Show(StrArraySave[2].ToString() + "不能为空！");
                                Comb.Focus();
                                Comb.ShowPopup();
                                return false;
                            }
                            break;

                        case "DevExpress.XtraEditors.ImageComboBoxEdit":
                            ImageComboBoxEdit imgcom = new ImageComboBoxEdit();
                            imgcom = (ImageComboBoxEdit)ctl.Controls.Find(StrArray[1].ToString(), false)[0];
                            if (imgcom.Name.Substring(3, imgcom.Name.Length - 3) == StrArraySave[1].ToString() && imgcom.EditValue.ToString().Trim().Length == 0)
                            {
                                MessageBox.Show(StrArraySave[2].ToString() + "不能为空！");
                                imgcom.Focus();
                                imgcom.ShowPopup();
                                return false;
                            }
                            break;

                        //case "DevExpress.XtraEditors.CheckEdit":
                        //    DevExpress.XtraEditors.CheckEdit chk = new DevExpress.XtraEditors.CheckEdit();
                        //    chk = (DevExpress.XtraEditors.CheckEdit)ctl.Controls.Find(StrArray[1].ToString(), false)[0];
                        //    if (chk.Name.Substring(3, chk.Name.Length - 3) == StrArraySave[1].ToString() && chk.EditValue.ToString().Trim().Length == 0)
                        //    {
                        //        MessageBox.Show(StrArraySave[2].ToString() + "不能为空！");
                        //        chk.Focus();
                        //        return false;
                        //    }
                        //    break;
                        default:
                            break;
                    }
                }
            }
            return true;
        }

        /// <summary>编辑区获取控件列表Out
        ///
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        public List<string> GetControlInfo(Control ct)
        {
            List<string> stringArray = new List<string>();
            List<Int32> intArrary = new List<int>();
            foreach (Control ctl in ct.Controls)
            {
                ctl.Enter += Txt_Enter;
                switch (ctl.GetType().ToString())
                {
                    case "System.Windows.Forms.TextBox":
                        var wintxt = (TextBox)ct.Controls.Find(ctl.Name, false)[0];
                        if (wintxt.Visible && wintxt.Enabled && wintxt.ReadOnly != true)
                        {
                            if (ctl.Tag != null)
                            {
                                stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType() + "," + ctl.Tag);
                            }
                            else
                            {
                                stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType());
                            }
                            intArrary.Add(ctl.TabIndex);
                        }
                        break;

                    case "DevExpress.XtraEditors.TextEdit":
                        var txt = (TextEdit)ct.Controls.Find(ctl.Name, false)[0];
                        if (txt.Visible && txt.Enabled && txt.Properties.ReadOnly != true)
                        {
                            if (ctl.Tag != null)
                            {
                                stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType() + "," + ctl.Tag);
                            }
                            else
                            {
                                stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType());
                            }
                            intArrary.Add(ctl.TabIndex);
                        }
                        break;

                    case "DevExpress.XtraEditors.CheckEdit":
                        var ce = (CheckEdit)ct.Controls.Find(ctl.Name, false)[0];
                        if (ce.Visible && ce.Enabled && ce.Properties.ReadOnly != true)
                        {
                            if (ctl.Tag != null)
                            {
                                stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType() + "," + ctl.Tag);
                            }
                            else
                            {
                                stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType());
                            }
                            intArrary.Add(ctl.TabIndex);
                        }
                        break;

                    case "DevExpress.XtraEditors.MemoEdit":
                        var mme = (MemoEdit)ct.Controls.Find(ctl.Name, false)[0];
                        if (mme.Visible && mme.Enabled && mme.Properties.ReadOnly != true)
                        {
                            if (ctl.Tag != null)
                            {
                                stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType() + "," + ctl.Tag);
                            }
                            else
                            {
                                stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType());
                            }

                            intArrary.Add(ctl.TabIndex);
                        }
                        break;

                    case "DevExpress.XtraEditors.LookUpEdit":
                        var lue = (LookUpEdit)ct.Controls.Find(ctl.Name, false)[0];
                        if (lue.Visible && lue.Enabled && lue.Properties.ReadOnly != true)
                        {
                            if (ctl.Tag != null)
                            {
                                stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType() + "," + ctl.Tag);
                            }
                            else
                            {
                                stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType());
                            }
                            intArrary.Add(ctl.TabIndex);
                        }
                        break;

                    case "DevExpress.XtraEditors.CheckedComboBoxEdit":
                        var ckb = (CheckedComboBoxEdit)ct.Controls.Find(ctl.Name, false)[0];
                        if (ckb.Visible && ckb.Enabled && ckb.Properties.ReadOnly != true)
                        {
                            if (ctl.Tag != null)
                            {
                                stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType() + "," + ctl.Tag);
                            }
                            else
                            {
                                stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType());
                            }

                            intArrary.Add(ctl.TabIndex);
                        }
                        break;

                    case "DevExpress.XtraEditors.DateEdit":
                        var dt = (DateEdit)ct.Controls.Find(ctl.Name, false)[0];
                        if (dt.Visible && dt.Enabled && dt.Properties.ReadOnly != true)
                        {
                            if (ctl.Tag != null)
                            {
                                stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType() + "," + ctl.Tag);
                            }
                            else
                            {
                                stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType());
                            }
                            intArrary.Add(ctl.TabIndex);
                        }
                        break;

                    case "DevExpress.XtraEditors.ComboBoxEdit":
                        var comb = (ComboBoxEdit)ct.Controls.Find(ctl.Name, false)[0];
                        if (comb.Visible && comb.Enabled && comb.Properties.ReadOnly != true)
                        {
                            if (ctl.Tag != null)
                            {
                                stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType() + "," + ctl.Tag);
                            }
                            else
                            {
                                stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType());
                            }
                            intArrary.Add(ctl.TabIndex);
                        }
                        break;
                }
            }
            intArrary.Sort();
            List<string> strArray = new List<string>();
            foreach (int t in intArrary)
            {
                foreach (string t1 in stringArray)
                {
                    if (t.ToString() == t1.Split(',')[0])
                    {
                        strArray.Add(t1);
                    }
                }
            }
            return strArray;
        }

        /// <summary>编辑区获取控件列表
        ///
        /// </summary>
        /// <param name="ct"></param>
        /// <returns></returns>
        ///
        public Hashtable GetControlInofArray(Control ct)
        {
            Hashtable Values = new Hashtable();
            try
            {
                List<string> stringArray = new List<string>();
                List<Int32> IntArrary = new List<int>();
                List<Int32> IntCheckSaveArrary = new List<int>();
                List<string> CheckArray = new List<string>();
                string Tag = string.Empty;
                foreach (Control ctl in ct.Controls)
                {
                    ctl.Enter += new EventHandler(this.Txt_Enter);
                    switch (ctl.GetType().ToString())
                    {
                        //case "DevExpress.XtraEditors.SimpleButton":
                        //    DevExpress.XtraEditors.SimpleButton btn = new DevExpress.XtraEditors.SimpleButton();
                        //    btn = (DevExpress.XtraEditors.SimpleButton)ct.Controls.Find(ctl.Name, false)[0];
                        //    if (btn.Visible != false && btn.Enabled != false)
                        //    {
                        //        StringBtnMode.Add(ctl.Name);
                        //    }
                        //    break;
                        case "DevExpress.XtraEditors.TextEdit":
                            TextEdit txt = new TextEdit();
                            txt = (TextEdit)ct.Controls.Find(ctl.Name, false)[0];
                            if (txt.Visible != false && txt.Enabled != false && txt.Properties.ReadOnly != true)
                            {
                                if (ctl.Tag != null)
                                {
                                    stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType().ToString() + "," + ctl.Tag.ToString());
                                }
                                else
                                {
                                    stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType().ToString());
                                }
                                IntArrary.Add(ctl.TabIndex);
                            }
                            break;

                        case "DevExpress.XtraEditors.CheckEdit":
                            CheckEdit ce = new CheckEdit();
                            ce = (CheckEdit)ct.Controls.Find(ctl.Name, false)[0];
                            if (ce.Visible != false && ce.Enabled != false && ce.Properties.ReadOnly != true)
                            {
                                if (ctl.Tag != null)
                                {
                                    stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType().ToString() + "," + ctl.Tag.ToString());
                                }
                                else
                                {
                                    stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType().ToString());
                                }
                                IntArrary.Add(ctl.TabIndex);
                            }
                            if (ce.ForeColor == Color.Red)
                            {
                                CheckArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name.Substring(3, ctl.Name.Length - 3) + "," + ce.Text.Trim());
                                IntCheckSaveArrary.Add(ctl.TabIndex);
                            }
                            break;

                        case "DevExpress.XtraEditors.MemoEdit":
                            MemoEdit mme = new MemoEdit();
                            mme = (MemoEdit)ct.Controls.Find(ctl.Name, false)[0];
                            if (mme.Visible != false && mme.Enabled != false && mme.Properties.ReadOnly != true)
                            {
                                if (ctl.Tag != null)
                                {
                                    stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType().ToString() + "," + ctl.Tag.ToString());
                                }
                                else
                                {
                                    stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType().ToString());
                                }
                                IntArrary.Add(ctl.TabIndex);
                            }
                            break;

                        case "DevExpress.XtraEditors.LookUpEdit":
                            LookUpEdit lue = new LookUpEdit();
                            lue = (LookUpEdit)ct.Controls.Find(ctl.Name, false)[0];
                            if (lue.Visible != false && lue.Enabled != false && lue.Properties.ReadOnly != true)
                            {
                                if (ctl.Tag != null)
                                {
                                    stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType().ToString() + "," + ctl.Tag.ToString());
                                }
                                else
                                {
                                    stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType().ToString());
                                }
                                IntArrary.Add(ctl.TabIndex);
                            }
                            break;

                        case "DevExpress.XtraEditors.CheckedComboBoxEdit":
                            CheckedComboBoxEdit ckb = new CheckedComboBoxEdit();
                            ckb = (CheckedComboBoxEdit)ct.Controls.Find(ctl.Name, false)[0];
                            if (ckb.Visible != false && ckb.Enabled != false && ckb.Properties.ReadOnly != true)
                            {
                                if (ctl.Tag != null)
                                {
                                    stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType().ToString() + "," + ctl.Tag.ToString());
                                }
                                else
                                {
                                    stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType().ToString());
                                }
                                IntArrary.Add(ctl.TabIndex);
                            }
                            break;

                        case "DevExpress.XtraEditors.DateEdit":
                            DateEdit dt = new DateEdit();
                            dt = (DateEdit)ct.Controls.Find(ctl.Name, false)[0];
                            if (dt.Visible != false && dt.Enabled != false && dt.Properties.ReadOnly != true)
                            {
                                if (ctl.Tag != null)
                                {
                                    stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType().ToString() + "," + ctl.Tag.ToString());
                                }
                                else
                                {
                                    stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType().ToString());
                                }
                                IntArrary.Add(ctl.TabIndex);
                            }
                            break;

                        case "DevExpress.XtraEditors.ComboBoxEdit":
                            ComboBoxEdit Comb = new ComboBoxEdit();
                            Comb = (ComboBoxEdit)ct.Controls.Find(ctl.Name, false)[0];
                            if (Comb.Visible != false && Comb.Enabled != false && Comb.Properties.ReadOnly != true)
                            {
                                if (ctl.Tag != null)
                                {
                                    stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType().ToString() + "," + ctl.Tag.ToString());
                                }
                                else
                                {
                                    stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType().ToString());
                                }
                                IntArrary.Add(ctl.TabIndex);
                            }
                            break;

                        case "DevExpress.XtraEditors.ImageComboBoxEdit":
                            ImageComboBoxEdit ImgCom = new ImageComboBoxEdit();
                            ImgCom = (ImageComboBoxEdit)ct.Controls.Find(ctl.Name, false)[0];
                            if (ImgCom.Visible != false && ImgCom.Enabled != false && ImgCom.Properties.ReadOnly != true)
                            {
                                if (ctl.Tag != null)
                                {
                                    stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType().ToString() + "," + ctl.Tag.ToString());
                                }
                                else
                                {
                                    stringArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name + "," + ctl.GetType().ToString());
                                }
                                IntArrary.Add(ctl.TabIndex);
                            }
                            break;

                        case "DevExpress.XtraEditors.LabelControl":
                            LabelControl lab = new LabelControl();
                            lab = (LabelControl)ct.Controls.Find(ctl.Name, false)[0];
                            if (lab.ForeColor == Color.Red)
                            {
                                CheckArray.Add(ctl.TabIndex.ToString() + "," + ctl.Name.Substring(3, ctl.Name.Length - 3) + "," + lab.Text.Trim());
                                IntCheckSaveArrary.Add(ctl.TabIndex);
                            }
                            break;

                        default:
                            break;
                    }
                }
                IntArrary.Sort();
                IntCheckSaveArrary.Sort();
                List<string> strArray = new List<string>();

                for (int i = 0; i < IntArrary.Count; i++)
                {
                    for (int j = 0; j < stringArray.Count; j++)
                    {
                        if (IntArrary[i].ToString() == stringArray[j].Split(',')[0].ToString())
                        {
                            strArray.Add(stringArray[j]);
                        }
                    }
                }
                for (int i = 0; i < strArray.Count; i++)
                {
                    StrCtrlMode = StrCtrlMode + strArray[i].Split(',')[1].ToString() + ",";
                    StrCtrlAdd = StrCtrlAdd + strArray[i].Split(',')[3].ToString() + ",";
                }
                for (int i = 0; i < IntCheckSaveArrary.Count; i++)
                {
                    for (int j = 0; j < CheckArray.Count; j++)
                    {
                        if (IntCheckSaveArrary[i].ToString() == CheckArray[j].Split(',')[0].ToString())
                        {
                            StringArraryCheckSave.Add(CheckArray[j]);
                        }
                    }
                }

                Values["GetControlInofArray"] = strArray;
                Values["GetControlInofo_CheckSave"] = StringArraryCheckSave;
                //Values["GetControlInofo_BtnMode"] = StringBtnMode;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Values;
        }

        /// <summary>获取当前控件按回车跳转到的下一个控件的ID的索引
        ///
        /// </summary>
        /// <param name="FocusCtlName"></param>
        /// <param name="ArrayStr"></param>
        /// <returns></returns>
        public string[] GetNextIndex(List<string> ArrayStr)
        {
            string[] NextStrArray;
            if (FocusedControl.Tag != null)
            {
                Nextindex = ArrayStr.IndexOf(FocusedControl.TabIndex.ToString() + "," + FocusedControl.Name + "," + FocusedControl.GetType() + "," + FocusedControl.Tag.ToString());
            }
            else
            {
                Nextindex = ArrayStr.IndexOf(FocusedControl.TabIndex.ToString() + "," + FocusedControl.Name + "," + FocusedControl.GetType());
            }

            if (Nextindex < StringArrary.Count - 1)
            {
                NextStrArray = StringArrary[Nextindex + 1].Split(',');
            }
            else
            {
                NextStrArray = StringArrary[ArrayStr.Count - 1].Split(',');
            }
            return NextStrArray;
        }

        /// <summary>回车跳转到当前控件所做的处理
        ///
        /// </summary>
        /// <param name="StringArrary"></param>
        /// <param name="ctl"></param>
        public void GetPreCtl(List<string> StringArrary, string[] Ctrl, Control ctl)
        {
            switch (Ctrl[2])
            {
                case "System.Windows.Forms.TextBox":
                    TextBox wintxt = new TextBox();
                    wintxt = (TextBox)ctl.Controls.Find(Ctrl[1], true)[0];
                    wintxt.Focus();
                    wintxt.Select();
                    break;

                case "DevExpress.XtraEditors.TextEdit":
                    TextEdit txt = new TextEdit();
                    txt = (TextEdit)ctl.Controls.Find(Ctrl[1], true)[0];
                    txt.Focus();
                    txt.Select();
                    break;

                case "DevExpress.XtraEditors.CheckEdit":
                    CheckEdit ce = new CheckEdit();
                    ce = (CheckEdit)ctl.Controls.Find(Ctrl[1], true)[0];
                    ce.Focus();
                    ce.Checked = true;
                    break;

                case "DevExpress.XtraEditors.MemoEdit":
                    MemoEdit mTxt = new MemoEdit();
                    mTxt = (MemoEdit)ctl.Controls.Find(Ctrl[1], false)[0];
                    mTxt.Focus();
                    mTxt.Select();
                    break;

                case "DevExpress.XtraEditors.SimpleButton":
                    SimpleButton btn = new SimpleButton();
                    btn = (SimpleButton)ctl.Controls.Find(Ctrl[1], false)[0];
                    btn.Focus();
                    btn.Select();
                    break;

                case "DevExpress.XtraEditors.LookUpEdit":
                    LookUpEdit dpl = new LookUpEdit();
                    dpl = (LookUpEdit)ctl.Controls.Find(Ctrl[1], false)[0];
                    dpl.Focus();
                    dpl.ShowPopup();
                    break;

                case "DevExpress.XtraEditors.CheckedComboBoxEdit":
                    CheckedComboBoxEdit ckcob = new CheckedComboBoxEdit();
                    ckcob = (CheckedComboBoxEdit)ctl.Controls.Find(Ctrl[1], false)[0];
                    ckcob.Focus();
                    ckcob.Select();
                    ckcob.ShowPopup();
                    break;

                case "DevExpress.XtraEditors.DateEdit":
                    DateEdit dt = new DateEdit();
                    dt = (DateEdit)ctl.Controls.Find(Ctrl[1], false)[0];
                    dt.Focus();
                    dt.ShowPopup();
                    break;

                case "DevExpress.XtraEditors.ComboBoxEdit":
                    ComboBoxEdit Comb = new ComboBoxEdit();
                    Comb = (ComboBoxEdit)ctl.Controls.Find(Ctrl[1], false)[0];
                    Comb.Focus();
                    Comb.ShowPopup();
                    break;

                case "DevExpress.XtraEditors.ImageComboBoxEdit":
                    ImageComboBoxEdit imgcom = new ImageComboBoxEdit();
                    imgcom = (ImageComboBoxEdit)ctl.Controls.Find(Ctrl[1], false)[0];
                    imgcom.Focus();
                    imgcom.Select();
                    imgcom.ShowPopup();
                    break;

                default:
                    break;
            }
        }

        /// <summary>根据True , False 设置编辑区启用弃用按钮文本显示，
        ///
        /// </summary>
        /// <param name="State"></param>
        /// <returns></returns>
        public string SetBtnDelTxt(string State)
        {
            return State = State == "True" || State == "1" ? "弃用&X" : "启用&X";
        }

        /// <summary>单表模式下的按钮状态
        ///
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="StrMode"></param>
        public void SetBtnMode_OneTable(Control ct, Control btnPanel, string StrMode)
        {
            switch (StrMode)
            {
                case "Add":
                    StrBtnMode = "Add";
                    for (int i = 0; i < StringBtnMode.Count; i++)
                    {
                        SimpleButton btn;
                        if (StringBtnMode[i].ToString() == "btnSave" || StringBtnMode[i].ToString() == "btnCancel" || StringBtnMode[i].ToString() == "btnUploadPicture")
                        {
                            btn = (SimpleButton)btnPanel.Controls.Find(StringBtnMode[i].ToString(), false)[0];
                            btn.Enabled = true;
                        }
                        else
                        {
                            btn = (SimpleButton)btnPanel.Controls.Find(StringBtnMode[i].ToString(), false)[0];
                            btn.Enabled = false;
                        }
                    }
                    DxCtlHelper.SetControlEnabled(ct, true, StrCtrlMode);
                    DxCtlHelper.SetControlEmpty(ct);
                    break;

                case "Edit":
                    StrBtnMode = "Edit";
                    for (int i = 0; i < StringBtnMode.Count; i++)
                    {
                        SimpleButton btn = new SimpleButton();
                        if (StringBtnMode[i].ToString() == "btnSave" || StringBtnMode[i].ToString() == "btnCancel" || StringBtnMode[i].ToString() == "btnUploadPicture")
                        {
                            btn = (SimpleButton)btnPanel.Controls.Find(StringBtnMode[i].ToString(), false)[0];
                            btn.Enabled = true;
                        }
                        else
                        {
                            btn = (SimpleButton)btnPanel.Controls.Find(StringBtnMode[i].ToString(), false)[0];
                            btn.Enabled = false;
                        }
                    }
                    DxCtlHelper.SetControlEnabled(ct, true, StrCtrlMode);
                    break;

                case "View":
                    StrBtnMode = "View";
                    for (int i = 0; i < StringBtnMode.Count; i++)
                    {
                        SimpleButton btn = new SimpleButton();
                        if (StringBtnMode[i].ToString() == "btnSave" || StringBtnMode[i].ToString() == "btnCancel" || StringBtnMode[i].ToString() == "btnUploadPicture")
                        {
                            btn = (SimpleButton)btnPanel.Controls.Find(StringBtnMode[i].ToString(), false)[0];
                            btn.Enabled = false;
                        }
                        else
                        {
                            btn = (SimpleButton)btnPanel.Controls.Find(StringBtnMode[i].ToString(), false)[0];
                            btn.Enabled = true;
                        }
                    }
                    DxCtlHelper.SetControlEnabled(ct, false, StrCtrlMode);
                    break;

                default:
                    break;
            }
        }

        /// <summary>树形单表模式下的按钮状态
        ///
        /// </summary>
        /// <param name="ct"></param>
        /// <param name="StrMode"></param>
        public void SetBtnMode_Tree(Control ct, Control btnPanel, string StrMode)
        {
            switch (StrMode)
            {
                case "Add":
                    StrBtnMode = "Add";
                    for (int i = 0; i < StringBtnMode.Count; i++)
                    {
                        SimpleButton btn = new SimpleButton();
                        if (StringBtnMode[i].ToString() == "btnSave" || StringBtnMode[i].ToString() == "btnCancel")
                        {
                            btn = (SimpleButton)btnPanel.Controls.Find(StringBtnMode[i].ToString(), false)[0];
                            btn.Enabled = true;
                        }
                        else
                        {
                            btn = (SimpleButton)btnPanel.Controls.Find(StringBtnMode[i].ToString(), false)[0];
                            btn.Enabled = false;
                        }
                    }
                    DxCtlHelper.SetControlEnabled(ct, true, StrCtrlMode);
                    DxCtlHelper.SetControlEmpty(ct);
                    break;

                case "Edit":
                    StrBtnMode = "Edit";
                    for (int i = 0; i < StringBtnMode.Count; i++)
                    {
                        SimpleButton btn = new SimpleButton();
                        if (StringBtnMode[i].ToString() == "btnSave" || StringBtnMode[i].ToString() == "btnCancel")
                        {
                            btn = (SimpleButton)btnPanel.Controls.Find(StringBtnMode[i].ToString(), false)[0];
                            btn.Enabled = true;
                        }
                        else
                        {
                            btn = (SimpleButton)btnPanel.Controls.Find(StringBtnMode[i].ToString(), false)[0];
                            btn.Enabled = false;
                        }
                    }
                    DxCtlHelper.SetControlEnabled(ct, true, StrCtrlMode);
                    break;

                case "View":
                    StrBtnMode = "View";
                    for (int i = 0; i < StringBtnMode.Count; i++)
                    {
                        SimpleButton btn = new SimpleButton();
                        if (StringBtnMode[i].ToString() == "btnSave" || StringBtnMode[i].ToString() == "btnCancel")
                        {
                            btn = (SimpleButton)btnPanel.Controls.Find(StringBtnMode[i].ToString(), false)[0];
                            btn.Enabled = false;
                        }
                        else
                        {
                            btn = (SimpleButton)btnPanel.Controls.Find(StringBtnMode[i].ToString(), false)[0];
                            btn.Enabled = true;
                        }
                    }
                    DxCtlHelper.SetControlEnabled(ct, false, StrCtrlMode);
                    break;

                default:
                    break;
            }
        }

        public void Txt_Enter(object sender, EventArgs e)
        {
            var control = sender as Control;
            if (control != null) StrFocusedContrName = control.Name;
            FocusedControl = sender as Control;
        }
    }
}