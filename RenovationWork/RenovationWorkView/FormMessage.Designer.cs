namespace RenovationWorkView
{
    partial class FormMessage
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
            this.labelSenderEmail = new System.Windows.Forms.Label();
            this.labelBody = new System.Windows.Forms.Label();
            this.labelSubjectText = new System.Windows.Forms.Label();
            this.textBoxReplyText = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonReply = new System.Windows.Forms.Button();
            this.textBoxDateDelivery = new System.Windows.Forms.TextBox();
            this.labelSender = new System.Windows.Forms.Label();
            this.labelSubject = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelSenderEmail
            // 
            this.labelSenderEmail.AutoSize = true;
            this.labelSenderEmail.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSenderEmail.Location = new System.Drawing.Point(100, 10);
            this.labelSenderEmail.Name = "labelSenderEmail";
            this.labelSenderEmail.Size = new System.Drawing.Size(82, 28);
            this.labelSenderEmail.TabIndex = 0;
            this.labelSenderEmail.Text = "Sender: ";
            // 
            // labelBody
            // 
            this.labelBody.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelBody.Location = new System.Drawing.Point(12, 81);
            this.labelBody.Name = "labelBody";
            this.labelBody.Size = new System.Drawing.Size(776, 160);
            this.labelBody.TabIndex = 1;
            this.labelBody.Text = "Text";
            // 
            // labelSubjectText
            // 
            this.labelSubjectText.AutoSize = true;
            this.labelSubjectText.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSubjectText.Location = new System.Drawing.Point(100, 53);
            this.labelSubjectText.Name = "labelSubjectText";
            this.labelSubjectText.Size = new System.Drawing.Size(86, 28);
            this.labelSubjectText.TabIndex = 2;
            this.labelSubjectText.Text = "Subject: ";
            // 
            // textBoxReplyText
            // 
            this.textBoxReplyText.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxReplyText.Location = new System.Drawing.Point(12, 283);
            this.textBoxReplyText.Name = "textBoxReplyText";
            this.textBoxReplyText.Size = new System.Drawing.Size(776, 34);
            this.textBoxReplyText.TabIndex = 3;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(713, 358);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonReply
            // 
            this.buttonReply.Location = new System.Drawing.Point(619, 358);
            this.buttonReply.Name = "buttonReply";
            this.buttonReply.Size = new System.Drawing.Size(75, 23);
            this.buttonReply.TabIndex = 5;
            this.buttonReply.Text = "Reply";
            this.buttonReply.UseVisualStyleBackColor = true;
            this.buttonReply.Click += new System.EventHandler(this.buttonReply_Click);
            // 
            // textBoxDateDelivery
            // 
            this.textBoxDateDelivery.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxDateDelivery.Location = new System.Drawing.Point(576, 9);
            this.textBoxDateDelivery.Name = "textBoxDateDelivery";
            this.textBoxDateDelivery.Size = new System.Drawing.Size(212, 29);
            this.textBoxDateDelivery.TabIndex = 6;
            // 
            // labelSender
            // 
            this.labelSender.AutoSize = true;
            this.labelSender.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSender.Location = new System.Drawing.Point(12, 10);
            this.labelSender.Name = "labelSender";
            this.labelSender.Size = new System.Drawing.Size(82, 28);
            this.labelSender.TabIndex = 7;
            this.labelSender.Text = "Sender: ";
            // 
            // labelSubject
            // 
            this.labelSubject.AutoSize = true;
            this.labelSubject.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelSubject.Location = new System.Drawing.Point(12, 53);
            this.labelSubject.Name = "labelSubject";
            this.labelSubject.Size = new System.Drawing.Size(86, 28);
            this.labelSubject.TabIndex = 8;
            this.labelSubject.Text = "Subject: ";
            // 
            // labelDate
            // 
            this.labelDate.AutoSize = true;
            this.labelDate.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelDate.Location = new System.Drawing.Point(508, 10);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(62, 28);
            this.labelDate.TabIndex = 9;
            this.labelDate.Text = "Date: ";
            // 
            // FormMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 393);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelSubject);
            this.Controls.Add(this.labelSender);
            this.Controls.Add(this.textBoxDateDelivery);
            this.Controls.Add(this.buttonReply);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxReplyText);
            this.Controls.Add(this.labelSubjectText);
            this.Controls.Add(this.labelBody);
            this.Controls.Add(this.labelSenderEmail);
            this.Name = "FormMessage";
            this.Text = "Message";
            this.Load += new System.EventHandler(this.FormMessage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSenderEmail;
        private System.Windows.Forms.Label labelBody;
        private System.Windows.Forms.Label labelSubjectText;
        private System.Windows.Forms.TextBox textBoxReplyText;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonReply;
        private System.Windows.Forms.TextBox textBoxDateDelivery;
        private System.Windows.Forms.Label labelSender;
        private System.Windows.Forms.Label labelSubject;
        private System.Windows.Forms.Label labelDate;
    }
}