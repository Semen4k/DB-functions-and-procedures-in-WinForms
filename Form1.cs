using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsAppLab3Pnet
{
   
    public partial class Form1 : Form
    { 
        private SqlConnection connectionForm1 = null;

        private SqlDataAdapter adapter = null;

        private DataTable table = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButtonShowBalloons_Click(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("SELECT * FROM Baloon", connectionForm1);
            table = new DataTable();
            adapter.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connectionForm1 = new SqlConnection(@"Data Source=SKA;Initial Catalog=BalloonShop;Integrated Security=True");

            connectionForm1.Open();

            adapter = new SqlDataAdapter("SELECT * FROM Baloon", connectionForm1);

            table = new DataTable();

            adapter.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void toolStripButtonShowClients_Click(object sender, EventArgs e)
        {
            adapter = new SqlDataAdapter("SELECT * FROM Customer", connectionForm1);

            table = new DataTable();

            adapter.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void toolStripButtonShowOrders_Click(object sender, EventArgs e)
        {
           
            adapter = new SqlDataAdapter(@"SELECT * FROM [Order]", connectionForm1);

            table = new DataTable();

            adapter.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void toolStripButtonAddSaleNumberProcedure_Click(object sender, EventArgs e)
        {
            AddSaleNumberForm saleNumberForm = new AddSaleNumberForm();
            saleNumberForm.ShowDialog();
        }

        private void toolStripButtonReduceCostOfThemedBalloons_Click(object sender, EventArgs e)
        {
            ReduceCostOfThemedBalloons reduceCostOfThemedBalloons = new ReduceCostOfThemedBalloons();
            reduceCostOfThemedBalloons.ShowDialog();
        }

        private void toolStripButtonCustomerFavoriteBalloon_Click(object sender, EventArgs e)
        {
            CustomerFavouriteBalloonForm customerFavouriteBalloonForm = new CustomerFavouriteBalloonForm();
            customerFavouriteBalloonForm.ShowDialog();
        }

        private void toolStripButtonTheBiggestOrder_Click(object sender, EventArgs e)
        {
            TheBiggestOrderForm theBiggestOrderForm = new TheBiggestOrderForm();
            theBiggestOrderForm.ShowDialog();
        }
    }
}
