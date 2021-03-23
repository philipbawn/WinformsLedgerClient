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
    public partial class frmAccounts : Form
    {
        public frmAccounts()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var channel = GrpcChannel.ForAddress("http://127.0.0.1:50051");
            var client = new Transaction.Transactor.TransactorClient(channel);
            var reply = client.AddAccount(new Transaction.AccountTagRequest() { Account = txtAccountName.Text });
            MessageBox.Show(reply.Message);
            ReloadAllAccounts();
        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {
            ReloadAllAccounts();
        }

        private void ReloadAllAccounts()
        {
            this.listBox1.Items.Clear();
            using var channel = GrpcChannel.ForAddress("http://127.0.0.1:50051");
            var client = new Transaction.Transactor.TransactorClient(channel);
            var reply = client.GetTB(new Transaction.TBRequest() { Date = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd") });
            foreach (var tbLine in reply.Lines)
            {
                this.listBox1.Items.Add(tbLine);
            }
        }
    }
}
