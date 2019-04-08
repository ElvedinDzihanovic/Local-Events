namespace LocalEventsSeminarski_UI.Lokacija
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
            this.lokacijaDataGrid = new System.Windows.Forms.DataGridView();
            this.LokacijaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Adresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pretraziBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nazivInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lokacijaDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lokacijaDataGrid
            // 
            this.lokacijaDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lokacijaDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LokacijaID,
            this.Naziv,
            this.Tip,
            this.Adresa,
            this.Grad});
            this.lokacijaDataGrid.Location = new System.Drawing.Point(126, 174);
            this.lokacijaDataGrid.Name = "lokacijaDataGrid";
            this.lokacijaDataGrid.Size = new System.Drawing.Size(441, 226);
            this.lokacijaDataGrid.TabIndex = 0;
            // 
            // LokacijaID
            // 
            this.LokacijaID.DataPropertyName = "LokacijaID";
            this.LokacijaID.HeaderText = "LokacijaID";
            this.LokacijaID.Name = "LokacijaID";
            this.LokacijaID.ReadOnly = true;
            this.LokacijaID.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            // 
            // Tip
            // 
            this.Tip.DataPropertyName = "Tip";
            this.Tip.HeaderText = "Tip";
            this.Tip.Name = "Tip";
            // 
            // Adresa
            // 
            this.Adresa.DataPropertyName = "Adresa";
            this.Adresa.HeaderText = "Adresa";
            this.Adresa.Name = "Adresa";
            // 
            // Grad
            // 
            this.Grad.DataPropertyName = "Grad";
            this.Grad.HeaderText = "Grad";
            this.Grad.Name = "Grad";
            // 
            // pretraziBtn
            // 
            this.pretraziBtn.Location = new System.Drawing.Point(332, 128);
            this.pretraziBtn.Name = "pretraziBtn";
            this.pretraziBtn.Size = new System.Drawing.Size(75, 23);
            this.pretraziBtn.TabIndex = 1;
            this.pretraziBtn.Text = "Search";
            this.pretraziBtn.UseVisualStyleBackColor = true;
            this.pretraziBtn.Click += new System.EventHandler(this.pretraziBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(123, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // nazivInput
            // 
            this.nazivInput.Location = new System.Drawing.Point(174, 130);
            this.nazivInput.Name = "nazivInput";
            this.nazivInput.Size = new System.Drawing.Size(140, 20);
            this.nazivInput.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(573, 174);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 42);
            this.button1.TabIndex = 7;
            this.button1.Text = "Edit Selected";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 412);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nazivInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pretraziBtn);
            this.Controls.Add(this.lokacijaDataGrid);
            this.Name = "IndexForm";
            this.Text = "IndexForm";
            this.Load += new System.EventHandler(this.IndexForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lokacijaDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView lokacijaDataGrid;
        private System.Windows.Forms.Button pretraziBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nazivInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn LokacijaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tip;
        private System.Windows.Forms.DataGridViewTextBoxColumn Adresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grad;
        private System.Windows.Forms.Button button1;
    }
}