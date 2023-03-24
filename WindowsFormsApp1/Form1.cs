using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbDataSet.Item_Invoice". При необходимости она может быть перемещена или удалена.
            this.item_InvoiceTableAdapter.FillBy(this.dbDataSet.Item_Invoice);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dbDataSet.Invoice". При необходимости она может быть перемещена или удалена.
            this.invoiceTableAdapter.FillBy(this.dbDataSet.Invoice);

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви действительно хотите удалить накладную", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                invoiceTableAdapter.DeleteInvoice((int)dataGridView1.CurrentRow.Cells["idinvoiceDataGridViewTextBoxColumn"].Value);
                invoiceTableAdapter.Update(dbDataSet.Invoice); //осуществляет удаление записей в БД
                invoiceTableAdapter.FillBy(dbDataSet.Invoice);
                MessageBox.Show("Good", "Resault", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви действительно хотите удалить накладную", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                item_InvoiceTableAdapter.DeleteItemInvoice((int)dataGridView1.CurrentRow.Cells[0].Value);
                item_InvoiceTableAdapter.Update(dbDataSet.Item_Invoice); //осуществляет удаление записей в БД
                item_InvoiceTableAdapter.FillBy(dbDataSet.Item_Invoice);
                MessageBox.Show("Good", "Resault", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
