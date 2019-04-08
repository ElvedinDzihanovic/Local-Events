namespace LocalEventsSeminarski_UI.Event
{
    partial class EditImageForm
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
            this.imagePictureBox = new System.Windows.Forms.PictureBox();
            this.imageDescription = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // imagePictureBox
            // 
            this.imagePictureBox.Location = new System.Drawing.Point(12, 12);
            this.imagePictureBox.Name = "imagePictureBox";
            this.imagePictureBox.Size = new System.Drawing.Size(266, 189);
            this.imagePictureBox.TabIndex = 0;
            this.imagePictureBox.TabStop = false;
            // 
            // imageDescription
            // 
            this.imageDescription.Location = new System.Drawing.Point(12, 218);
            this.imageDescription.Name = "imageDescription";
            this.imageDescription.Size = new System.Drawing.Size(266, 82);
            this.imageDescription.TabIndex = 1;
            this.imageDescription.Text = "";
            this.imageDescription.Validating += new System.ComponentModel.CancelEventHandler(this.imageDescription_Validating);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(184, 317);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Save Changes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // EditImageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 352);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.imageDescription);
            this.Controls.Add(this.imagePictureBox);
            this.Name = "EditImageForm";
            this.Text = "EditImageForm";
            this.Load += new System.EventHandler(this.EditImageForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox imagePictureBox;
        private System.Windows.Forms.RichTextBox imageDescription;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}