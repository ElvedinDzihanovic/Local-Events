namespace LocalEventsSeminarski_UI.Organizacija
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nameInput = new System.Windows.Forms.TextBox();
            this.tipSelect = new System.Windows.Forms.ComboBox();
            this.gradSelect = new System.Windows.Forms.ComboBox();
            this.opisInput = new System.Windows.Forms.RichTextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "City";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(267, 77);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 108);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // nameInput
            // 
            this.nameInput.Location = new System.Drawing.Point(98, 77);
            this.nameInput.Name = "nameInput";
            this.nameInput.Size = new System.Drawing.Size(136, 20);
            this.nameInput.TabIndex = 5;
            this.nameInput.Validating += new System.ComponentModel.CancelEventHandler(this.nameInput_Validating);
            // 
            // tipSelect
            // 
            this.tipSelect.FormattingEnabled = true;
            this.tipSelect.Location = new System.Drawing.Point(98, 191);
            this.tipSelect.Name = "tipSelect";
            this.tipSelect.Size = new System.Drawing.Size(136, 21);
            this.tipSelect.TabIndex = 6;
            this.tipSelect.Validating += new System.ComponentModel.CancelEventHandler(this.tipSelect_Validating);
            // 
            // gradSelect
            // 
            this.gradSelect.FormattingEnabled = true;
            this.gradSelect.Location = new System.Drawing.Point(98, 229);
            this.gradSelect.Name = "gradSelect";
            this.gradSelect.Size = new System.Drawing.Size(136, 21);
            this.gradSelect.TabIndex = 7;
            this.gradSelect.Validating += new System.ComponentModel.CancelEventHandler(this.gradSelect_Validating);
            // 
            // opisInput
            // 
            this.opisInput.Location = new System.Drawing.Point(98, 103);
            this.opisInput.Name = "opisInput";
            this.opisInput.Size = new System.Drawing.Size(136, 82);
            this.opisInput.TabIndex = 8;
            this.opisInput.Text = "";
            this.opisInput.Validating += new System.ComponentModel.CancelEventHandler(this.opisInput_Validating);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(267, 229);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(95, 23);
            this.saveBtn.TabIndex = 9;
            this.saveBtn.Text = "Save Changes";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 294);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.opisInput);
            this.Controls.Add(this.gradSelect);
            this.Controls.Add(this.tipSelect);
            this.Controls.Add(this.nameInput);
            this.Controls.Add(this.pictureBox1);
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox nameInput;
        private System.Windows.Forms.ComboBox tipSelect;
        private System.Windows.Forms.ComboBox gradSelect;
        private System.Windows.Forms.RichTextBox opisInput;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}