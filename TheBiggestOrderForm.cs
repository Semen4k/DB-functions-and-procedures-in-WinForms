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
    public partial class TheBiggestOrderForm : Form
    {
        private SqlConnection connectionTBOForm = null;
        private SqlDataAdapter adapter = null;
        private DataTable table = null;

        public TheBiggestOrderForm()
        {
            InitializeComponent();
        }

        private void buttonConfirmFavouriteBalloon_Click(object sender, EventArgs e)
        {
            connectionTBOForm = new SqlConnection(@"Data Source=SKA;Initial Catalog=BalloonShop;Integrated Security=True");
            connectionTBOForm.Open();

            int balloonID = Int32.Parse(textBoxTheBiggestOrder.Text);
            string sqlCommandTBO = $"select * FROM[BalloonShop].[dbo].[THE_BIGGEST_ORDER_TABLE]({balloonID});";

            adapter = new SqlDataAdapter(sqlCommandTBO, connectionTBOForm);

            table = new DataTable();

            adapter.Fill(table);

            dataGridViewTheBiggestOrder.DataSource = table;
        }
    }
}
