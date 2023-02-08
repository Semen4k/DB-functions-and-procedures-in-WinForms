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
    public partial class ReduceCostOfThemedBalloons : Form
    {
        private SqlConnection connectionRCTBForm = null;

        public ReduceCostOfThemedBalloons()
        {
            InitializeComponent();
        }

        private void ReduceCostConfirmbutton_Click(object sender, EventArgs e)
        {
            connectionRCTBForm = new SqlConnection(@"Data Source=SKA;Initial Catalog=BalloonShop;Integrated Security=True");
            connectionRCTBForm.Open();

            string sqlExpression = "reduce_the_cost_of_themed_balloons";
            string balloonName;
            int saleNum;

            balloonName = textBoxProductTheme.Text;
            saleNum = Int32.Parse(textBoxPercentNumberRCOTB.Text);

            SqlCommand reduceCostOfThemedBalloons = new SqlCommand(sqlExpression, connectionRCTBForm);
            reduceCostOfThemedBalloons.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter nameParameter = new SqlParameter
            {
                ParameterName = "@balloons_topic",
                Value = balloonName
            };

            reduceCostOfThemedBalloons.Parameters.Add(nameParameter);

            SqlParameter saleNumParameter = new SqlParameter
            {
                ParameterName = "@sale_percent",
                Value = saleNum
            };

            reduceCostOfThemedBalloons.Parameters.Add(saleNumParameter);

            reduceCostOfThemedBalloons.ExecuteNonQuery();

            Close();
        }
    }
    
}
