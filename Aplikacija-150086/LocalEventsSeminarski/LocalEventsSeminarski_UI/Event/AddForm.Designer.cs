namespace LocalEventsSeminarski_UI.Event
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
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nazivInput = new System.Windows.Forms.TextBox();
            this.slikaInput = new System.Windows.Forms.TextBox();
            this.organizacijaSelect = new System.Windows.Forms.ComboBox();
            this.eventTipSelect = new System.Windows.Forms.ComboBox();
            this.opisInput = new System.Windows.Forms.RichTextBox();
            this.datumOdrzavanjaSelect = new System.Windows.Forms.DateTimePicker();
            this.vrijemePocetkaSelect = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.submitBtn = new System.Windows.Forms.Button();
            this.eventPictureBox = new System.Windows.Forms.PictureBox();
            this.vrijemeKrajaSelect = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.lokacijaSelect = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.ageRangeCheck = new System.Windows.Forms.CheckedListBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.eventPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(53, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Event Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Starts at:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 262);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ends at:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 294);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Event Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(55, 384);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Organization";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(55, 446);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Photo";
            // 
            // nazivInput
            // 
            this.nazivInput.Location = new System.Drawing.Point(169, 73);
            this.nazivInput.Name = "nazivInput";
            this.nazivInput.Size = new System.Drawing.Size(101, 20);
            this.nazivInput.TabIndex = 8;
            this.nazivInput.Validating += new System.ComponentModel.CancelEventHandler(this.nazivInput_Validating);
            // 
            // slikaInput
            // 
            this.slikaInput.Location = new System.Drawing.Point(171, 446);
            this.slikaInput.Name = "slikaInput";
            this.slikaInput.Size = new System.Drawing.Size(108, 20);
            this.slikaInput.TabIndex = 9;
            this.slikaInput.Validating += new System.ComponentModel.CancelEventHandler(this.slikaInput_Validating);
            // 
            // organizacijaSelect
            // 
            this.organizacijaSelect.FormattingEnabled = true;
            this.organizacijaSelect.Location = new System.Drawing.Point(171, 376);
            this.organizacijaSelect.Name = "organizacijaSelect";
            this.organizacijaSelect.Size = new System.Drawing.Size(108, 21);
            this.organizacijaSelect.TabIndex = 10;
            this.organizacijaSelect.Validating += new System.ComponentModel.CancelEventHandler(this.organizacijaSelect_Validating);
            // 
            // eventTipSelect
            // 
            this.eventTipSelect.FormattingEnabled = true;
            this.eventTipSelect.Location = new System.Drawing.Point(169, 294);
            this.eventTipSelect.Name = "eventTipSelect";
            this.eventTipSelect.Size = new System.Drawing.Size(110, 21);
            this.eventTipSelect.TabIndex = 11;
            this.eventTipSelect.Validating += new System.ComponentModel.CancelEventHandler(this.eventTipSelect_Validating);
            // 
            // opisInput
            // 
            this.opisInput.Location = new System.Drawing.Point(170, 110);
            this.opisInput.Name = "opisInput";
            this.opisInput.Size = new System.Drawing.Size(199, 52);
            this.opisInput.TabIndex = 13;
            this.opisInput.Text = "";
            this.opisInput.Validating += new System.ComponentModel.CancelEventHandler(this.opisInput_Validating);
            // 
            // datumOdrzavanjaSelect
            // 
            this.datumOdrzavanjaSelect.Location = new System.Drawing.Point(169, 178);
            this.datumOdrzavanjaSelect.Name = "datumOdrzavanjaSelect";
            this.datumOdrzavanjaSelect.Size = new System.Drawing.Size(200, 20);
            this.datumOdrzavanjaSelect.TabIndex = 14;
            this.datumOdrzavanjaSelect.Validating += new System.ComponentModel.CancelEventHandler(this.datumOdrzavanjaSelect_Validating);
            // 
            // vrijemePocetkaSelect
            // 
            this.vrijemePocetkaSelect.Location = new System.Drawing.Point(170, 220);
            this.vrijemePocetkaSelect.Name = "vrijemePocetkaSelect";
            this.vrijemePocetkaSelect.Size = new System.Drawing.Size(200, 20);
            this.vrijemePocetkaSelect.TabIndex = 15;
            this.vrijemePocetkaSelect.Validating += new System.ComponentModel.CancelEventHandler(this.vrijemePocetkaSelect_Validating);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(295, 444);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 16;
            this.button1.Text = "Dodaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(420, 443);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 17;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // eventPictureBox
            // 
            this.eventPictureBox.Location = new System.Drawing.Point(395, 76);
            this.eventPictureBox.Name = "eventPictureBox";
            this.eventPictureBox.Size = new System.Drawing.Size(100, 103);
            this.eventPictureBox.TabIndex = 18;
            this.eventPictureBox.TabStop = false;
            // 
            // vrijemeKrajaSelect
            // 
            this.vrijemeKrajaSelect.Location = new System.Drawing.Point(169, 262);
            this.vrijemeKrajaSelect.Name = "vrijemeKrajaSelect";
            this.vrijemeKrajaSelect.Size = new System.Drawing.Size(200, 20);
            this.vrijemeKrajaSelect.TabIndex = 19;
            this.vrijemeKrajaSelect.Validating += new System.ComponentModel.CancelEventHandler(this.vrijemeKrajaSelect_Validating);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(55, 420);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Location";
            // 
            // lokacijaSelect
            // 
            this.lokacijaSelect.FormattingEnabled = true;
            this.lokacijaSelect.Location = new System.Drawing.Point(171, 412);
            this.lokacijaSelect.Name = "lokacijaSelect";
            this.lokacijaSelect.Size = new System.Drawing.Size(108, 21);
            this.lokacijaSelect.TabIndex = 21;
            this.lokacijaSelect.Validating += new System.ComponentModel.CancelEventHandler(this.lokacijaSelect_Validating);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(52, 331);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Age Range";
            // 
            // ageRangeCheck
            // 
            this.ageRangeCheck.FormattingEnabled = true;
            this.ageRangeCheck.Location = new System.Drawing.Point(169, 321);
            this.ageRangeCheck.Name = "ageRangeCheck";
            this.ageRangeCheck.Size = new System.Drawing.Size(110, 49);
            this.ageRangeCheck.TabIndex = 23;
            this.ageRangeCheck.Validating += new System.ComponentModel.CancelEventHandler(this.ageRangeCheck_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 492);
            this.Controls.Add(this.ageRangeCheck);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lokacijaSelect);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.vrijemeKrajaSelect);
            this.Controls.Add(this.eventPictureBox);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.vrijemePocetkaSelect);
            this.Controls.Add(this.datumOdrzavanjaSelect);
            this.Controls.Add(this.opisInput);
            this.Controls.Add(this.eventTipSelect);
            this.Controls.Add(this.organizacijaSelect);
            this.Controls.Add(this.slikaInput);
            this.Controls.Add(this.nazivInput);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddForm";
            this.Text = "AddForm";
            this.Load += new System.EventHandler(this.AddForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventPictureBox)).EndInit();
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox nazivInput;
        private System.Windows.Forms.TextBox slikaInput;
        private System.Windows.Forms.ComboBox organizacijaSelect;
        private System.Windows.Forms.ComboBox eventTipSelect;
        private System.Windows.Forms.RichTextBox opisInput;
        private System.Windows.Forms.DateTimePicker datumOdrzavanjaSelect;
        private System.Windows.Forms.DateTimePicker vrijemePocetkaSelect;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.PictureBox eventPictureBox;
        private System.Windows.Forms.DateTimePicker vrijemeKrajaSelect;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox lokacijaSelect;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckedListBox ageRangeCheck;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}