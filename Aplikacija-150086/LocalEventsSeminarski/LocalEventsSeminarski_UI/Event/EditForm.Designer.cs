namespace LocalEventsSeminarski_UI.Event
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
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nazivInput = new System.Windows.Forms.TextBox();
            this.opisInput = new System.Windows.Forms.RichTextBox();
            this.lokacijaSelect = new System.Windows.Forms.ComboBox();
            this.eventTypeSelect = new System.Windows.Forms.ComboBox();
            this.organizacijaSelect = new System.Windows.Forms.ComboBox();
            this.statusSelect = new System.Windows.Forms.ComboBox();
            this.datumOdrzavanjaInput = new System.Windows.Forms.DateTimePicker();
            this.vrijemeKrajaInput = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.vrijemePocetkaInput = new System.Windows.Forms.DateTimePicker();
            this.eventImage = new System.Windows.Forms.PictureBox();
            this.galleriesDataGrid = new System.Windows.Forms.DataGridView();
            this.EventGalleryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newGalleryBtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.editGalleryBtn = new System.Windows.Forms.Button();
            this.ratingInput = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.reportBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleriesDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Event Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Starts at:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ends at:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Event type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(364, 190);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Location";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(363, 252);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Organization";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(363, 283);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Status";
            // 
            // nazivInput
            // 
            this.nazivInput.Location = new System.Drawing.Point(148, 87);
            this.nazivInput.Name = "nazivInput";
            this.nazivInput.Size = new System.Drawing.Size(189, 20);
            this.nazivInput.TabIndex = 9;
            this.nazivInput.Validating += new System.ComponentModel.CancelEventHandler(this.nazivInput_Validating);
            // 
            // opisInput
            // 
            this.opisInput.Location = new System.Drawing.Point(148, 122);
            this.opisInput.Name = "opisInput";
            this.opisInput.Size = new System.Drawing.Size(189, 53);
            this.opisInput.TabIndex = 10;
            this.opisInput.Text = "";
            this.opisInput.Validating += new System.ComponentModel.CancelEventHandler(this.opisInput_Validating);
            // 
            // lokacijaSelect
            // 
            this.lokacijaSelect.FormattingEnabled = true;
            this.lokacijaSelect.Location = new System.Drawing.Point(431, 186);
            this.lokacijaSelect.Name = "lokacijaSelect";
            this.lokacijaSelect.Size = new System.Drawing.Size(100, 21);
            this.lokacijaSelect.TabIndex = 11;
            this.lokacijaSelect.Validating += new System.ComponentModel.CancelEventHandler(this.lokacijaSelect_Validating);
            // 
            // eventTypeSelect
            // 
            this.eventTypeSelect.FormattingEnabled = true;
            this.eventTypeSelect.Location = new System.Drawing.Point(431, 218);
            this.eventTypeSelect.Name = "eventTypeSelect";
            this.eventTypeSelect.Size = new System.Drawing.Size(100, 21);
            this.eventTypeSelect.TabIndex = 12;
            this.eventTypeSelect.Validating += new System.ComponentModel.CancelEventHandler(this.eventTypeSelect_Validating);
            // 
            // organizacijaSelect
            // 
            this.organizacijaSelect.FormattingEnabled = true;
            this.organizacijaSelect.Location = new System.Drawing.Point(431, 249);
            this.organizacijaSelect.Name = "organizacijaSelect";
            this.organizacijaSelect.Size = new System.Drawing.Size(100, 21);
            this.organizacijaSelect.TabIndex = 13;
            this.organizacijaSelect.Validating += new System.ComponentModel.CancelEventHandler(this.organizacijaSelect_Validating);
            // 
            // statusSelect
            // 
            this.statusSelect.FormattingEnabled = true;
            this.statusSelect.Location = new System.Drawing.Point(431, 280);
            this.statusSelect.Name = "statusSelect";
            this.statusSelect.Size = new System.Drawing.Size(100, 21);
            this.statusSelect.TabIndex = 14;
            this.statusSelect.Validating += new System.ComponentModel.CancelEventHandler(this.statusSelect_Validating);
            // 
            // datumOdrzavanjaInput
            // 
            this.datumOdrzavanjaInput.Location = new System.Drawing.Point(148, 190);
            this.datumOdrzavanjaInput.Name = "datumOdrzavanjaInput";
            this.datumOdrzavanjaInput.Size = new System.Drawing.Size(189, 20);
            this.datumOdrzavanjaInput.TabIndex = 15;
            // 
            // vrijemeKrajaInput
            // 
            this.vrijemeKrajaInput.Location = new System.Drawing.Point(148, 253);
            this.vrijemeKrajaInput.Name = "vrijemeKrajaInput";
            this.vrijemeKrajaInput.Size = new System.Drawing.Size(189, 20);
            this.vrijemeKrajaInput.TabIndex = 17;
            this.vrijemeKrajaInput.Validating += new System.ComponentModel.CancelEventHandler(this.vrijemeKrajaInput_Validating);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(451, 478);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 28);
            this.button1.TabIndex = 18;
            this.button1.Text = "Save Changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // vrijemePocetkaInput
            // 
            this.vrijemePocetkaInput.Location = new System.Drawing.Point(148, 221);
            this.vrijemePocetkaInput.Name = "vrijemePocetkaInput";
            this.vrijemePocetkaInput.Size = new System.Drawing.Size(189, 20);
            this.vrijemePocetkaInput.TabIndex = 20;
            this.vrijemePocetkaInput.Validating += new System.ComponentModel.CancelEventHandler(this.vrijemePocetkaInput_Validating);
            // 
            // eventImage
            // 
            this.eventImage.Location = new System.Drawing.Point(431, 87);
            this.eventImage.Name = "eventImage";
            this.eventImage.Size = new System.Drawing.Size(100, 88);
            this.eventImage.TabIndex = 22;
            this.eventImage.TabStop = false;
            // 
            // galleriesDataGrid
            // 
            this.galleriesDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.galleriesDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EventGalleryID,
            this.Naziv,
            this.Column1});
            this.galleriesDataGrid.Location = new System.Drawing.Point(42, 356);
            this.galleriesDataGrid.Name = "galleriesDataGrid";
            this.galleriesDataGrid.Size = new System.Drawing.Size(243, 150);
            this.galleriesDataGrid.TabIndex = 23;
            // 
            // EventGalleryID
            // 
            this.EventGalleryID.DataPropertyName = "EventGalleryID";
            this.EventGalleryID.HeaderText = "EventGalleryID";
            this.EventGalleryID.Name = "EventGalleryID";
            this.EventGalleryID.ReadOnly = true;
            this.EventGalleryID.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "DatumKreiranja";
            this.Column1.HeaderText = "DatumKreiranja";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // newGalleryBtn
            // 
            this.newGalleryBtn.Location = new System.Drawing.Point(291, 356);
            this.newGalleryBtn.Name = "newGalleryBtn";
            this.newGalleryBtn.Size = new System.Drawing.Size(75, 45);
            this.newGalleryBtn.TabIndex = 24;
            this.newGalleryBtn.Text = "New Gallery";
            this.newGalleryBtn.UseVisualStyleBackColor = true;
            this.newGalleryBtn.Click += new System.EventHandler(this.newGalleryBtn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label10.Location = new System.Drawing.Point(77, 326);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 17);
            this.label10.TabIndex = 25;
            this.label10.Text = "Index of Event Galleries";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // editGalleryBtn
            // 
            this.editGalleryBtn.Location = new System.Drawing.Point(291, 407);
            this.editGalleryBtn.Name = "editGalleryBtn";
            this.editGalleryBtn.Size = new System.Drawing.Size(75, 45);
            this.editGalleryBtn.TabIndex = 26;
            this.editGalleryBtn.Text = "Edit Selected";
            this.editGalleryBtn.UseVisualStyleBackColor = true;
            this.editGalleryBtn.Click += new System.EventHandler(this.editGalleryBtn_Click);
            // 
            // ratingInput
            // 
            this.ratingInput.Location = new System.Drawing.Point(148, 283);
            this.ratingInput.Name = "ratingInput";
            this.ratingInput.Size = new System.Drawing.Size(189, 20);
            this.ratingInput.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 288);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(38, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Rating";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(291, 458);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 45);
            this.button2.TabIndex = 29;
            this.button2.Text = "Refresh Grid";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // reportBtn
            // 
            this.reportBtn.Location = new System.Drawing.Point(451, 356);
            this.reportBtn.Name = "reportBtn";
            this.reportBtn.Size = new System.Drawing.Size(91, 45);
            this.reportBtn.TabIndex = 30;
            this.reportBtn.Text = "Create Report";
            this.reportBtn.UseVisualStyleBackColor = true;
            this.reportBtn.Click += new System.EventHandler(this.reportBtn_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 529);
            this.Controls.Add(this.reportBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ratingInput);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.editGalleryBtn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.newGalleryBtn);
            this.Controls.Add(this.galleriesDataGrid);
            this.Controls.Add(this.eventImage);
            this.Controls.Add(this.vrijemePocetkaInput);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.vrijemeKrajaInput);
            this.Controls.Add(this.datumOdrzavanjaInput);
            this.Controls.Add(this.statusSelect);
            this.Controls.Add(this.organizacijaSelect);
            this.Controls.Add(this.eventTypeSelect);
            this.Controls.Add(this.lokacijaSelect);
            this.Controls.Add(this.opisInput);
            this.Controls.Add(this.nazivInput);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
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
            ((System.ComponentModel.ISupportInitialize)(this.eventImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleriesDataGrid)).EndInit();
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox nazivInput;
        private System.Windows.Forms.RichTextBox opisInput;
        private System.Windows.Forms.ComboBox lokacijaSelect;
        private System.Windows.Forms.ComboBox eventTypeSelect;
        private System.Windows.Forms.ComboBox organizacijaSelect;
        private System.Windows.Forms.ComboBox statusSelect;
        private System.Windows.Forms.DateTimePicker datumOdrzavanjaInput;
        private System.Windows.Forms.DateTimePicker vrijemeKrajaInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker vrijemePocetkaInput;
        private System.Windows.Forms.PictureBox eventImage;
        private System.Windows.Forms.DataGridView galleriesDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventGalleryID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button newGalleryBtn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button editGalleryBtn;
        private System.Windows.Forms.TextBox ratingInput;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button reportBtn;
    }
}