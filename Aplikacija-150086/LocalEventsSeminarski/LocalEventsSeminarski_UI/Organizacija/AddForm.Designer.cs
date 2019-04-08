namespace LocalEventsSeminarski_UI.Organizacija
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
            this.nazivInput = new System.Windows.Forms.TextBox();
            this.opisInput = new System.Windows.Forms.RichTextBox();
            this.gradSelect = new System.Windows.Forms.ComboBox();
            this.tipSelect = new System.Windows.Forms.ComboBox();
            this.slikaInput = new System.Windows.Forms.TextBox();
            this.slikaDodajBtn = new System.Windows.Forms.Button();
            this.organizacijaPictureBox = new System.Windows.Forms.PictureBox();
            this.submitBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.organizacijaPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 219);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 254);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "City";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Photo";
            // 
            // nazivInput
            // 
            this.nazivInput.Location = new System.Drawing.Point(91, 63);
            this.nazivInput.Name = "nazivInput";
            this.nazivInput.Size = new System.Drawing.Size(121, 20);
            this.nazivInput.TabIndex = 6;
            this.nazivInput.Validating += new System.ComponentModel.CancelEventHandler(this.nazivInput_Validating);
            // 
            // opisInput
            // 
            this.opisInput.Location = new System.Drawing.Point(91, 100);
            this.opisInput.Name = "opisInput";
            this.opisInput.Size = new System.Drawing.Size(121, 96);
            this.opisInput.TabIndex = 7;
            this.opisInput.Text = "";
            this.opisInput.Validating += new System.ComponentModel.CancelEventHandler(this.opisInput_Validating);
            // 
            // gradSelect
            // 
            this.gradSelect.FormattingEnabled = true;
            this.gradSelect.Location = new System.Drawing.Point(91, 251);
            this.gradSelect.Name = "gradSelect";
            this.gradSelect.Size = new System.Drawing.Size(121, 21);
            this.gradSelect.TabIndex = 9;
            this.gradSelect.Validating += new System.ComponentModel.CancelEventHandler(this.gradSelect_Validating);
            // 
            // tipSelect
            // 
            this.tipSelect.FormattingEnabled = true;
            this.tipSelect.Location = new System.Drawing.Point(91, 211);
            this.tipSelect.Name = "tipSelect";
            this.tipSelect.Size = new System.Drawing.Size(121, 21);
            this.tipSelect.TabIndex = 10;
            this.tipSelect.Validating += new System.ComponentModel.CancelEventHandler(this.tipSelect_Validating);
            // 
            // slikaInput
            // 
            this.slikaInput.Location = new System.Drawing.Point(91, 289);
            this.slikaInput.Name = "slikaInput";
            this.slikaInput.Size = new System.Drawing.Size(121, 20);
            this.slikaInput.TabIndex = 11;
            this.slikaInput.Validating += new System.ComponentModel.CancelEventHandler(this.slikaInput_Validating);
            // 
            // slikaDodajBtn
            // 
            this.slikaDodajBtn.Location = new System.Drawing.Point(227, 287);
            this.slikaDodajBtn.Name = "slikaDodajBtn";
            this.slikaDodajBtn.Size = new System.Drawing.Size(75, 23);
            this.slikaDodajBtn.TabIndex = 12;
            this.slikaDodajBtn.Text = "Add";
            this.slikaDodajBtn.UseVisualStyleBackColor = true;
            this.slikaDodajBtn.Click += new System.EventHandler(this.slikaDodajBtn_Click);
            // 
            // organizacijaPictureBox
            // 
            this.organizacijaPictureBox.Location = new System.Drawing.Point(322, 63);
            this.organizacijaPictureBox.Name = "organizacijaPictureBox";
            this.organizacijaPictureBox.Size = new System.Drawing.Size(106, 101);
            this.organizacijaPictureBox.TabIndex = 13;
            this.organizacijaPictureBox.TabStop = false;
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(353, 321);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 14;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
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
            this.ClientSize = new System.Drawing.Size(452, 367);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.organizacijaPictureBox);
            this.Controls.Add(this.slikaDodajBtn);
            this.Controls.Add(this.slikaInput);
            this.Controls.Add(this.tipSelect);
            this.Controls.Add(this.gradSelect);
            this.Controls.Add(this.opisInput);
            this.Controls.Add(this.nazivInput);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddForm";
            this.Text = "AddForm";
            this.Load += new System.EventHandler(this.AddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.organizacijaPictureBox)).EndInit();
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
        private System.Windows.Forms.RichTextBox opisInput;
        private System.Windows.Forms.ComboBox gradSelect;
        private System.Windows.Forms.ComboBox tipSelect;
        private System.Windows.Forms.TextBox slikaInput;
        private System.Windows.Forms.Button slikaDodajBtn;
        private System.Windows.Forms.PictureBox organizacijaPictureBox;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}