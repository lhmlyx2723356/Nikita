using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    public partial class DataNavigator : UserControl
    {
        private int m_CurrentIndex = 0;

        public DataNavigator()
        {
            InitializeComponent();
        }

        // 步骤1，定义delegate对象
        public delegate void PostionChangedEventHandler(object sender, EventArgs e);

        public event PostionChangedEventHandler PositionChanged;

        //当前的位置

        /// <summary>
        /// 获取或设置索引值
        /// </summary>
        public int CurrentIndex
        {
            get { return m_CurrentIndex; }
            set
            {
                m_CurrentIndex = value;
                ChangePosition(value);
            }
        }

        public List<string> ListInfo { get; set; }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            ChangePosition(0);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            ChangePosition(ListInfo.Count - 1);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            ChangePosition(m_CurrentIndex + 1);
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            ChangePosition(m_CurrentIndex - 1);
        }

        private void ChangePosition(int newPos)
        {
            if (ListInfo == null)
            {
                return;
            }
            int count = ListInfo.Count;
            if (count == 0)
            {
                EnableControl(false);
                this.txtInfo.Text = "";
            }
            else
            {
                EnableControl(true);

                newPos = (newPos < 0) ? 0 : newPos;
                m_CurrentIndex = ((count - 1) > newPos) ? newPos : (count - 1);
                this.btnPrevious.Enabled = (m_CurrentIndex > 0);
                this.btnNext.Enabled = m_CurrentIndex < (count - 1);
                this.txtInfo.Text = string.Format("{0}/{1}", m_CurrentIndex + 1, count);

                if (PositionChanged != null)
                {
                    PositionChanged(this, new EventArgs());
                }
            }
        }

        private void EnableControl(bool enable)
        {
            this.btnFirst.Enabled = enable;
            this.btnLast.Enabled = enable;
            this.btnNext.Enabled = enable;
            this.btnPrevious.Enabled = enable;
        }
    }
}