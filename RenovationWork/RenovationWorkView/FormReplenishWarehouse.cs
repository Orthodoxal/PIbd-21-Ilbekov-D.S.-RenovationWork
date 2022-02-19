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
    public partial class FormReplenishWarehouse : Form
    {
        private readonly IWarehouseLogic _warehouseLogic;
        private readonly IComponentLogic _componentLogic;
        public int Amount
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }
        public FormReplenishWarehouse(IWarehouseLogic warehouseLogic, IComponentLogic componentLogic)
        {
            InitializeComponent();
            _warehouseLogic = warehouseLogic;
            _componentLogic = componentLogic;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Enter amount", "Error",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxWarehouse.SelectedValue == null)
            {
                MessageBox.Show("Choose Warehouse", "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Choose component", "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            _warehouseLogic.AddComponent(new WarehouseBindingModel { Id = (int)comboBoxWarehouse.SelectedValue },
                new ComponentBindingModel { Id = (int)comboBoxComponent.SelectedValue }, Amount);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormReplenishWarehouse_Load(object sender, EventArgs e)
        {
            List<WarehouseViewModel> warehousesList = _warehouseLogic.Read(null);
            if (warehousesList != null)
            {
                comboBoxWarehouse.DisplayMember = "WarehouseName";
                comboBoxWarehouse.ValueMember = "Id";
                comboBoxWarehouse.DataSource = warehousesList;
                comboBoxWarehouse.SelectedItem = null;
            }
            List<ComponentViewModel> componentsList = _componentLogic.Read(null);
            if (componentsList != null)
            {
                comboBoxComponent.DisplayMember = "ComponentName";
                comboBoxComponent.ValueMember = "Id";
                comboBoxComponent.DataSource = componentsList;
                comboBoxComponent.SelectedItem = null;
            }
        }
    }
}
