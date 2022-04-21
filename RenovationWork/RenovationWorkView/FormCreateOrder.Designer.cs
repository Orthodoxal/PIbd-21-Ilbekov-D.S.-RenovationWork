
namespace RenovationWorkView
{
    partial class FormCreateOrder
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
            this.labelRepair = new System.Windows.Forms.Label();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.comboBoxRepair = new System.Windows.Forms.ComboBox();
            this.labelAmount = new System.Windows.Forms.Label();
            this.labelTotal = new System.Windows.Forms.Label();
            this.textBoxCount = new System.Windows.Forms.TextBox();
            this.textBoxSum = new System.Windows.Forms.TextBox();
            this.labelClient = new System.Windows.Forms.Label();
            this.comboBoxClient = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelRepair
            // 
            this.labelRepair.AutoSize = true;
            this.labelRepair.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelRepair.Location = new System.Drawing.Point(31, 65);
            this.labelRepair.Name = "labelRepair";
            this.labelRepair.Size = new System.Drawing.Size(85, 32);
            this.labelRepair.TabIndex = 10;
            this.labelRepair.Text = "Repair:";
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.Location = new System.Drawing.Point(339, 226);
            this.ButtonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(86, 31);
            this.ButtonCancel.TabIndex = 9;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(240, 226);
            this.ButtonSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(86, 31);
            this.ButtonSave.TabIndex = 8;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // comboBoxRepair
            // 
            this.comboBoxRepair.FormattingEnabled = true;
            this.comboBoxRepair.Location = new System.Drawing.Point(168, 68);
            this.comboBoxRepair.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxRepair.Name = "comboBoxRepair";
            this.comboBoxRepair.Size = new System.Drawing.Size(257, 28);
            this.comboBoxRepair.TabIndex = 7;
            this.comboBoxRepair.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRepair_SelectedIndexChanged);
            // 
            // labelAmount
            // 
            this.labelAmount.AutoSize = true;
            this.labelAmount.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelAmount.Location = new System.Drawing.Point(31, 139);
            this.labelAmount.Name = "labelAmount";
            this.labelAmount.Size = new System.Drawing.Size(105, 32);
            this.labelAmount.TabIndex = 11;
            this.labelAmount.Text = "Amount:";
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelTotal.Location = new System.Drawing.Point(31, 175);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(70, 32);
            this.labelTotal.TabIndex = 12;
            this.labelTotal.Text = "Total:";
            // 
            // textBoxCount
            // 
            this.textBoxCount.Location = new System.Drawing.Point(168, 139);
            this.textBoxCount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxCount.Name = "textBoxCount";
            this.textBoxCount.Size = new System.Drawing.Size(257, 27);
            this.textBoxCount.TabIndex = 13;
            this.textBoxCount.TextChanged += new System.EventHandler(this.TextBoxAmount_TextChanged);
            // 
            // textBoxSum
            // 
            this.textBoxSum.Location = new System.Drawing.Point(168, 178);
            this.textBoxSum.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxSum.Name = "textBoxSum";
            this.textBoxSum.Size = new System.Drawing.Size(257, 27);
            this.textBoxSum.TabIndex = 14;
            // 
            // labelClient
            // 
            this.labelClient.AutoSize = true;
            this.labelClient.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelClient.Location = new System.Drawing.Point(31, 19);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(81, 32);
            this.labelClient.TabIndex = 15;
            this.labelClient.Text = "Client:";
            // 
            // comboBoxClient
            // 
            this.comboBoxClient.FormattingEnabled = true;
            this.comboBoxClient.Location = new System.Drawing.Point(168, 19);
            this.comboBoxClient.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxClient.Name = "comboBoxClient";
            this.comboBoxClient.Size = new System.Drawing.Size(257, 28);
            this.comboBoxClient.TabIndex = 16;
            // 
            // FormCreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 275);
            this.Controls.Add(this.comboBoxClient);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.textBoxSum);
            this.Controls.Add(this.textBoxCount);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.labelAmount);
            this.Controls.Add(this.labelRepair);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.comboBoxRepair);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormCreateOrder";
            this.Text = "Order";
            this.Load += new System.EventHandler(this.FormCreateOrder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRepair;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.ComboBox comboBoxRepair;
        private System.Windows.Forms.Label labelAmount;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.TextBox textBoxSum;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.ComboBox comboBoxClient;
    }
}