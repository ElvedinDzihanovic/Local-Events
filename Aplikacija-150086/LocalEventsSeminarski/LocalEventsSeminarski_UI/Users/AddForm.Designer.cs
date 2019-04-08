namespace LocalEventsSeminarski_UI.Users
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
            this.imeInput = new System.Windows.Forms.TextBox();
            this.prezimeInput = new System.Windows.Forms.TextBox();
            this.emailInput = new System.Windows.Forms.TextBox();
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.userPictureBox = new System.Windows.Forms.PictureBox();
            this.korisnickoImeInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gradSelect = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.slikaInput = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.slikaDodajBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.telefonInput = new System.Windows.Forms.MaskedTextBox();
            this.ulogeListBox = new System.Windows.Forms.CheckedListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.zanimanjeInput = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Phone";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Password";
            // 
            // imeInput
            // 
            this.imeInput.Location = new System.Drawing.Point(101, 77);
            this.imeInput.Name = "imeInput";
            this.imeInput.Size = new System.Drawing.Size(100, 20);
            this.imeInput.TabIndex = 5;
            this.imeInput.Validating += new System.ComponentModel.CancelEventHandler(this.imeInput_Validating);
            // 
            // prezimeInput
            // 
            this.prezimeInput.Location = new System.Drawing.Point(101, 105);
            this.prezimeInput.Name = "prezimeInput";
            this.prezimeInput.Size = new System.Drawing.Size(100, 20);
            this.prezimeInput.TabIndex = 6;
            this.prezimeInput.Validating += new System.ComponentModel.CancelEventHandler(this.prezimeInput_Validating);
            // 
            // emailInput
            // 
            this.emailInput.Location = new System.Drawing.Point(101, 131);
            this.emailInput.Name = "emailInput";
            this.emailInput.Size = new System.Drawing.Size(100, 20);
            this.emailInput.TabIndex = 7;
            this.emailInput.Validating += new System.ComponentModel.CancelEventHandler(this.emailInput_Validating);
            // 
            // passwordInput
            // 
            this.passwordInput.Location = new System.Drawing.Point(101, 209);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.PasswordChar = '*';
            this.passwordInput.Size = new System.Drawing.Size(100, 20);
            this.passwordInput.TabIndex = 9;
            this.passwordInput.Validating += new System.ComponentModel.CancelEventHandler(this.passwordInput_Validating);
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(277, 355);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 10;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // userPictureBox
            // 
            this.userPictureBox.Location = new System.Drawing.Point(243, 77);
            this.userPictureBox.Name = "userPictureBox";
            this.userPictureBox.Size = new System.Drawing.Size(109, 107);
            this.userPictureBox.TabIndex = 11;
            this.userPictureBox.TabStop = false;
            // 
            // korisnickoImeInput
            // 
            this.korisnickoImeInput.Location = new System.Drawing.Point(101, 157);
            this.korisnickoImeInput.Name = "korisnickoImeInput";
            this.korisnickoImeInput.Size = new System.Drawing.Size(100, 20);
            this.korisnickoImeInput.TabIndex = 12;
            this.korisnickoImeInput.Validating += new System.ComponentModel.CancelEventHandler(this.korisnickoImeInput_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Username";
            // 
            // gradSelect
            // 
            this.gradSelect.FormattingEnabled = true;
            this.gradSelect.Location = new System.Drawing.Point(101, 235);
            this.gradSelect.Name = "gradSelect";
            this.gradSelect.Size = new System.Drawing.Size(99, 21);
            this.gradSelect.TabIndex = 15;
            this.gradSelect.Validating += new System.ComponentModel.CancelEventHandler(this.gradSelect_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 238);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "City";
            // 
            // slikaInput
            // 
            this.slikaInput.Location = new System.Drawing.Point(101, 271);
            this.slikaInput.Name = "slikaInput";
            this.slikaInput.Size = new System.Drawing.Size(100, 20);
            this.slikaInput.TabIndex = 17;
            this.slikaInput.Validating += new System.ComponentModel.CancelEventHandler(this.slikaInput_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 274);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Photo";
            // 
            // slikaDodajBtn
            // 
            this.slikaDodajBtn.Location = new System.Drawing.Point(207, 269);
            this.slikaDodajBtn.Name = "slikaDodajBtn";
            this.slikaDodajBtn.Size = new System.Drawing.Size(75, 23);
            this.slikaDodajBtn.TabIndex = 19;
            this.slikaDodajBtn.Text = "Dodaj";
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
            // telefonInput
            // 
            this.telefonInput.Location = new System.Drawing.Point(101, 183);
            this.telefonInput.Mask = "(999) 000-000";
            this.telefonInput.Name = "telefonInput";
            this.telefonInput.Size = new System.Drawing.Size(100, 20);
            this.telefonInput.TabIndex = 20;
            this.telefonInput.Validating += new System.ComponentModel.CancelEventHandler(this.telefonInput_Validating_1);
            // 
            // ulogeListBox
            // 
            this.ulogeListBox.FormattingEnabled = true;
            this.ulogeListBox.Location = new System.Drawing.Point(101, 300);
            this.ulogeListBox.Name = "ulogeListBox";
            this.ulogeListBox.Size = new System.Drawing.Size(100, 49);
            this.ulogeListBox.TabIndex = 21;
            this.ulogeListBox.Validating += new System.ComponentModel.CancelEventHandler(this.ulogeListBox_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 300);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Roles";
            // 
            // zanimanjeInput
            // 
            this.zanimanjeInput.Location = new System.Drawing.Point(101, 358);
            this.zanimanjeInput.Name = "zanimanjeInput";
            this.zanimanjeInput.Size = new System.Drawing.Size(100, 20);
            this.zanimanjeInput.TabIndex = 24;
            this.zanimanjeInput.Validating += new System.ComponentModel.CancelEventHandler(this.zanimanjeInput_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(36, 361);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Zanimanje";
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 391);
            this.Controls.Add(this.zanimanjeInput);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.ulogeListBox);
            this.Controls.Add(this.telefonInput);
            this.Controls.Add(this.slikaDodajBtn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.slikaInput);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gradSelect);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.korisnickoImeInput);
            this.Controls.Add(this.userPictureBox);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.passwordInput);
            this.Controls.Add(this.emailInput);
            this.Controls.Add(this.prezimeInput);
            this.Controls.Add(this.imeInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddForm";
            this.Text = "AddForm";
            this.Load += new System.EventHandler(this.AddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).EndInit();
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
        private System.Windows.Forms.TextBox imeInput;
        private System.Windows.Forms.TextBox prezimeInput;
        private System.Windows.Forms.TextBox emailInput;
        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.PictureBox userPictureBox;
        private System.Windows.Forms.TextBox korisnickoImeInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox gradSelect;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox slikaInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button slikaDodajBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.MaskedTextBox telefonInput;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckedListBox ulogeListBox;
        private System.Windows.Forms.TextBox zanimanjeInput;
        private System.Windows.Forms.Label label10;
    }
}