namespace LocalEventsSeminarski_UI.Organizacija
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
            this.organizacijaDataGrid = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.nazivInput = new System.Windows.Forms.TextBox();
            this.pretraziBtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.OrganizacijaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.organizacijaDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // organizacijaDataGrid
            // 
            this.organizacijaDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.organizacijaDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrganizacijaID,
            this.Naziv});
            this.organizacijaDataGrid.Location = new System.Drawing.Point(211, 153);
            this.organizacijaDataGrid.Name = "organizacijaDataGrid";
            this.organizacijaDataGrid.Size = new System.Drawing.Size(143, 189);
            this.organizacijaDataGrid.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // nazivInput
            // 
            this.nazivInput.Location = new System.Drawing.Point(211, 77);
            this.nazivInput.Name = "nazivInput";
            this.nazivInput.Size = new System.Drawing.Size(143, 20);
            this.nazivInput.TabIndex = 3;
            // 
            // pretraziBtn
            // 
            this.pretraziBtn.Location = new System.Drawing.Point(371, 75);
            this.pretraziBtn.Name = "pretraziBtn";
            this.pretraziBtn.Size = new System.Drawing.Size(65, 23);
            this.pretraziBtn.TabIndex = 4;
            this.pretraziBtn.Text = "Search";
            this.pretraziBtn.UseVisualStyleBackColor = true;
            this.pretraziBtn.Click += new System.EventHandler(this.pretraziBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(371, 153);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(65, 41);
            this.button2.TabIndex = 8;
            this.button2.Text = "Edit Selected";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OrganizacijaID
            // 
            this.OrganizacijaID.DataPropertyName = "OrganizacijaID";
            this.OrganizacijaID.HeaderText = "OrganizacijaID";
            this.OrganizacijaID.Name = "OrganizacijaID";
            this.OrganizacijaID.ReadOnly = true;
            this.OrganizacijaID.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 416);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pretraziBtn);
            this.Controls.Add(this.nazivInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.organizacijaDataGrid);
            this.Name = "IndexForm";
            this.Text = "IndexForm";
            this.Load += new System.EventHandler(this.IndexForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.organizacijaDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView organizacijaDataGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nazivInput;
        private System.Windows.Forms.Button pretraziBtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrganizacijaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
    }
}