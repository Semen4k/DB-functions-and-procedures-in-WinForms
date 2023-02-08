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
    public partial class AddSaleNumberForm : Form
    {
        private SqlConnection connectionADSNForm = null;



        public AddSaleNumberForm()
        {
            InitializeComponent();
        }

        private void AddSaleNumConfirmbutton_Click(object sender, EventArgs e)
        {
            connectionADSNForm = new SqlConnection(@"Data Source=SKA;Initial Catalog=BalloonShop;Integrated Security=True");
            connectionADSNForm.Open();

            string sqlExpression = "add_sale_number";
            string balloonName, saleNum;

            balloonName = textBoxProductName.Text;
            saleNum = textBoxPercentNumber.Text;

            SqlCommand addSaleNumber = new SqlCommand(sqlExpression, connectionADSNForm);
            addSaleNumber.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter nameParameter = new SqlParameter
            {
                ParameterName = "@product_name", 
                Value = balloonName
            };

            addSaleNumber.Parameters.Add(nameParameter);

            SqlParameter saleNumParameter = new SqlParameter
            {
                ParameterName = "@percent_number",
                Value = saleNum
            };

            addSaleNumber.Parameters.Add(saleNumParameter);

            addSaleNumber.ExecuteNonQuery();

            Close();
        }
    }
}
