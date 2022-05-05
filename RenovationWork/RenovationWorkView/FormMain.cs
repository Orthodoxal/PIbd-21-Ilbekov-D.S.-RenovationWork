using RenovationWorkContracts.BindingModels;
using RenovationWorkContracts.BusinessLogicsContracts;
using System;
using System.Windows.Forms;
using Unity;

namespace RenovationWorkView
{
    public partial class FormMain : Form
    {
        private readonly IOrderLogic _orderLogic;
        private readonly IReportLogic _reportLogic;
        private readonly IWorkProcess _workProcess;
        private readonly IImplementerLogic _implementerLogic;
        public FormMain(IOrderLogic orderLogic, IReportLogic reportLogic,
            IWorkProcess workProcess, IImplementerLogic implementerLogic)
        {
            InitializeComponent();
            _orderLogic = orderLogic;
            _reportLogic = reportLogic;
            _workProcess = workProcess;
            _implementerLogic = implementerLogic;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = _orderLogic.Read(null);
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].Visible = false;
                    for (int i = 4; i < 10; i++)
                        dataGridView.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void componentsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormComponents>();
            form.ShowDialog();
        }

        private void repairsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormRepairs>();
            form.ShowDialog();
        }

        private void warehousesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormWarehouses>();
            form.ShowDialog();
        }


        private void replenishingWarehouseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReplenishWarehouse>();
            form.ShowDialog();
        }

        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }
                
        private void ButtonOrderIsIssued_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    _orderLogic.DeliveryOrder(new ChangeStatusBindingModel
                    {
                        OrderId = id
                    });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ComponentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _reportLogic.SaveComponentsToWordFile(new ReportBindingModel
                {
                    FileName = dialog.FileName
                });
                MessageBox.Show("Executed", "Success", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private void ComponentsRepairsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportRepairComponents>();
            form.ShowDialog();
        }

        private void OrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportOrders>();
            form.ShowDialog();
        }

        private void WarehousesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _reportLogic.SaveWarehousesToWordFile(new ReportBindingModel
                {
                    FileName = dialog.FileName
                });
                MessageBox.Show("Executed", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void warehouseWorkloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportWarehouseComponent>();
            form.ShowDialog();
        }

        private void listOrdersByDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormReportOrdersByDate>();
            form.ShowDialog();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormClients>();
            form.ShowDialog();
        }

        private void implementersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormImplementers>();
            form.ShowDialog();
        }

        private void startWorkingToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            _workProcess.DoWork(_implementerLogic, _orderLogic);
        }

        private void messagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormMessages>();
            form.ShowDialog();
        }
    }
}
