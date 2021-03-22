using Grpc.Net.Client;
using LedgerFormsApp.ViewModel;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var list = new BindingList<TransactionLineItemForDisplay>();
            tranLookupProgress.Value = 0;

            string startDate = dtpStart.Value.ToString("yyyy-MM-dd");
            string endDate = dtpEnd.Value.ToString("yyyy-MM-dd");
            
            // Note: my GoDbLedger runs on remote server, use SSH client to tunnel local port 50051 to same port on remote host
            using var channel = GrpcChannel.ForAddress("http://127.0.0.1:50051");
            var client = new Transaction.Transactor.TransactorClient(channel);
            var reply = client.GetListing(new Transaction.ReportRequest() { Startdate = startDate, Date = endDate });
            foreach (var item in reply.Transactions)
            {
                foreach (var line in item.Lines)
                {
                    TransactionLineItemForDisplay newTran = new TransactionLineItemForDisplay();
                    newTran.Currency = line.Currency;
                    newTran.AccountName = line.Accountname;
                    newTran.Description = line.Description;
                    newTran.DateEntry = item.Date.Replace("00:00:00", "");
                    if (newTran.Currency == "USD")
                    {
                        newTran.Money = new Dollars(line.Amount);
                    }
                    list.Add(newTran);
                }
            }

            dataGridView1.DataSource = list;
            tranLookupProgress.Value = 100;
            dataGridView1.AutoResizeColumns();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int year = DateTime.Now.Year;
            dtpStart.Value = new DateTime(year, 1, 1);
            dtpEnd.Value = new DateTime(year, 12, 31);
        }
    }
}
