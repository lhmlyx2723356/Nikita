 namespace Nikita.Report.WinForm
{
    partial class MatrixDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.availableFieldsListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.columnFieldsListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rowFieldsListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.summarizedFieldsListBox = new System.Windows.Forms.ListBox();
            this.addColumnFieldButton = new System.Windows.Forms.Button();
            this.removeColumnFieldButton = new System.Windows.Forms.Button();
            this.removeRowFieldButton = new System.Windows.Forms.Button();
            this.addRowFieldButton = new System.Windows.Forms.Button();
            this.removeSummarizedFieldButton = new System.Windows.Forms.Button();
            this.addSummarizedFieldButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.upArrowButton = new System.Windows.Forms.Button();
            this.downArrowButton = new System.Windows.Forms.Button();
            this.applyButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Available Fields:";
            // 
            // availableFieldsListBox
            // 
            this.availableFieldsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.availableFieldsListBox.FormattingEnabled = true;
            this.availableFieldsListBox.Location = new System.Drawing.Point(15, 26);
            this.availableFieldsListBox.Name = "availableFieldsListBox";
            this.availableFieldsListBox.Size = new System.Drawing.Size(120, 212);
            this.availableFieldsListBox.Sorted = true;
            this.availableFieldsListBox.TabIndex = 1;
            this.availableFieldsListBox.SelectedIndexChanged += new System.EventHandler(this.availableFieldsListBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Column Fields:";
            // 
            // columnFieldsListBox
            // 
            this.columnFieldsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.columnFieldsListBox.FormattingEnabled = true;
            this.columnFieldsListBox.Location = new System.Drawing.Point(239, 26);
            this.columnFieldsListBox.Name = "columnFieldsListBox";
            this.columnFieldsListBox.Size = new System.Drawing.Size(120, 56);
            this.columnFieldsListBox.TabIndex = 3;
            this.columnFieldsListBox.SelectedIndexChanged += new System.EventHandler(this.columnFieldsListBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Row Fields:";
            // 
            // rowFieldsListBox
            // 
            this.rowFieldsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rowFieldsListBox.FormattingEnabled = true;
            this.rowFieldsListBox.Location = new System.Drawing.Point(239, 101);
            this.rowFieldsListBox.Name = "rowFieldsListBox";
            this.rowFieldsListBox.Size = new System.Drawing.Size(120, 56);
            this.rowFieldsListBox.TabIndex = 5;
            this.rowFieldsListBox.SelectedIndexChanged += new System.EventHandler(this.rowFieldsListBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Summarized Fields:";
            // 
            // summarizedFieldsListBox
            // 
            this.summarizedFieldsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.summarizedFieldsListBox.FormattingEnabled = true;
            this.summarizedFieldsListBox.Location = new System.Drawing.Point(239, 176);
            this.summarizedFieldsListBox.Name = "summarizedFieldsListBox";
            this.summarizedFieldsListBox.Size = new System.Drawing.Size(120, 56);
            this.summarizedFieldsListBox.TabIndex = 7;
            this.summarizedFieldsListBox.SelectedIndexChanged += new System.EventHandler(this.summarizedFieldsListBox_SelectedIndexChanged);
            // 
            // addColumnFieldButton
            // 
            this.addColumnFieldButton.Location = new System.Drawing.Point(156, 26);
            this.addColumnFieldButton.Name = "addColumnFieldButton";
            this.addColumnFieldButton.Size = new System.Drawing.Size(59, 23);
            this.addColumnFieldButton.TabIndex = 8;
            this.addColumnFieldButton.Text = ">";
            this.addColumnFieldButton.UseVisualStyleBackColor = true;
            this.addColumnFieldButton.Click += new System.EventHandler(this.addColumnFieldButton_Click);
            // 
            // removeColumnFieldButton
            // 
            this.removeColumnFieldButton.Location = new System.Drawing.Point(156, 56);
            this.removeColumnFieldButton.Name = "removeColumnFieldButton";
            this.removeColumnFieldButton.Size = new System.Drawing.Size(59, 23);
            this.removeColumnFieldButton.TabIndex = 9;
            this.removeColumnFieldButton.Text = "<";
            this.removeColumnFieldButton.UseVisualStyleBackColor = true;
            this.removeColumnFieldButton.Click += new System.EventHandler(this.removeColumnFieldButton_Click);
            // 
            // removeRowFieldButton
            // 
            this.removeRowFieldButton.Location = new System.Drawing.Point(156, 131);
            this.removeRowFieldButton.Name = "removeRowFieldButton";
            this.removeRowFieldButton.Size = new System.Drawing.Size(59, 23);
            this.removeRowFieldButton.TabIndex = 11;
            this.removeRowFieldButton.Text = "<";
            this.removeRowFieldButton.UseVisualStyleBackColor = true;
            this.removeRowFieldButton.Click += new System.EventHandler(this.removeRowFieldButton_Click);
            // 
            // addRowFieldButton
            // 
            this.addRowFieldButton.Location = new System.Drawing.Point(156, 101);
            this.addRowFieldButton.Name = "addRowFieldButton";
            this.addRowFieldButton.Size = new System.Drawing.Size(59, 23);
            this.addRowFieldButton.TabIndex = 10;
            this.addRowFieldButton.Text = ">";
            this.addRowFieldButton.UseVisualStyleBackColor = true;
            this.addRowFieldButton.Click += new System.EventHandler(this.addRowFieldButton_Click);
            // 
            // removeSummarizedFieldButton
            // 
            this.removeSummarizedFieldButton.Location = new System.Drawing.Point(156, 206);
            this.removeSummarizedFieldButton.Name = "removeSummarizedFieldButton";
            this.removeSummarizedFieldButton.Size = new System.Drawing.Size(59, 23);
            this.removeSummarizedFieldButton.TabIndex = 13;
            this.removeSummarizedFieldButton.Text = "<";
            this.removeSummarizedFieldButton.UseVisualStyleBackColor = true;
            this.removeSummarizedFieldButton.Click += new System.EventHandler(this.removeSummarizedFieldButton_Click);
            // 
            // addSummarizedFieldButton
            // 
            this.addSummarizedFieldButton.Location = new System.Drawing.Point(156, 176);
            this.addSummarizedFieldButton.Name = "addSummarizedFieldButton";
            this.addSummarizedFieldButton.Size = new System.Drawing.Size(59, 23);
            this.addSummarizedFieldButton.TabIndex = 12;
            this.addSummarizedFieldButton.Text = ">";
            this.addSummarizedFieldButton.UseVisualStyleBackColor = true;
            this.addSummarizedFieldButton.Click += new System.EventHandler(this.addSummarizedFieldButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(329, 259);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 14;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(248, 259);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 15;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // upArrowButton
            // 
            this.upArrowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            //this.upArrowButton.Image = global::DynamicMatrix.Properties.Resources.UpArrow;
            this.upArrowButton.Location = new System.Drawing.Point(376, 102);
            this.upArrowButton.Name = "upArrowButton";
            this.upArrowButton.Size = new System.Drawing.Size(28, 23);
            this.upArrowButton.TabIndex = 16;
            this.upArrowButton.UseVisualStyleBackColor = true;
            this.upArrowButton.Click += new System.EventHandler(this.upArrowButton_Click);
            // 
            // downArrowButton
            // 
            this.downArrowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            //   this.downArrowButton.Image = global::DynamicMatrix.Properties.Resources.DownArrow;
            this.downArrowButton.Location = new System.Drawing.Point(376, 131);
            this.downArrowButton.Name = "downArrowButton";
            this.downArrowButton.Size = new System.Drawing.Size(28, 23);
            this.downArrowButton.TabIndex = 17;
            this.downArrowButton.UseVisualStyleBackColor = true;
            this.downArrowButton.Click += new System.EventHandler(this.downArrowButton_Click);
            // 
            // applyButton
            // 
            this.applyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.applyButton.Location = new System.Drawing.Point(167, 259);
            this.applyButton.Name = "applyButton";
            this.applyButton.Size = new System.Drawing.Size(75, 23);
            this.applyButton.TabIndex = 18;
            this.applyButton.Text = "Apply";
            this.applyButton.UseVisualStyleBackColor = true;
            this.applyButton.Click += new System.EventHandler(this.applyButton_Click);
            // 
            // MatrixDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(416, 294);
            this.Controls.Add(this.applyButton);
            this.Controls.Add(this.downArrowButton);
            this.Controls.Add(this.upArrowButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.removeSummarizedFieldButton);
            this.Controls.Add(this.addSummarizedFieldButton);
            this.Controls.Add(this.removeRowFieldButton);
            this.Controls.Add(this.addRowFieldButton);
            this.Controls.Add(this.removeColumnFieldButton);
            this.Controls.Add(this.addColumnFieldButton);
            this.Controls.Add(this.summarizedFieldsListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rowFieldsListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.columnFieldsListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.availableFieldsListBox);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(424, 325);
            this.Name = "MatrixDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Matrix";
            this.Load += new System.EventHandler(this.MatrixDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox availableFieldsListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox columnFieldsListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox rowFieldsListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox summarizedFieldsListBox;
        private System.Windows.Forms.Button addColumnFieldButton;
        private System.Windows.Forms.Button removeColumnFieldButton;
        private System.Windows.Forms.Button removeRowFieldButton;
        private System.Windows.Forms.Button addRowFieldButton;
        private System.Windows.Forms.Button removeSummarizedFieldButton;
        private System.Windows.Forms.Button addSummarizedFieldButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button upArrowButton;
        private System.Windows.Forms.Button downArrowButton;
        private System.Windows.Forms.Button applyButton;
    }
}