using RenovationWorkContracts.BindingModels;
using RenovationWorkContracts.BusinessLogicsContracts;
using RenovationWorkContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenovationWorkView
{
    public partial class FormCreateOrder : Form
    {
        private readonly IRepairLogic _logicR;
        private readonly IOrderLogic _logicO;
        private readonly IClientLogic _logicC;
        public FormCreateOrder(IRepairLogic logicR, IOrderLogic logicO, IClientLogic logicC)
        {
            InitializeComponent();
            _logicR = logicR;
            _logicO = logicO;
            _logicC = logicC;
        }

        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            // прописать логику
            List<RepairViewModel> list = _logicR.Read(null);
            if (list != null)
            {
                comboBoxRepair.DisplayMember = "RepairName";
                comboBoxRepair.ValueMember = "Id";
                comboBoxRepair.DataSource = list;
                comboBoxRepair.SelectedItem = null;
            }
            List<ClientViewModel> listClients = _logicC.Read(null);
            if (listClients != null)
            {
                comboBoxClient.DisplayMember = "Fullname";
                comboBoxClient.ValueMember = "Id";
                comboBoxClient.DataSource = listClients;
                comboBoxClient.SelectedItem = null;
            }
        }

        private void CalcSum()
        {
            if (comboBoxRepair.SelectedValue != null &&
           !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxRepair.SelectedValue);
                    RepairViewModel repair = _logicR.Read(new RepairBindingModel
                    {
                        Id
                    = id
                    })?[0];
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * repair?.Price ?? 0).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);

                }
            }
        }

        private void TextBoxAmount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ComboBoxRepair_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Enter Amount", "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxRepair.SelectedValue == null)
            {
                MessageBox.Show("Choose Repair", "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Choose client", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logicO.CreateOrder(new CreateOrderBindingModel
                {
                    RepairId = Convert.ToInt32(comboBoxRepair.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDecimal(textBoxSum.Text),
                    ClientId = Convert.ToInt32(comboBoxClient.SelectedValue)
                });
                MessageBox.Show("Save successfully", "Message",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }

        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
