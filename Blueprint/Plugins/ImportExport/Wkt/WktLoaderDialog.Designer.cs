namespace Blueprint.ImportExport.Wkt.WktLoader
{
    partial class WktLoaderDialog
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
            this.scaleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.flipYAxisCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.wktFileNameEdit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.incermentalCoordinatesCheckbox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.wktFreeTextEdit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scaleNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // scaleNumericUpDown
            // 
            this.scaleNumericUpDown.Location = new System.Drawing.Point(85, 331);
            this.scaleNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.scaleNumericUpDown.Name = "scaleNumericUpDown";
            this.scaleNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.scaleNumericUpDown.TabIndex = 0;
            this.scaleNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // flipYAxisCheckBox
            // 
            this.flipYAxisCheckBox.AutoSize = true;
            this.flipYAxisCheckBox.Location = new System.Drawing.Point(10, 284);
            this.flipYAxisCheckBox.Name = "flipYAxisCheckBox";
            this.flipYAxisCheckBox.Size = new System.Drawing.Size(73, 17);
            this.flipYAxisCheckBox.TabIndex = 1;
            this.flipYAxisCheckBox.Text = "Flip Y-axis";
            this.flipYAxisCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 333);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Scale devider";
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(686, 363);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(767, 363);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // wktFileNameEdit
            // 
            this.wktFileNameEdit.Location = new System.Drawing.Point(166, 12);
            this.wktFileNameEdit.Name = "wktFileNameEdit";
            this.wktFileNameEdit.Size = new System.Drawing.Size(595, 20);
            this.wktFileNameEdit.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "WKT file name";
            // 
            // incermentalCoordinatesCheckbox
            // 
            this.incermentalCoordinatesCheckbox.AutoSize = true;
            this.incermentalCoordinatesCheckbox.Location = new System.Drawing.Point(10, 307);
            this.incermentalCoordinatesCheckbox.Name = "incermentalCoordinatesCheckbox";
            this.incermentalCoordinatesCheckbox.Size = new System.Drawing.Size(139, 17);
            this.incermentalCoordinatesCheckbox.TabIndex = 7;
            this.incermentalCoordinatesCheckbox.Text = "Incermental coordinates";
            this.incermentalCoordinatesCheckbox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(767, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // wktFreeTextEdit
            // 
            this.wktFreeTextEdit.Location = new System.Drawing.Point(166, 38);
            this.wktFreeTextEdit.Multiline = true;
            this.wktFreeTextEdit.Name = "wktFreeTextEdit";
            this.wktFreeTextEdit.Size = new System.Drawing.Size(676, 232);
            this.wktFreeTextEdit.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "WKT free text";
            // 
            // WktLoaderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 397);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.wktFreeTextEdit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.incermentalCoordinatesCheckbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.wktFileNameEdit);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flipYAxisCheckBox);
            this.Controls.Add(this.scaleNumericUpDown);
            this.Name = "WktLoaderDialog";
            this.Text = "Import Well Known Text";
            ((System.ComponentModel.ISupportInitialize)(this.scaleNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown scaleNumericUpDown;
        private System.Windows.Forms.CheckBox flipYAxisCheckBox;
        private System.Windows.Forms.Label label1;
		//private System.Windows.Forms.TextBox wktTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox wktFileNameEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox incermentalCoordinatesCheckbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox wktFreeTextEdit;
        private System.Windows.Forms.Label label3;
    }
}