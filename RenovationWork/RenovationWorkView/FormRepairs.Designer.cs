
namespace RenovationWorkView
{
    partial class FormRepairs
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
            this.ButtonUpd = new System.Windows.Forms.Button();
            this.ButtonDel = new System.Windows.Forms.Button();
            this.ButtonRef = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ButtonUpd
            // 
            this.ButtonUpd.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonUpd.Location = new System.Drawing.Point(465, 256);
            this.ButtonUpd.Name = "ButtonUpd";
            this.ButtonUpd.Size = new System.Drawing.Size(100, 38);
            this.ButtonUpd.TabIndex = 9;
            this.ButtonUpd.Text = "Update";
            this.ButtonUpd.UseVisualStyleBackColor = true;
            this.ButtonUpd.Click += new System.EventHandler(this.ButtonUpd_Click);
            // 
            // ButtonDel
            // 
            this.ButtonDel.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonDel.Location = new System.Drawing.Point(465, 212);
            this.ButtonDel.Name = "ButtonDel";
            this.ButtonDel.Size = new System.Drawing.Size(100, 38);
            this.ButtonDel.TabIndex = 8;
            this.ButtonDel.Text = "Delete";
            this.ButtonDel.UseVisualStyleBackColor = true;
            this.ButtonDel.Click += new System.EventHandler(this.ButtonDel_Click);
            // 
            // ButtonRef
            // 
            this.ButtonRef.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonRef.Location = new System.Drawing.Point(465, 168);
            this.ButtonRef.Name = "ButtonRef";
            this.ButtonRef.Size = new System.Drawing.Size(100, 38);
            this.ButtonRef.TabIndex = 7;
            this.ButtonRef.Text = "Change";
            this.ButtonRef.UseVisualStyleBackColor = true;
            this.ButtonRef.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonAdd.Location = new System.Drawing.Point(465, 124);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(100, 38);
            this.ButtonAdd.TabIndex = 6;
            this.ButtonAdd.Text = "Add";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(20, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(410, 417);
            this.dataGridView.TabIndex = 5;
            // 
            // FormRepairs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 441);
            this.Controls.Add(this.ButtonUpd);
            this.Controls.Add(this.ButtonDel);
            this.Controls.Add(this.ButtonRef);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormRepairs";
            this.Text = "Repairs";
            this.Load += new System.EventHandler(this.FormRepairs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonUpd;
        private System.Windows.Forms.Button ButtonDel;
        private System.Windows.Forms.Button ButtonRef;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}