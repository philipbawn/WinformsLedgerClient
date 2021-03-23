using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LedgerFormsApp
{
    public partial class frmTransaction : Form
    {
        public frmTransaction()
        {
            InitializeComponent();
        }

        private void frmTransaction_Load(object sender, EventArgs e)
        {
            using var channel = GrpcChannel.ForAddress("http://127.0.0.1:50051");
            var client = new Transaction.Transactor.TransactorClient(channel);
            var reply = client.GetTB(new Transaction.TBRequest() { Date = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd") });
            foreach (var tbLine in reply.Lines)
            {
                this.comboBox1.Items.Add(tbLine.Accountname);
                this.comboBox2.Items.Add(tbLine.Accountname);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtCreditAmount_TextChanged(object sender, EventArgs e)
        {
            WarnIfNotEqual();
        }

        private bool WarnIfNotEqual()
        {
            bool result = false;
            bool debitParse = decimal.TryParse(txtDebitAmount.Text, out decimal debit);
            bool creditParse = decimal.TryParse(txtCreditAmount.Text, out decimal credit);
            if (debitParse == false || creditParse == false)
            {
                lblWarning.ForeColor = Color.DarkRed;
                lblWarning.Text = "Cannot parse your credit or debit amounts into decimals!";
            }
            else
            {
                lblWarning.ForeColor = Color.Black;
                if (debit*-1 == credit)
                {
                    lblWarning.Text = "Debit and credit are inverse. TODO: other sanity checks";
                }
                else
                {
                    lblWarning.Text = "Caution, debit and credit amounts are not inverse.";
                }
            }
            return result;
        }

        private void txtDebitAmount_TextChanged(object sender, EventArgs e)
        {
            WarnIfNotEqual();
        }

        private void lblWarning_Click(object sender, EventArgs e)
        {

        }
    }
}
