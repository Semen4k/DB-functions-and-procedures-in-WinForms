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
using Microsoft.SqlServer.Server;

namespace WindowsFormsAppLab3Pnet
{
    public partial class CustomerFavouriteBalloonForm : Form
    {
        private SqlConnection connectionCFBForm = null;
        public CustomerFavouriteBalloonForm()
        {
            InitializeComponent();
        }

        private void buttonConfirmFavouriteBalloon_Click(object sender, EventArgs e)
        {
            connectionCFBForm = new SqlConnection(@"Data Source=SKA;Initial Catalog=BalloonShop;Integrated Security=True");
            connectionCFBForm.Open();

            int customerID = Int32.Parse(textBoxCustomerIDCustomerFavouriteBalloonForm.Text);
            string sqlExpression = $"select BalloonShop.dbo.customer_favorite_balloon({customerID});";

            SqlCommand commandConfirmFavouriteBalloon = new SqlCommand(sqlExpression, connectionCFBForm);
            
            textBoxResult.Text = (string)commandConfirmFavouriteBalloon.ExecuteScalar();
        }
    }
}
