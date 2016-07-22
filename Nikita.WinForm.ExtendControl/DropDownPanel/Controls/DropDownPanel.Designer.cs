namespace Nikita.WinForm.ExtendControl
{
	partial class DropDownPanel
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.combo = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// combo
			// 
			this.combo.DropDownHeight = 1;
			this.combo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combo.FormattingEnabled = true;
			this.combo.IntegralHeight = false;
			this.combo.Location = new System.Drawing.Point(0, 0);
			this.combo.Name = "combo";
			this.combo.Size = new System.Drawing.Size(86, 21);
			this.combo.TabIndex = 0;
			this.combo.DropDown += new System.EventHandler(this.Combo_DropDown);
			// 
			// DropDownPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.combo);
			this.Name = "DropDownPanel";
			this.Size = new System.Drawing.Size(105, 32);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox combo;
	}
}
