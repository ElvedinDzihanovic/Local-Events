namespace LocalEventsSeminarski_UI.Lokacija
{
    partial class EditForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nazivInput = new System.Windows.Forms.TextBox();
            this.adresaInput = new System.Windows.Forms.TextBox();
            this.opisInput = new System.Windows.Forms.RichTextBox();
            this.tipSelect = new System.Windows.Forms.ComboBox();
            this.gradSelect = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveChangesBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.kapacitetInput = new System.Windows.Forms.NumericUpDown();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.averageRatingInput = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kapacitetInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "City";
            // 
            // nazivInput
            // 
            this.nazivInput.Location = new System.Drawing.Point(89, 64);
            this.nazivInput.Name = "nazivInput";
            this.nazivInput.Size = new System.Drawing.Size(147, 20);
            this.nazivInput.TabIndex = 5;
            this.nazivInput.Validating += new System.ComponentModel.CancelEventHandler(this.nazivInput_Validating);
            // 
            // adresaInput
            // 
            this.adresaInput.Location = new System.Drawing.Point(89, 230);
            this.adresaInput.Name = "adresaInput";
            this.adresaInput.Size = new System.Drawing.Size(147, 20);
            this.adresaInput.TabIndex = 6;
            this.adresaInput.Validating += new System.ComponentModel.CancelEventHandler(this.adresaInput_Validating);
            // 
            // opisInput
            // 
            this.opisInput.Location = new System.Drawing.Point(89, 133);
            this.opisInput.Name = "opisInput";
            this.opisInput.Size = new System.Drawing.Size(147, 63);
            this.opisInput.TabIndex = 7;
            this.opisInput.Text = "";
            this.opisInput.Validating += new System.ComponentModel.CancelEventHandler(this.opisInput_Validating);
            // 
            // tipSelect
            // 
            this.tipSelect.FormattingEnabled = true;
            this.tipSelect.Location = new System.Drawing.Point(89, 100);
            this.tipSelect.Name = "tipSelect";
            this.tipSelect.Size = new System.Drawing.Size(147, 21);
            this.tipSelect.TabIndex = 8;
            this.tipSelect.Validating += new System.ComponentModel.CancelEventHandler(this.tipSelect_Validating);
            // 
            // gradSelect
            // 
            this.gradSelect.FormattingEnabled = true;
            this.gradSelect.Location = new System.Drawing.Point(89, 256);
            this.gradSelect.Name = "gradSelect";
            this.gradSelect.Size = new System.Drawing.Size(147, 21);
            this.gradSelect.TabIndex = 9;
            this.gradSelect.Validating += new System.ComponentModel.CancelEventHandler(this.gradSelect_Validating);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(262, 63);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 92);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // saveChangesBtn
            // 
            this.saveChangesBtn.Location = new System.Drawing.Point(262, 303);
            this.saveChangesBtn.Name = "saveChangesBtn";
            this.saveChangesBtn.Size = new System.Drawing.Size(100, 23);
            this.saveChangesBtn.TabIndex = 11;
            this.saveChangesBtn.Text = "Save Changes";
            this.saveChangesBtn.UseVisualStyleBackColor = true;
            this.saveChangesBtn.Click += new System.EventHandler(this.saveChangesBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 206);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Capacity";
            // 
            // kapacitetInput
            // 
            this.kapacitetInput.Location = new System.Drawing.Point(89, 204);
            this.kapacitetInput.Name = "kapacitetInput";
            this.kapacitetInput.Size = new System.Drawing.Size(147, 20);
            this.kapacitetInput.TabIndex = 13;
            this.kapacitetInput.Validating += new System.ComponentModel.CancelEventHandler(this.kapacitetInput_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Rating";
            // 
            // averageRatingInput
            // 
            this.averageRatingInput.Location = new System.Drawing.Point(89, 300);
            this.averageRatingInput.Name = "averageRatingInput";
            this.averageRatingInput.Size = new System.Drawing.Size(147, 20);
            this.averageRatingInput.TabIndex = 15;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 349);
            this.Controls.Add(this.averageRatingInput);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.kapacitetInput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.saveChangesBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.gradSelect);
            this.Controls.Add(this.tipSelect);
            this.Controls.Add(this.opisInput);
            this.Controls.Add(this.adresaInput);
            this.Controls.Add(this.nazivInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.Load += new System.EventHandler(this.EditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kapacitetInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox nazivInput;
        private System.Windows.Forms.TextBox adresaInput;
        private System.Windows.Forms.RichTextBox opisInput;
        private System.Windows.Forms.ComboBox tipSelect;
        private System.Windows.Forms.ComboBox gradSelect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button saveChangesBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown kapacitetInput;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.TextBox averageRatingInput;
        private System.Windows.Forms.Label label7;
    }
}