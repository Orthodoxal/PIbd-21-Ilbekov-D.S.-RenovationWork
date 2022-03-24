
namespace RenovationWorkView
{
    partial class FormReportOrders
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
            this.panel = new System.Windows.Forms.Panel();
            this.ButtonToPdf = new System.Windows.Forms.Button();
            this.ButtonMake = new System.Windows.Forms.Button();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.labelTo = new System.Windows.Forms.Label();
            this.labelFrom = new System.Windows.Forms.Label();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.Controls.Add(this.ButtonToPdf);
            this.panel.Controls.Add(this.ButtonMake);
            this.panel.Controls.Add(this.dateTimePickerTo);
            this.panel.Controls.Add(this.dateTimePickerFrom);
            this.panel.Controls.Add(this.labelTo);
            this.panel.Controls.Add(this.labelFrom);
            this.panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(800, 42);
            this.panel.TabIndex = 0;
            // 
            // ButtonToPdf
            // 
            this.ButtonToPdf.Location = new System.Drawing.Point(664, 8);
            this.ButtonToPdf.Name = "ButtonToPdf";
            this.ButtonToPdf.Size = new System.Drawing.Size(109, 23);
            this.ButtonToPdf.TabIndex = 5;
            this.ButtonToPdf.Text = "Forming to PDF";
            this.ButtonToPdf.UseVisualStyleBackColor = true;
            this.ButtonToPdf.Click += new System.EventHandler(this.ButtonToPdf_Click);
            // 
            // ButtonMake
            // 
            this.ButtonMake.Location = new System.Drawing.Point(394, 8);
            this.ButtonMake.Name = "ButtonMake";
            this.ButtonMake.Size = new System.Drawing.Size(75, 23);
            this.ButtonMake.TabIndex = 4;
            this.ButtonMake.Text = "To Form";
            this.ButtonMake.UseVisualStyleBackColor = true;
            this.ButtonMake.Click += new System.EventHandler(this.ButtonMake_Click);
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Location = new System.Drawing.Point(243, 8);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(145, 23);
            this.dateTimePickerTo.TabIndex = 3;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Location = new System.Drawing.Point(67, 8);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(145, 23);
            this.dateTimePickerFrom.TabIndex = 2;
            // 
            // labelTo
            // 
            this.labelTo.AutoSize = true;
            this.labelTo.Location = new System.Drawing.Point(218, 14);
            this.labelTo.Name = "labelTo";
            this.labelTo.Size = new System.Drawing.Size(19, 15);
            this.labelTo.TabIndex = 1;
            this.labelTo.Text = "To";
            // 
            // labelFrom
            // 
            this.labelFrom.AutoSize = true;
            this.labelFrom.Location = new System.Drawing.Point(26, 14);
            this.labelFrom.Name = "labelFrom";
            this.labelFrom.Size = new System.Drawing.Size(35, 15);
            this.labelFrom.TabIndex = 0;
            this.labelFrom.Text = "From";
            // 
            // FormReportOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel);
            this.Name = "FormReportOrders";
            this.Text = "FormReportOrders";
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button ButtonToPdf;
        private System.Windows.Forms.Button ButtonMake;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.Label labelFrom;
    }
}