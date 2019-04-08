namespace LocalEventsSeminarski_UI.Event
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
            this.eventDataGridView = new System.Windows.Forms.DataGridView();
            this.EventID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumOdrzavanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nazivInput = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // eventDataGridView
            // 
            this.eventDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EventID,
            this.Naziv,
            this.DatumOdrzavanja});
            this.eventDataGridView.Location = new System.Drawing.Point(94, 172);
            this.eventDataGridView.Name = "eventDataGridView";
            this.eventDataGridView.Size = new System.Drawing.Size(244, 156);
            this.eventDataGridView.TabIndex = 1;
            // 
            // EventID
            // 
            this.EventID.DataPropertyName = "EventID";
            this.EventID.HeaderText = "EventID";
            this.EventID.Name = "EventID";
            this.EventID.ReadOnly = true;
            this.EventID.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            // 
            // DatumOdrzavanja
            // 
            this.DatumOdrzavanja.DataPropertyName = "DatumOdrzavanja";
            this.DatumOdrzavanja.HeaderText = "DatumOdrzavanja";
            this.DatumOdrzavanja.Name = "DatumOdrzavanja";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(282, 93);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // nazivInput
            // 
            this.nazivInput.Location = new System.Drawing.Point(149, 96);
            this.nazivInput.Name = "nazivInput";
            this.nazivInput.Size = new System.Drawing.Size(116, 20);
            this.nazivInput.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(379, 172);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 39);
            this.button1.TabIndex = 8;
            this.button1.Text = "Edit Selected";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 351);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nazivInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.eventDataGridView);
            this.Movable = false;
            this.Name = "IndexForm";
            this.Resizable = false;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Event Index";
            this.Load += new System.EventHandler(this.IndexForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView eventDataGridView;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nazivInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn EventID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumOdrzavanja;
        private System.Windows.Forms.Button button1;
    }
}