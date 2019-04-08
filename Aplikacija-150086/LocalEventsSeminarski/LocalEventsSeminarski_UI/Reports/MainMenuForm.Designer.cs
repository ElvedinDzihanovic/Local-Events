namespace LocalEventsSeminarski_UI.Reports
{
    partial class MainMenuForm
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
            this.createReportBtn1 = new System.Windows.Forms.Button();
            this.createReportBtn2 = new System.Windows.Forms.Button();
            this.gradSelect1 = new System.Windows.Forms.ComboBox();
            this.gradSelect2 = new System.Windows.Forms.ComboBox();
            this.mjesecSelect = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createReportBtn1
            // 
            this.createReportBtn1.Location = new System.Drawing.Point(194, 72);
            this.createReportBtn1.Name = "createReportBtn1";
            this.createReportBtn1.Size = new System.Drawing.Size(75, 41);
            this.createReportBtn1.TabIndex = 0;
            this.createReportBtn1.Text = "Create Report";
            this.createReportBtn1.UseVisualStyleBackColor = true;
            this.createReportBtn1.Click += new System.EventHandler(this.createReportBtn1_Click);
            // 
            // createReportBtn2
            // 
            this.createReportBtn2.Location = new System.Drawing.Point(194, 176);
            this.createReportBtn2.Name = "createReportBtn2";
            this.createReportBtn2.Size = new System.Drawing.Size(75, 44);
            this.createReportBtn2.TabIndex = 1;
            this.createReportBtn2.Text = "Create Report";
            this.createReportBtn2.UseVisualStyleBackColor = true;
            this.createReportBtn2.Click += new System.EventHandler(this.createReportBtn2_Click);
            // 
            // gradSelect1
            // 
            this.gradSelect1.FormattingEnabled = true;
            this.gradSelect1.Location = new System.Drawing.Point(53, 83);
            this.gradSelect1.Name = "gradSelect1";
            this.gradSelect1.Size = new System.Drawing.Size(88, 21);
            this.gradSelect1.TabIndex = 2;
            // 
            // gradSelect2
            // 
            this.gradSelect2.FormattingEnabled = true;
            this.gradSelect2.Location = new System.Drawing.Point(53, 172);
            this.gradSelect2.Name = "gradSelect2";
            this.gradSelect2.Size = new System.Drawing.Size(88, 21);
            this.gradSelect2.TabIndex = 3;
            // 
            // mjesecSelect
            // 
            this.mjesecSelect.FormattingEnabled = true;
            this.mjesecSelect.Location = new System.Drawing.Point(53, 199);
            this.mjesecSelect.Name = "mjesecSelect";
            this.mjesecSelect.Size = new System.Drawing.Size(88, 21);
            this.mjesecSelect.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(81, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Top Rated Lokacije By City";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(52, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Top Rated Events By City and Month";
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 272);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.mjesecSelect);
            this.Controls.Add(this.gradSelect2);
            this.Controls.Add(this.gradSelect1);
            this.Controls.Add(this.createReportBtn2);
            this.Controls.Add(this.createReportBtn1);
            this.Name = "MainMenuForm";
            this.Text = "MainMenuForm";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createReportBtn1;
        private System.Windows.Forms.Button createReportBtn2;
        private System.Windows.Forms.ComboBox gradSelect1;
        private System.Windows.Forms.ComboBox gradSelect2;
        private System.Windows.Forms.ComboBox mjesecSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}