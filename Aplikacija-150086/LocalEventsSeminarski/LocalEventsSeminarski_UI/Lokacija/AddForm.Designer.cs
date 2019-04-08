namespace LocalEventsSeminarski_UI.Lokacija
{
    partial class AddForm
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
            this.label6 = new System.Windows.Forms.Label();
            this.nazivInput = new System.Windows.Forms.TextBox();
            this.opisInput = new System.Windows.Forms.RichTextBox();
            this.adresaInput = new System.Windows.Forms.TextBox();
            this.gradSelect = new System.Windows.Forms.ComboBox();
            this.lokacijaTipSelect = new System.Windows.Forms.ComboBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.kapacitetInput = new System.Windows.Forms.NumericUpDown();
            this.lokacijaPictureBox = new System.Windows.Forms.PictureBox();
            this.slikaInput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.slikaDodajBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.kapacitetInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokacijaPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Capacity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "City";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 323);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Type";
            // 
            // nazivInput
            // 
            this.nazivInput.Location = new System.Drawing.Point(105, 75);
            this.nazivInput.Name = "nazivInput";
            this.nazivInput.Size = new System.Drawing.Size(150, 20);
            this.nazivInput.TabIndex = 6;
            this.nazivInput.Validating += new System.ComponentModel.CancelEventHandler(this.nazivInput_Validating);
            // 
            // opisInput
            // 
            this.opisInput.Location = new System.Drawing.Point(105, 111);
            this.opisInput.Name = "opisInput";
            this.opisInput.Size = new System.Drawing.Size(150, 98);
            this.opisInput.TabIndex = 7;
            this.opisInput.Text = "";
            this.opisInput.Validating += new System.ComponentModel.CancelEventHandler(this.opisInput_Validating);
            // 
            // adresaInput
            // 
            this.adresaInput.Location = new System.Drawing.Point(105, 251);
            this.adresaInput.Name = "adresaInput";
            this.adresaInput.Size = new System.Drawing.Size(150, 20);
            this.adresaInput.TabIndex = 9;
            this.adresaInput.Validating += new System.ComponentModel.CancelEventHandler(this.adresaInput_Validating);
            // 
            // gradSelect
            // 
            this.gradSelect.FormattingEnabled = true;
            this.gradSelect.Location = new System.Drawing.Point(105, 284);
            this.gradSelect.Name = "gradSelect";
            this.gradSelect.Size = new System.Drawing.Size(150, 21);
            this.gradSelect.TabIndex = 10;
            this.gradSelect.Validating += new System.ComponentModel.CancelEventHandler(this.gradSelect_Validating);
            // 
            // lokacijaTipSelect
            // 
            this.lokacijaTipSelect.FormattingEnabled = true;
            this.lokacijaTipSelect.Location = new System.Drawing.Point(105, 323);
            this.lokacijaTipSelect.Name = "lokacijaTipSelect";
            this.lokacijaTipSelect.Size = new System.Drawing.Size(150, 21);
            this.lokacijaTipSelect.TabIndex = 11;
            this.lokacijaTipSelect.Validating += new System.ComponentModel.CancelEventHandler(this.lokacijaTipSelect_Validating);
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(387, 398);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 34);
            this.submitBtn.TabIndex = 12;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // kapacitetInput
            // 
            this.kapacitetInput.Location = new System.Drawing.Point(105, 217);
            this.kapacitetInput.Name = "kapacitetInput";
            this.kapacitetInput.Size = new System.Drawing.Size(150, 20);
            this.kapacitetInput.TabIndex = 13;
            this.kapacitetInput.Validating += new System.ComponentModel.CancelEventHandler(this.kapacitetInput_Validating);
            // 
            // lokacijaPictureBox
            // 
            this.lokacijaPictureBox.Location = new System.Drawing.Point(347, 75);
            this.lokacijaPictureBox.Name = "lokacijaPictureBox";
            this.lokacijaPictureBox.Size = new System.Drawing.Size(115, 107);
            this.lokacijaPictureBox.TabIndex = 14;
            this.lokacijaPictureBox.TabStop = false;
            // 
            // slikaInput
            // 
            this.slikaInput.Location = new System.Drawing.Point(105, 362);
            this.slikaInput.Name = "slikaInput";
            this.slikaInput.Size = new System.Drawing.Size(150, 20);
            this.slikaInput.TabIndex = 15;
            this.slikaInput.Validating += new System.ComponentModel.CancelEventHandler(this.slikaInput_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 369);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Slika";
            // 
            // slikaDodajBtn
            // 
            this.slikaDodajBtn.Location = new System.Drawing.Point(272, 362);
            this.slikaDodajBtn.Name = "slikaDodajBtn";
            this.slikaDodajBtn.Size = new System.Drawing.Size(75, 23);
            this.slikaDodajBtn.TabIndex = 17;
            this.slikaDodajBtn.Text = "Add";
            this.slikaDodajBtn.UseVisualStyleBackColor = true;
            this.slikaDodajBtn.Click += new System.EventHandler(this.slikaDodajBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 441);
            this.Controls.Add(this.slikaDodajBtn);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.slikaInput);
            this.Controls.Add(this.lokacijaPictureBox);
            this.Controls.Add(this.kapacitetInput);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.lokacijaTipSelect);
            this.Controls.Add(this.gradSelect);
            this.Controls.Add(this.adresaInput);
            this.Controls.Add(this.opisInput);
            this.Controls.Add(this.nazivInput);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddForm";
            this.Text = "AddForm";
            this.Load += new System.EventHandler(this.AddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kapacitetInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lokacijaPictureBox)).EndInit();
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nazivInput;
        private System.Windows.Forms.RichTextBox opisInput;
        private System.Windows.Forms.TextBox adresaInput;
        private System.Windows.Forms.ComboBox gradSelect;
        private System.Windows.Forms.ComboBox lokacijaTipSelect;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.NumericUpDown kapacitetInput;
        private System.Windows.Forms.PictureBox lokacijaPictureBox;
        private System.Windows.Forms.TextBox slikaInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button slikaDodajBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}