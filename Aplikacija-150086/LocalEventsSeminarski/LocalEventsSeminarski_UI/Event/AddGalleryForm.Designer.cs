namespace LocalEventsSeminarski_UI.Event
{
    partial class AddGalleryForm
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
            this.submitBtn = new System.Windows.Forms.Button();
            this.nazivInput = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.opisRichTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Description";
            // 
            // submitBtn
            // 
            this.submitBtn.Location = new System.Drawing.Point(224, 243);
            this.submitBtn.Name = "submitBtn";
            this.submitBtn.Size = new System.Drawing.Size(75, 23);
            this.submitBtn.TabIndex = 2;
            this.submitBtn.Text = "Submit";
            this.submitBtn.UseVisualStyleBackColor = true;
            this.submitBtn.Click += new System.EventHandler(this.submitBtn_Click);
            // 
            // nazivInput
            // 
            this.nazivInput.Location = new System.Drawing.Point(80, 83);
            this.nazivInput.Name = "nazivInput";
            this.nazivInput.Size = new System.Drawing.Size(219, 20);
            this.nazivInput.TabIndex = 3;
            this.nazivInput.Validating += new System.ComponentModel.CancelEventHandler(this.nazivInput_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // opisRichTextBox
            // 
            this.opisRichTextBox.Location = new System.Drawing.Point(80, 125);
            this.opisRichTextBox.Name = "opisRichTextBox";
            this.opisRichTextBox.Size = new System.Drawing.Size(219, 96);
            this.opisRichTextBox.TabIndex = 4;
            this.opisRichTextBox.Text = "";
            this.opisRichTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.opisRichTextBox_Validating);
            // 
            // AddGalleryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 300);
            this.Controls.Add(this.opisRichTextBox);
            this.Controls.Add(this.nazivInput);
            this.Controls.Add(this.submitBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddGalleryForm";
            this.Text = "AddGalleryForm";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button submitBtn;
        private System.Windows.Forms.TextBox nazivInput;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.RichTextBox opisRichTextBox;
    }
}