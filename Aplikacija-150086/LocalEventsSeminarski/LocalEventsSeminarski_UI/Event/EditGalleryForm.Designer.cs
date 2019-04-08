namespace LocalEventsSeminarski_UI.Event
{
    partial class EditGalleryForm
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
            this.slikeDataGrid = new System.Windows.Forms.DataGridView();
            this.SlikaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SlikaThumb = new System.Windows.Forms.DataGridViewImageColumn();
            this.Opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.slikaDodajBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.opisInput = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nazivInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.saveChangesBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.refreshGridBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.slikeDataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // slikeDataGrid
            // 
            this.slikeDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.slikeDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SlikaID,
            this.SlikaThumb,
            this.Opis});
            this.slikeDataGrid.Location = new System.Drawing.Point(59, 259);
            this.slikeDataGrid.Name = "slikeDataGrid";
            this.slikeDataGrid.RowTemplate.Height = 40;
            this.slikeDataGrid.Size = new System.Drawing.Size(248, 151);
            this.slikeDataGrid.TabIndex = 0;
            // 
            // SlikaID
            // 
            this.SlikaID.DataPropertyName = "SlikaID";
            this.SlikaID.HeaderText = "SlikaID";
            this.SlikaID.Name = "SlikaID";
            this.SlikaID.Visible = false;
            // 
            // SlikaThumb
            // 
            this.SlikaThumb.DataPropertyName = "SlikaThumb";
            this.SlikaThumb.HeaderText = "SlikaThumb";
            this.SlikaThumb.Name = "SlikaThumb";
            this.SlikaThumb.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SlikaThumb.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Opis
            // 
            this.Opis.DataPropertyName = "Opis";
            this.Opis.HeaderText = "Opis";
            this.Opis.Name = "Opis";
            // 
            // slikaDodajBtn
            // 
            this.slikaDodajBtn.Location = new System.Drawing.Point(313, 259);
            this.slikaDodajBtn.Name = "slikaDodajBtn";
            this.slikaDodajBtn.Size = new System.Drawing.Size(75, 38);
            this.slikaDodajBtn.TabIndex = 1;
            this.slikaDodajBtn.Text = "Add New";
            this.slikaDodajBtn.UseVisualStyleBackColor = true;
            this.slikaDodajBtn.Click += new System.EventHandler(this.slikaDodajBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Desc";
            // 
            // opisInput
            // 
            this.opisInput.Location = new System.Drawing.Point(59, 100);
            this.opisInput.Name = "opisInput";
            this.opisInput.Size = new System.Drawing.Size(239, 119);
            this.opisInput.TabIndex = 3;
            this.opisInput.Text = "";
            this.opisInput.Validating += new System.ComponentModel.CancelEventHandler(this.opisInput_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name";
            // 
            // nazivInput
            // 
            this.nazivInput.Location = new System.Drawing.Point(59, 74);
            this.nazivInput.Name = "nazivInput";
            this.nazivInput.Size = new System.Drawing.Size(100, 20);
            this.nazivInput.TabIndex = 5;
            this.nazivInput.Validating += new System.ComponentModel.CancelEventHandler(this.nazivInput_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(139, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Image Index";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // saveChangesBtn
            // 
            this.saveChangesBtn.Location = new System.Drawing.Point(313, 183);
            this.saveChangesBtn.Name = "saveChangesBtn";
            this.saveChangesBtn.Size = new System.Drawing.Size(75, 36);
            this.saveChangesBtn.TabIndex = 7;
            this.saveChangesBtn.Text = "Save Changes";
            this.saveChangesBtn.UseVisualStyleBackColor = true;
            this.saveChangesBtn.Click += new System.EventHandler(this.saveChangesBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 303);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 8;
            this.button1.Text = "Edit Selected";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // refreshGridBtn
            // 
            this.refreshGridBtn.Location = new System.Drawing.Point(313, 347);
            this.refreshGridBtn.Name = "refreshGridBtn";
            this.refreshGridBtn.Size = new System.Drawing.Size(75, 38);
            this.refreshGridBtn.TabIndex = 9;
            this.refreshGridBtn.Text = "Refresh Grid";
            this.refreshGridBtn.UseVisualStyleBackColor = true;
            this.refreshGridBtn.Click += new System.EventHandler(this.refreshGridBtn_Click);
            // 
            // EditGalleryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 422);
            this.Controls.Add(this.refreshGridBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.saveChangesBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nazivInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.opisInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.slikaDodajBtn);
            this.Controls.Add(this.slikeDataGrid);
            this.Name = "EditGalleryForm";
            this.Text = "EditGalleryForm";
            this.Load += new System.EventHandler(this.EditGalleryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.slikeDataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView slikeDataGrid;
        private System.Windows.Forms.Button slikaDodajBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox opisInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nazivInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn SlikaID;
        private System.Windows.Forms.DataGridViewImageColumn SlikaThumb;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button saveChangesBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button refreshGridBtn;
    }
}