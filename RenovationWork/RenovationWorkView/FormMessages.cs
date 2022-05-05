using RenovationWorkContracts.BindingModels;
using RenovationWorkContracts.BusinessLogicsContracts;
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
    public partial class FormMessages : Form
    {
        private readonly IMessageInfoLogic logic;
        private bool hasNext = false;
        private readonly int mailsOnPage = 4;
        private int currentPage = 0;
        public FormMessages(IMessageInfoLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
            if (mailsOnPage < 1) 
            {
                mailsOnPage = 5;
            }
        }
        private void FormMessages_Load(object sender, EventArgs e)
        {
            LoadData();
            textBoxPage.Text = "1";
            dataGridView.Columns[0].Visible = false;
            dataGridView.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        private void LoadData()
        {
            var list = logic.Read(new MessageInfoBindingModel {
                ToSkip = currentPage * mailsOnPage,
                ToTake = mailsOnPage + 1
            });
            hasNext = !(list.Count() <= mailsOnPage);
            if (hasNext)
            {
                buttonNext.Text = "Next " + (currentPage + 2);
                buttonNext.Enabled = true;
            }
            else
            {
                buttonNext.Text = "Next";
                buttonNext.Enabled = false;
            }
            if (list != null)
            {
                dataGridView.DataSource = list.Take(mailsOnPage).ToList();               
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (hasNext)
            {
                currentPage++;
                textBoxPage.Text = (currentPage + 1).ToString();
                buttonPrev.Enabled = true;
                buttonPrev.Text = "Prev " + (currentPage);
                LoadData();
            }
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if ((currentPage - 1) >= 0)
            {
                currentPage--;
                textBoxPage.Text = (currentPage + 1).ToString();
                buttonNext.Enabled = true;
                buttonNext.Text = "Next " + (currentPage + 2);
                if (currentPage == 0)
                {
                    buttonPrev.Enabled = false;
                    buttonPrev.Text = "Prev";
                }
                else
                {
                    buttonPrev.Text = "Prev " + (currentPage);
                }
                LoadData();
            }
        }

        private void buttonShowMessage_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Program.Container.Resolve<FormMessage>();
                form.MessageId = dataGridView.SelectedRows[0].Cells[0].Value.ToString();
                form.ShowDialog();
                LoadData();
            }
        }
    }
}
