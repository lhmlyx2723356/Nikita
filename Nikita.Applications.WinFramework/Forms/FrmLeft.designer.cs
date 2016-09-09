using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Applications.WinFramework
{
    partial class FrmLeft
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
            this.SuspendLayout();
            // 
            // FrmLeft
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.ClientSize = new System.Drawing.Size(208, 350);
            this.DockAreas = ((DockAreas)((((DockAreas.DockLeft | DockAreas.DockRight) 
            | DockAreas.DockTop) 
            | DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F);
            this.HideOnClose = true;
            this.Name = "FrmLeft";
            this.Padding = new System.Windows.Forms.Padding(0, 24, 0, 1);
            this.ShowHint = DockState.DockLeft;
            this.ShowIcon = false;
            this.TabText = "²Ëµ¥";
            this.Text = "²Ëµ¥";
            this.ResumeLayout(false);

        }
        #endregion

    }
}