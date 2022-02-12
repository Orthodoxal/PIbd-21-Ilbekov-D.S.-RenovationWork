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
using Unity;

namespace RenovationWorkView
{
    public partial class FormRepair : Form
    {
        public int Id { set { id = value; } }
        private readonly IRepairLogic _logic;
        private int? id;
        private Dictionary<int, (string, int)> repairComponents;
        public FormRepair(IRepairLogic logic)
        {
            InitializeComponent();
            _logic = logic;
        }

        private void FormRepair_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    RepairViewModel view = _logic.Read(new RepairBindingModel
                    {
                        Id = id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.RepairName;
                        textBoxPrice.Text = view.Price.ToString();
                        repairComponents = view.RepairComponents;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                repairComponents = new Dictionary<int, (string, int)>();
            }
        }

        private void LoadData()
        {
            try
            {
                if (repairComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in repairComponents)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1, pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Program.Container.Resolve<FormRepairComponent>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (repairComponents.ContainsKey(form.Id))
                {
                    repairComponents[form.Id] = (form.ComponentName, form.Count);
                }
                else
                {
                    repairComponents.Add(form.Id, (form.ComponentName, form.Count));
                }
                LoadData();
            }
        }

        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Delete record", "Question", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        repairComponents.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }

        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormRepairComponent>();
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = repairComponents[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    repairComponents[form.Id] = (form.ComponentName, form.Count);
                    LoadData();
                }
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Enter Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Enter Price", "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (repairComponents == null || repairComponents.Count == 0)
            {
                MessageBox.Show("Enter Components", "Error", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                _logic.CreateOrUpdate(new RepairBindingModel
                {
                    Id = id,
                    RepairName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    ProductComponents = repairComponents
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

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
