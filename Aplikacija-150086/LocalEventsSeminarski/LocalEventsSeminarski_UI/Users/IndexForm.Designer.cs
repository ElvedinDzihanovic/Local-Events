namespace LocalEventsSeminarski_UI.Users
{
    partial class IndexForm
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
            this.usersGrid = new System.Windows.Forms.DataGridView();
            this.KorisnikID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prezime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pretraziBtn = new System.Windows.Forms.Button();
            this.imePrezimeInput = new System.Windows.Forms.TextBox();
            this.imePrezimeLabel = new System.Windows.Forms.Label();
            this.izmijeniKorisnikaBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usersGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // usersGrid
            // 
            this.usersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.KorisnikID,
            this.Ime,
            this.Prezime,
            this.Email,
            this.Status});
            this.usersGrid.Location = new System.Drawing.Point(138, 167);
            this.usersGrid.Name = "usersGrid";
            this.usersGrid.Size = new System.Drawing.Size(442, 208);
            this.usersGrid.TabIndex = 0;
            // 
            // KorisnikID
            // 
            this.KorisnikID.DataPropertyName = "KorisnikID";
            this.KorisnikID.HeaderText = "KorisnikID";
            this.KorisnikID.Name = "KorisnikID";
            this.KorisnikID.Visible = false;
            // 
            // Ime
            // 
            this.Ime.DataPropertyName = "Ime";
            this.Ime.HeaderText = "Ime";
            this.Ime.Name = "Ime";
            // 
            // Prezime
            // 
            this.Prezime.DataPropertyName = "Ime";
            this.Prezime.HeaderText = "Prezime";
            this.Prezime.Name = "Prezime";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            // 
            // pretraziBtn
            // 
            this.pretraziBtn.Location = new System.Drawing.Point(362, 96);
            this.pretraziBtn.Name = "pretraziBtn";
            this.pretraziBtn.Size = new System.Drawing.Size(75, 23);
            this.pretraziBtn.TabIndex = 1;
            this.pretraziBtn.Text = "Search";
            this.pretraziBtn.UseVisualStyleBackColor = true;
            this.pretraziBtn.Click += new System.EventHandler(this.pretraziBtn_Click);
            // 
            // imePrezimeInput
            // 
            this.imePrezimeInput.Location = new System.Drawing.Point(212, 96);
            this.imePrezimeInput.Name = "imePrezimeInput";
            this.imePrezimeInput.Size = new System.Drawing.Size(144, 20);
            this.imePrezimeInput.TabIndex = 2;
            // 
            // imePrezimeLabel
            // 
            this.imePrezimeLabel.AutoSize = true;
            this.imePrezimeLabel.Location = new System.Drawing.Point(135, 98);
            this.imePrezimeLabel.Name = "imePrezimeLabel";
            this.imePrezimeLabel.Size = new System.Drawing.Size(55, 13);
            this.imePrezimeLabel.TabIndex = 3;
            this.imePrezimeLabel.Text = "Username";
            // 
            // izmijeniKorisnikaBtn
            // 
            this.izmijeniKorisnikaBtn.Location = new System.Drawing.Point(586, 167);
            this.izmijeniKorisnikaBtn.Name = "izmijeniKorisnikaBtn";
            this.izmijeniKorisnikaBtn.Size = new System.Drawing.Size(74, 42);
            this.izmijeniKorisnikaBtn.TabIndex = 5;
            this.izmijeniKorisnikaBtn.Text = "Edit Selected";
            this.izmijeniKorisnikaBtn.UseVisualStyleBackColor = true;
            this.izmijeniKorisnikaBtn.Click += new System.EventHandler(this.izmijeniKorisnikaBtn_Click);
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 395);
            this.Controls.Add(this.izmijeniKorisnikaBtn);
            this.Controls.Add(this.imePrezimeLabel);
            this.Controls.Add(this.imePrezimeInput);
            this.Controls.Add(this.pretraziBtn);
            this.Controls.Add(this.usersGrid);
            this.Name = "IndexForm";
            this.Text = "IndexForm";
            this.Load += new System.EventHandler(this.IndexForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usersGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView usersGrid;
        private System.Windows.Forms.Button pretraziBtn;
        private System.Windows.Forms.TextBox imePrezimeInput;
        private System.Windows.Forms.Label imePrezimeLabel;
        private System.Windows.Forms.Button izmijeniKorisnikaBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prezime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
    }
}