namespace LocalEventsSeminarski_UI.Users
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
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imeInput = new System.Windows.Forms.TextBox();
            this.prezimeInput = new System.Windows.Forms.TextBox();
            this.emailInput = new System.Windows.Forms.TextBox();
            this.usernameInput = new System.Windows.Forms.TextBox();
            this.passwordInput = new System.Windows.Forms.TextBox();
            this.gradInput = new System.Windows.Forms.ComboBox();
            this.saveChangesBtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.statusSelect = new System.Windows.Forms.ComboBox();
            this.telefonInput = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Phone ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "New Pass";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 217);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "City";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(205, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 86);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // imeInput
            // 
            this.imeInput.Location = new System.Drawing.Point(87, 29);
            this.imeInput.Name = "imeInput";
            this.imeInput.Size = new System.Drawing.Size(100, 20);
            this.imeInput.TabIndex = 8;
            this.imeInput.Validating += new System.ComponentModel.CancelEventHandler(this.imeInput_Validating);
            // 
            // prezimeInput
            // 
            this.prezimeInput.Location = new System.Drawing.Point(87, 61);
            this.prezimeInput.Name = "prezimeInput";
            this.prezimeInput.Size = new System.Drawing.Size(100, 20);
            this.prezimeInput.TabIndex = 9;
            this.prezimeInput.Validating += new System.ComponentModel.CancelEventHandler(this.prezimeInput_Validating);
            // 
            // emailInput
            // 
            this.emailInput.Location = new System.Drawing.Point(87, 95);
            this.emailInput.Name = "emailInput";
            this.emailInput.Size = new System.Drawing.Size(100, 20);
            this.emailInput.TabIndex = 10;
            this.emailInput.Validating += new System.ComponentModel.CancelEventHandler(this.emailInput_Validating);
            // 
            // usernameInput
            // 
            this.usernameInput.Location = new System.Drawing.Point(87, 123);
            this.usernameInput.Name = "usernameInput";
            this.usernameInput.Size = new System.Drawing.Size(100, 20);
            this.usernameInput.TabIndex = 11;
            this.usernameInput.Validating += new System.ComponentModel.CancelEventHandler(this.usernameInput_Validating);
            // 
            // passwordInput
            // 
            this.passwordInput.Location = new System.Drawing.Point(88, 186);
            this.passwordInput.Name = "passwordInput";
            this.passwordInput.PasswordChar = '*';
            this.passwordInput.Size = new System.Drawing.Size(100, 20);
            this.passwordInput.TabIndex = 13;
            this.passwordInput.Validating += new System.ComponentModel.CancelEventHandler(this.passwordInput_Validating);
            // 
            // gradInput
            // 
            this.gradInput.FormattingEnabled = true;
            this.gradInput.Location = new System.Drawing.Point(87, 217);
            this.gradInput.Name = "gradInput";
            this.gradInput.Size = new System.Drawing.Size(100, 21);
            this.gradInput.TabIndex = 14;
            this.gradInput.Validating += new System.ComponentModel.CancelEventHandler(this.gradInput_Validating);
            // 
            // saveChangesBtn
            // 
            this.saveChangesBtn.Location = new System.Drawing.Point(205, 278);
            this.saveChangesBtn.Name = "saveChangesBtn";
            this.saveChangesBtn.Size = new System.Drawing.Size(100, 23);
            this.saveChangesBtn.TabIndex = 15;
            this.saveChangesBtn.Text = "Save Changes";
            this.saveChangesBtn.UseVisualStyleBackColor = true;
            this.saveChangesBtn.Click += new System.EventHandler(this.saveChangesBtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Status";
            // 
            // statusSelect
            // 
            this.statusSelect.FormattingEnabled = true;
            this.statusSelect.Location = new System.Drawing.Point(87, 248);
            this.statusSelect.Name = "statusSelect";
            this.statusSelect.Size = new System.Drawing.Size(100, 21);
            this.statusSelect.TabIndex = 18;
            // 
            // telefonInput
            // 
            this.telefonInput.Location = new System.Drawing.Point(88, 151);
            this.telefonInput.Name = "telefonInput";
            this.telefonInput.Size = new System.Drawing.Size(100, 20);
            this.telefonInput.TabIndex = 19;
            this.telefonInput.Validating += new System.ComponentModel.CancelEventHandler(this.telefonInput_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 313);
            this.Controls.Add(this.telefonInput);
            this.Controls.Add(this.statusSelect);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.saveChangesBtn);
            this.Controls.Add(this.gradInput);
            this.Controls.Add(this.passwordInput);
            this.Controls.Add(this.usernameInput);
            this.Controls.Add(this.emailInput);
            this.Controls.Add(this.prezimeInput);
            this.Controls.Add(this.imeInput);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "EditForm";
            this.Text = "EditForm";
            this.Load += new System.EventHandler(this.EditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox imeInput;
        private System.Windows.Forms.TextBox prezimeInput;
        private System.Windows.Forms.TextBox emailInput;
        private System.Windows.Forms.TextBox usernameInput;
        private System.Windows.Forms.TextBox passwordInput;
        private System.Windows.Forms.ComboBox gradInput;
        private System.Windows.Forms.Button saveChangesBtn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox statusSelect;
        private System.Windows.Forms.TextBox telefonInput;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}