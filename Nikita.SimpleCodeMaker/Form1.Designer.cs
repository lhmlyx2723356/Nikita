namespace Nikita.Assist.SimpleCodeMaker
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btngen = new System.Windows.Forms.Button();
            this.btnmodelyl = new System.Windows.Forms.Button();
            this.btndalyl = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtoutput = new System.Windows.Forms.TextBox();
            this.txtfront = new System.Windows.Forms.TextBox();
            this.txtnamespace = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rad2 = new System.Windows.Forms.RadioButton();
            this.rad1 = new System.Windows.Forms.RadioButton();
            this.rad0 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnalltoleft = new System.Windows.Forms.Button();
            this.btntoleft = new System.Windows.Forms.Button();
            this.btnalltoright = new System.Windows.Forms.Button();
            this.btntoright = new System.Windows.Forms.Button();
            this.lsbright = new System.Windows.Forms.ListBox();
            this.lsbleft = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnlink = new System.Windows.Forms.Button();
            this.cobdbtype = new System.Windows.Forms.ComboBox();
            this.txtconnstr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtyl = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.btngen);
            this.splitContainer1.Panel1.Controls.Add(this.btnmodelyl);
            this.splitContainer1.Panel1.Controls.Add(this.btndalyl);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtyl);
            this.splitContainer1.Size = new System.Drawing.Size(1194, 669);
            this.splitContainer1.SplitterDistance = 499;
            this.splitContainer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(143, 634);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "生成数据库文档";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(18, 581);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 36);
            this.label6.TabIndex = 1;
            this.label6.Text = "数据表创建规则:\r\n1.每个表都必须得用id字段\r\n2.id主键自增";
            // 
            // btngen
            // 
            this.btngen.Location = new System.Drawing.Point(412, 634);
            this.btngen.Name = "btngen";
            this.btngen.Size = new System.Drawing.Size(75, 23);
            this.btngen.TabIndex = 4;
            this.btngen.Text = "生成代码";
            this.btngen.UseVisualStyleBackColor = true;
            this.btngen.Click += new System.EventHandler(this.btngen_Click);
            // 
            // btnmodelyl
            // 
            this.btnmodelyl.Location = new System.Drawing.Point(331, 634);
            this.btnmodelyl.Name = "btnmodelyl";
            this.btnmodelyl.Size = new System.Drawing.Size(75, 23);
            this.btnmodelyl.TabIndex = 4;
            this.btnmodelyl.Text = "Model预览";
            this.btnmodelyl.UseVisualStyleBackColor = true;
            this.btnmodelyl.Click += new System.EventHandler(this.btnmodelyl_Click);
            // 
            // btndalyl
            // 
            this.btndalyl.Location = new System.Drawing.Point(250, 634);
            this.btndalyl.Name = "btndalyl";
            this.btndalyl.Size = new System.Drawing.Size(75, 23);
            this.btndalyl.TabIndex = 4;
            this.btndalyl.Text = "DAL预览";
            this.btndalyl.UseVisualStyleBackColor = true;
            this.btndalyl.Click += new System.EventHandler(this.btndalyl_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtoutput);
            this.groupBox4.Controls.Add(this.txtfront);
            this.groupBox4.Controls.Add(this.txtnamespace);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Location = new System.Drawing.Point(12, 465);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(475, 100);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "其他设置";
            // 
            // txtoutput
            // 
            this.txtoutput.Location = new System.Drawing.Point(107, 73);
            this.txtoutput.Name = "txtoutput";
            this.txtoutput.Size = new System.Drawing.Size(168, 21);
            this.txtoutput.TabIndex = 1;
            // 
            // txtfront
            // 
            this.txtfront.Location = new System.Drawing.Point(107, 50);
            this.txtfront.Name = "txtfront";
            this.txtfront.Size = new System.Drawing.Size(168, 21);
            this.txtfront.TabIndex = 1;
            // 
            // txtnamespace
            // 
            this.txtnamespace.Location = new System.Drawing.Point(107, 25);
            this.txtnamespace.Name = "txtnamespace";
            this.txtnamespace.Size = new System.Drawing.Size(168, 21);
            this.txtnamespace.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "生成目录:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(54, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "表前缀:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "命名空间:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rad2);
            this.groupBox3.Controls.Add(this.rad1);
            this.groupBox3.Controls.Add(this.rad0);
            this.groupBox3.Location = new System.Drawing.Point(12, 398);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(475, 61);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "代码生成方式";
            // 
            // rad2
            // 
            this.rad2.AutoSize = true;
            this.rad2.Location = new System.Drawing.Point(257, 33);
            this.rad2.Name = "rad2";
            this.rad2.Size = new System.Drawing.Size(137, 16);
            this.rad2.TabIndex = 1;
            this.rad2.Text = "基于wcf数据库操作类";
            this.rad2.UseVisualStyleBackColor = true;
            // 
            // rad1
            // 
            this.rad1.AutoSize = true;
            this.rad1.Checked = true;
            this.rad1.Location = new System.Drawing.Point(75, 33);
            this.rad1.Name = "rad1";
            this.rad1.Size = new System.Drawing.Size(155, 16);
            this.rad1.TabIndex = 0;
            this.rad1.TabStop = true;
            this.rad1.Text = "基于UsTeam数据库操作类";
            this.rad1.UseVisualStyleBackColor = true;
            // 
            // rad0
            // 
            this.rad0.AutoSize = true;
            this.rad0.Location = new System.Drawing.Point(81, 8);
            this.rad0.Name = "rad0";
            this.rad0.Size = new System.Drawing.Size(107, 16);
            this.rad0.TabIndex = 0;
            this.rad0.Text = "基于微软企业库";
            this.rad0.UseVisualStyleBackColor = true;
            this.rad0.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnalltoleft);
            this.groupBox2.Controls.Add(this.btntoleft);
            this.groupBox2.Controls.Add(this.btnalltoright);
            this.groupBox2.Controls.Add(this.btntoright);
            this.groupBox2.Controls.Add(this.lsbright);
            this.groupBox2.Controls.Add(this.lsbleft);
            this.groupBox2.Location = new System.Drawing.Point(12, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(475, 288);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "选择操作表";
            // 
            // btnalltoleft
            // 
            this.btnalltoleft.Location = new System.Drawing.Point(200, 195);
            this.btnalltoleft.Name = "btnalltoleft";
            this.btnalltoleft.Size = new System.Drawing.Size(75, 23);
            this.btnalltoleft.TabIndex = 1;
            this.btnalltoleft.Text = "< <";
            this.btnalltoleft.UseVisualStyleBackColor = true;
            this.btnalltoleft.Click += new System.EventHandler(this.btnalltoleft_Click);
            // 
            // btntoleft
            // 
            this.btntoleft.Location = new System.Drawing.Point(200, 148);
            this.btntoleft.Name = "btntoleft";
            this.btntoleft.Size = new System.Drawing.Size(75, 23);
            this.btntoleft.TabIndex = 1;
            this.btntoleft.Text = "<";
            this.btntoleft.UseVisualStyleBackColor = true;
            this.btntoleft.Click += new System.EventHandler(this.btntoleft_Click);
            // 
            // btnalltoright
            // 
            this.btnalltoright.Location = new System.Drawing.Point(200, 96);
            this.btnalltoright.Name = "btnalltoright";
            this.btnalltoright.Size = new System.Drawing.Size(75, 23);
            this.btnalltoright.TabIndex = 1;
            this.btnalltoright.Text = "> >";
            this.btnalltoright.UseVisualStyleBackColor = true;
            this.btnalltoright.Click += new System.EventHandler(this.btnalltoright_Click);
            // 
            // btntoright
            // 
            this.btntoright.Location = new System.Drawing.Point(200, 46);
            this.btntoright.Name = "btntoright";
            this.btntoright.Size = new System.Drawing.Size(75, 23);
            this.btntoright.TabIndex = 1;
            this.btntoright.Text = ">";
            this.btntoright.UseVisualStyleBackColor = true;
            this.btntoright.Click += new System.EventHandler(this.btntoright_Click);
            // 
            // lsbright
            // 
            this.lsbright.FormattingEnabled = true;
            this.lsbright.ItemHeight = 12;
            this.lsbright.Location = new System.Drawing.Point(308, 20);
            this.lsbright.Name = "lsbright";
            this.lsbright.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbright.Size = new System.Drawing.Size(155, 256);
            this.lsbright.TabIndex = 0;
            this.lsbright.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsbright_MouseDoubleClick);
            // 
            // lsbleft
            // 
            this.lsbleft.FormattingEnabled = true;
            this.lsbleft.ItemHeight = 12;
            this.lsbleft.Location = new System.Drawing.Point(14, 20);
            this.lsbleft.Name = "lsbleft";
            this.lsbleft.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lsbleft.Size = new System.Drawing.Size(155, 256);
            this.lsbleft.TabIndex = 0;
            this.lsbleft.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lsbleft_MouseDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnlink);
            this.groupBox1.Controls.Add(this.cobdbtype);
            this.groupBox1.Controls.Add(this.txtconnstr);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(475, 86);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库设置";
            // 
            // btnlink
            // 
            this.btnlink.Location = new System.Drawing.Point(378, 20);
            this.btnlink.Name = "btnlink";
            this.btnlink.Size = new System.Drawing.Size(75, 23);
            this.btnlink.TabIndex = 3;
            this.btnlink.Text = "连接";
            this.btnlink.UseVisualStyleBackColor = true;
            this.btnlink.Click += new System.EventHandler(this.btnlink_Click);
            // 
            // cobdbtype
            // 
            this.cobdbtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cobdbtype.FormattingEnabled = true;
            this.cobdbtype.Items.AddRange(new object[] {
            "SQL Server",
            "MySQL",
            "Access",
            "Sqlite"});
            this.cobdbtype.Location = new System.Drawing.Point(119, 26);
            this.cobdbtype.Name = "cobdbtype";
            this.cobdbtype.Size = new System.Drawing.Size(111, 20);
            this.cobdbtype.TabIndex = 2;
            this.cobdbtype.SelectedIndexChanged += new System.EventHandler(this.cobdbtype_SelectedIndexChanged);
            // 
            // txtconnstr
            // 
            this.txtconnstr.Location = new System.Drawing.Point(119, 52);
            this.txtconnstr.Name = "txtconnstr";
            this.txtconnstr.Size = new System.Drawing.Size(334, 21);
            this.txtconnstr.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "数据库连接字符串:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库类型:";
            // 
            // txtyl
            // 
            this.txtyl.BackColor = System.Drawing.Color.White;
            this.txtyl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtyl.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtyl.Location = new System.Drawing.Point(0, 0);
            this.txtyl.Multiline = true;
            this.txtyl.Name = "txtyl";
            this.txtyl.ReadOnly = true;
            this.txtyl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtyl.Size = new System.Drawing.Size(689, 667);
            this.txtyl.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 669);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "UsTeam代码生成器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cobdbtype;
        private System.Windows.Forms.TextBox txtconnstr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtyl;
        private System.Windows.Forms.Button btnlink;
        private System.Windows.Forms.Button btngen;
        private System.Windows.Forms.Button btnmodelyl;
        private System.Windows.Forms.Button btndalyl;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtoutput;
        private System.Windows.Forms.TextBox txtfront;
        private System.Windows.Forms.TextBox txtnamespace;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rad1;
        private System.Windows.Forms.RadioButton rad0;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnalltoleft;
        private System.Windows.Forms.Button btntoleft;
        private System.Windows.Forms.Button btnalltoright;
        private System.Windows.Forms.Button btntoright;
        private System.Windows.Forms.ListBox lsbright;
        private System.Windows.Forms.ListBox lsbleft;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rad2;
    }
}

