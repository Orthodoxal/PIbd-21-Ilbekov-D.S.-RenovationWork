
namespace RenovationWorkView
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.repairsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.implementersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComponentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ComponentsRepairsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startWorkingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonCreateOrder = new System.Windows.Forms.Button();
            this.ButtonOrderIsIssued = new System.Windows.Forms.Button();
            this.ButtonRef = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.startWorkingToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(984, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.componentsToolStripMenuItem1,
            this.repairsToolStripMenuItem,
            this.clientsToolStripMenuItem,
            this.implementersToolStripMenuItem});
            this.manualToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(74, 25);
            this.manualToolStripMenuItem.Text = "Manual";
            // 
            // componentsToolStripMenuItem1
            // 
            this.componentsToolStripMenuItem1.Name = "componentsToolStripMenuItem1";
            this.componentsToolStripMenuItem1.Size = new System.Drawing.Size(176, 26);
            this.componentsToolStripMenuItem1.Text = "Components";
            this.componentsToolStripMenuItem1.Click += new System.EventHandler(this.componentsToolStripMenuItem1_Click);
            // 
            // repairsToolStripMenuItem
            // 
            this.repairsToolStripMenuItem.Name = "repairsToolStripMenuItem";
            this.repairsToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.repairsToolStripMenuItem.Text = "Repairs";
            this.repairsToolStripMenuItem.Click += new System.EventHandler(this.repairsToolStripMenuItem_Click);
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.clientsToolStripMenuItem.Text = "Clients";
            this.clientsToolStripMenuItem.Click += new System.EventHandler(this.clientsToolStripMenuItem_Click);
            // 
            // implementersToolStripMenuItem
            // 
            this.implementersToolStripMenuItem.Name = "implementersToolStripMenuItem";
            this.implementersToolStripMenuItem.Size = new System.Drawing.Size(176, 26);
            this.implementersToolStripMenuItem.Text = "Implementers";
            this.implementersToolStripMenuItem.Click += new System.EventHandler(this.implementersToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ComponentsToolStripMenuItem,
            this.ComponentsRepairsToolStripMenuItem,
            this.OrdersToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 25);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // ComponentsToolStripMenuItem
            // 
            this.ComponentsToolStripMenuItem.Name = "ComponentsToolStripMenuItem";
            this.ComponentsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.ComponentsToolStripMenuItem.Text = "List components";
            this.ComponentsToolStripMenuItem.Click += new System.EventHandler(this.ComponentsToolStripMenuItem_Click);
            // 
            // ComponentsRepairsToolStripMenuItem
            // 
            this.ComponentsRepairsToolStripMenuItem.Name = "ComponentsRepairsToolStripMenuItem";
            this.ComponentsRepairsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.ComponentsRepairsToolStripMenuItem.Text = "Components by repairs";
            this.ComponentsRepairsToolStripMenuItem.Click += new System.EventHandler(this.ComponentsRepairsToolStripMenuItem_Click);
            // 
            // OrdersToolStripMenuItem
            // 
            this.OrdersToolStripMenuItem.Name = "OrdersToolStripMenuItem";
            this.OrdersToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.OrdersToolStripMenuItem.Text = "List orders";
            this.OrdersToolStripMenuItem.Click += new System.EventHandler(this.OrdersToolStripMenuItem_Click);
            // 
            // startWorkingToolStripMenuItem
            // 
            this.startWorkingToolStripMenuItem.Name = "startWorkingToolStripMenuItem";
            this.startWorkingToolStripMenuItem.Size = new System.Drawing.Size(89, 25);
            this.startWorkingToolStripMenuItem.Text = "Start working";
            this.startWorkingToolStripMenuItem.Click += new System.EventHandler(this.startWorkingToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 32);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 25;
            this.dataGridView.Size = new System.Drawing.Size(763, 367);
            this.dataGridView.TabIndex = 2;
            // 
            // ButtonCreateOrder
            // 
            this.ButtonCreateOrder.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonCreateOrder.Location = new System.Drawing.Point(781, 50);
            this.ButtonCreateOrder.Name = "ButtonCreateOrder";
            this.ButtonCreateOrder.Size = new System.Drawing.Size(191, 39);
            this.ButtonCreateOrder.TabIndex = 3;
            this.ButtonCreateOrder.Text = "Create order";
            this.ButtonCreateOrder.UseVisualStyleBackColor = true;
            this.ButtonCreateOrder.Click += new System.EventHandler(this.ButtonCreateOrder_Click);
            // 
            // ButtonOrderIsIssued
            // 
            this.ButtonOrderIsIssued.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonOrderIsIssued.Location = new System.Drawing.Point(781, 194);
            this.ButtonOrderIsIssued.Name = "ButtonOrderIsIssued";
            this.ButtonOrderIsIssued.Size = new System.Drawing.Size(191, 39);
            this.ButtonOrderIsIssued.TabIndex = 6;
            this.ButtonOrderIsIssued.Text = "Order is issued";
            this.ButtonOrderIsIssued.UseVisualStyleBackColor = true;
            this.ButtonOrderIsIssued.Click += new System.EventHandler(this.ButtonOrderIsIssued_Click);
            // 
            // ButtonRef
            // 
            this.ButtonRef.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ButtonRef.Location = new System.Drawing.Point(781, 345);
            this.ButtonRef.Name = "ButtonRef";
            this.ButtonRef.Size = new System.Drawing.Size(191, 39);
            this.ButtonRef.TabIndex = 7;
            this.ButtonRef.Text = "Update list";
            this.ButtonRef.UseVisualStyleBackColor = true;
            this.ButtonRef.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 411);
            this.Controls.Add(this.ButtonRef);
            this.Controls.Add(this.ButtonOrderIsIssued);
            this.Controls.Add(this.ButtonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Renovation Work";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem componentsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem repairsToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonCreateOrder;
        private System.Windows.Forms.Button ButtonOrderIsIssued;
        private System.Windows.Forms.Button ButtonRef;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ComponentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ComponentsRepairsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startWorkingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem implementersToolStripMenuItem;
    }
}