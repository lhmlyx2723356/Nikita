using System.Collections.Generic;
using System;
using System.Linq;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
 
namespace  Nikita.Assist.CodeMaker
{
    partial class  FrmTestNestQuery : System.Windows.Forms.Form
    { 
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }
        private System.ComponentModel.Container components = null;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
this.lblQueryDepartmentName = new System.Windows.Forms.Label();
            this.txtQueryDepartmentName = new System.Windows.Forms.TextBox();
this.lblQuerySortnum = new System.Windows.Forms.Label();
            this.txtQuerySortnum = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.panelView = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelView);
            this.splitContainer1.Size = new System.Drawing.Size(784, 561);
            this.splitContainer1.SplitterDistance = 51;
            this.splitContainer1.TabIndex = 24;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lblQueryDepartmentName);
            this.splitContainer2.Panel1.Controls.Add(this.txtQueryDepartmentName);
            this.splitContainer2.Panel1.Controls.Add(this.lblQuerySortnum);
            this.splitContainer2.Panel1.Controls.Add(this.txtQuerySortnum);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.btnLoad);
            this.splitContainer2.Size = new System.Drawing.Size(784, 51);
            this.splitContainer2.SplitterDistance = 706;
            this.splitContainer2.TabIndex = 0;
     this.lblQueryDepartmentName.Location = new System.Drawing.Point(15, 15);
            this.lblQueryDepartmentName.Name = "lblQueryDepartmentName";
            this.lblQueryDepartmentName.Size = new System.Drawing.Size(50, 16);
            this.lblQueryDepartmentName.TabIndex = 1;
            this.lblQueryDepartmentName.Text ="部门名称";
            // 
            // txtQueryDepartmentName
            // 
            this.txtQueryDepartmentName.Location = new System.Drawing.Point(70, 15);
            this.txtQueryDepartmentName.Name =  "txtQueryDepartmentName";
            this.txtQueryDepartmentName.Size = new System.Drawing.Size(130, 20);
            this.txtQueryDepartmentName.TabIndex = 1;

     this.lblQuerySortnum.Location = new System.Drawing.Point(205, 15);
            this.lblQuerySortnum.Name = "lblQuerySortnum";
            this.lblQuerySortnum.Size = new System.Drawing.Size(50, 16);
            this.lblQuerySortnum.TabIndex = 1;
            this.lblQuerySortnum.Text ="排序";
            // 
            // txtQuerySortnum
            // 
            this.txtQuerySortnum.Location = new System.Drawing.Point(260, 15);
            this.txtQuerySortnum.Name =  "txtQuerySortnum";
            this.txtQuerySortnum.Size = new System.Drawing.Size(130, 20);
            this.txtQuerySortnum.TabIndex = 5;

            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.FlatAppearance.BorderColor = System.Drawing.Color.LightSkyBlue;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Location = new System.Drawing.Point(8, 7);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(55, 33);
            this.btnLoad.TabIndex = 23;
            this.btnLoad.Text = "查询";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // panelView
            // 
            this.panelView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(0, 0);
            this.panelView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelView.Name = "panelView";
            this.panelView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panelView.Size = new System.Drawing.Size(784, 506);
            this.panelView.TabIndex = 24;
            // 
            // FrmNestQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmTestNestQuery";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master-Detail";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        private SplitContainer splitContainer1;
        internal Panel panelView;
        private SplitContainer splitContainer2;
        internal Button btnLoad;
        public  System.Windows.Forms.Label lblQueryDepartmentName;
        public System.Windows.Forms.TextBox  txtQueryDepartmentName;
        public  System.Windows.Forms.Label lblQuerySortnum;
        public System.Windows.Forms.TextBox  txtQuerySortnum;
    } 
}
