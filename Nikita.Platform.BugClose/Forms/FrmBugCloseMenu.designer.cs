namespace Nikita.Platform.BugClose
{
    partial class FrmBugCloseMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBugCloseMenu));
            this.OutLookBarMenu = new Nikita.WinForm.ExtendControl.WinControls.OutlookBar();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // OutLookBarMenu
            // 
            this.OutLookBarMenu.AnimationSpeed = 20;
            this.OutLookBarMenu.BackgroundBitmap = null;
            this.OutLookBarMenu.BorderType = Nikita.WinForm.ExtendControl.WinControls.BorderType.FixedSingle;
            this.OutLookBarMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutLookBarMenu.FlatArrowButtons = false;
            this.OutLookBarMenu.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.OutLookBarMenu.LeftTopColor = System.Drawing.Color.Empty;
            this.OutLookBarMenu.Location = new System.Drawing.Point(0, 0);
            this.OutLookBarMenu.Name = "OutLookBarMenu";
            this.OutLookBarMenu.RightBottomColor = System.Drawing.Color.Empty;
            this.OutLookBarMenu.Size = new System.Drawing.Size(154, 350);
            this.OutLookBarMenu.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Bitmap.ico");
            this.imageList1.Images.SetKeyName(1, "BlankIcon.ico");
            this.imageList1.Images.SetKeyName(2, "ClosedFolder.ICO");
            this.imageList1.Images.SetKeyName(3, "CSFile.ico");
            this.imageList1.Images.SetKeyName(4, "CSProject.ico");
            this.imageList1.Images.SetKeyName(5, "database.ico");
            // 
            // FrmBugCloseMenu
            // 
            this.ClientSize = new System.Drawing.Size(154, 350);
            this.Controls.Add(this.OutLookBarMenu);
            this.DockAreas = ((Nikita.WinForm.ExtendControl.DockAreas)((((Nikita.WinForm.ExtendControl.DockAreas.DockLeft | Nikita.WinForm.ExtendControl.DockAreas.DockRight) 
            | Nikita.WinForm.ExtendControl.DockAreas.DockTop) 
            | Nikita.WinForm.ExtendControl.DockAreas.DockBottom)));
            this.Font = new System.Drawing.Font("Î¢ÈíÑÅºÚ", 9F);
            this.HideOnClose = true;
            this.Name = "FrmBugCloseMenu";
            this.ShowHint = Nikita.WinForm.ExtendControl.DockState.DockLeft;
            this.ShowIcon = false;
            this.TabText = "²Ëµ¥";
            this.Text = "²Ëµ¥";
            this.ResumeLayout(false);

        }
        #endregion

        private WinForm.ExtendControl.WinControls.OutlookBar OutLookBarMenu;
        private System.Windows.Forms.ImageList imageList1;

    }
}