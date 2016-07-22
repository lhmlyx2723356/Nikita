namespace Nikita.Applications.WinFramework
{
    partial class ToolWindow
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
            this.components = new System.ComponentModel.Container();
            this.SuspendLayout();
            // 
            // ToolWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 246);
            this.DockAreas = ((Nikita.WinForm.ExtendControl.DockAreas)(((((Nikita.WinForm.ExtendControl.DockAreas.Float | Nikita.WinForm.ExtendControl.DockAreas.DockLeft) 
            | Nikita.WinForm.ExtendControl.DockAreas.DockRight) 
            | Nikita.WinForm.ExtendControl.DockAreas.DockTop) 
            | Nikita.WinForm.ExtendControl.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("ËÎÌו", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ToolWindow";
            this.TabText = "ToolWindow";
            this.Text = "ToolWindow";
            this.ResumeLayout(false);

        }

        #endregion

    }
}