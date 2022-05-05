using RenovationWorkBusinessLogic.MailWorker;
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
    public partial class FormMessage : Form
    {
        public string MessageId
        {
            set { _messageId = value; }
        }
        private readonly IMessageInfoLogic _messageLogic;

        private readonly IClientLogic _clientLogic;

        private readonly AbstractMailWorker _mailWorker;
        private string _messageId;
        public FormMessage(IMessageInfoLogic messageLogic, IClientLogic clientLogic, AbstractMailWorker mailWorker)
        {
            InitializeComponent();
            _messageLogic = messageLogic;
            _clientLogic = clientLogic;
            _mailWorker = mailWorker;
        }

        private void FormMessage_Load(object sender, EventArgs e)
        {
            if (_messageId != null)
            {
                try
                {
                    MessageInfoViewModel view = _messageLogic.Read(new MessageInfoBindingModel { MessageId = _messageId })?[0];
                    if (view != null)
                    {
                        if (view.Viewed == "No")
                        {
                            _messageLogic.CreateOrUpdate(new MessageInfoBindingModel
                            {
                                ClientId = _clientLogic.Read(new ClientBindingModel { Login = view.SenderName })?[0].Id,
                                MessageId = _messageId,
                                FromMailAddress = view.SenderName,
                                Subject = view.Subject,
                                Body = view.Body,
                                DateDelivery = view.DateDelivery,
                                Viewed = "Yes",
                                ReplyText = view.ReplyText
                            });
                        }
                        labelBody.Text = view.Body;
                        labelSenderEmail.Text = view.SenderName;
                        labelSubjectText.Text = view.Subject;
                        textBoxDateDelivery.Text = view.DateDelivery.ToString();
                        textBoxReplyText.Text = view.ReplyText;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonReply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxReplyText.Text))
            {
                MessageBox.Show("Enter text", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                _mailWorker.MailSendAsync(new MailSendInfoBindingModel
                {
                    MailAddress = labelSenderEmail.Text,
                    Subject = "Answer for: " + labelSubjectText.Text,
                    Text = textBoxReplyText.Text
                });

                _messageLogic.CreateOrUpdate(new MessageInfoBindingModel
                {
                    ClientId = _clientLogic.Read(new ClientBindingModel { Login = labelSenderEmail.Text })?[0].Id,
                    MessageId = _messageId,
                    FromMailAddress = labelSenderEmail.Text,
                    Subject = labelSubjectText.Text,
                    Body = labelBody.Text,
                    DateDelivery = DateTime.Parse(textBoxDateDelivery.Text),
                    Viewed = "Yes",
                    ReplyText = textBoxReplyText.Text
                });

                MessageBox.Show("Answer sent", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
