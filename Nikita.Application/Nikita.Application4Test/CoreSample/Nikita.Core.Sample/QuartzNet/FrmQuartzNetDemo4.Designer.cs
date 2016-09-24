namespace Nikita.Core.Sample
{
    partial class FrmQuartzNetDemo4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTest1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTest1
            // 
            this.btnTest1.Location = new System.Drawing.Point(70, 119);
            this.btnTest1.Name = "btnTest1";
            this.btnTest1.Size = new System.Drawing.Size(144, 23);
            this.btnTest1.TabIndex = 3;
            this.btnTest1.Text = "测试QuartzNet";
            this.btnTest1.UseVisualStyleBackColor = true;
            this.btnTest1.Click += new System.EventHandler(this.btnTest1_Click);
            // 
            // FrmQuartzNetDemo4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnTest1);
            this.Name = "FrmQuartzNetDemo4";
            this.Text = "FrmQuartzNetDemo4";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTest1;
    }
}