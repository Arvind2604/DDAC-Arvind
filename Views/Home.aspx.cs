using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace ExportManagementSystem.Views
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                conn.Open();
                string showAll = "select count(*) from ShipmentDetail";
                SqlCommand com = new SqlCommand(showAll, conn);
                conn.Close();
            }
            catch (Exception ex)
            {
                Response.Write("Please try again!!!");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text) ||
                    string.IsNullOrWhiteSpace(TextBox3.Text) || string.IsNullOrWhiteSpace(TextBox4.Text) ||
                    string.IsNullOrWhiteSpace(TextBox5.Text) || string.IsNullOrWhiteSpace(TextBox6.Text) ||
                    string.IsNullOrWhiteSpace(TextBox7.Text))
                {
                    Response.Write("The Boxes cannot be blank!!!");

                }
                else if (IsPostBack)
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    conn.Open();
                    string checkID = "select count(*) from ShipmentDetail where ShipmentID ='" + TextBox1.Text + "'";
                    SqlCommand com = new SqlCommand(checkID, conn);
                    int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                    if (temp == 1)
                    {
                        Response.Write("ShipmentID already exists!!!");
                    }
                    else
                    {
                        string insertQuery = "insert into ShipmentDetail(ShipmentID, ShipmentDate, ShipmentTime, ShipmentLocation, DestinationDate, DestinationTime, DestinationLocation) values (@v1, @v2, @v3, @v4, @v5, @v6, @v7)";
                        com = new SqlCommand(insertQuery, conn);
                        com.Parameters.AddWithValue("@v1", TextBox1.Text);
                        com.Parameters.AddWithValue("@v2", TextBox2.Text);
                        com.Parameters.AddWithValue("@v3", TextBox3.Text);
                        com.Parameters.AddWithValue("@v4", TextBox4.Text);
                        com.Parameters.AddWithValue("@v5", TextBox5.Text);
                        com.Parameters.AddWithValue("@v6", TextBox6.Text);
                        com.Parameters.AddWithValue("@v7", TextBox7.Text);

                        com.ExecuteNonQuery();
                        Response.Redirect("Home.aspx");
                        Response.Write("New shipment added successful!!!");
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Response.Write("Please try again!!!");
            }
            finally
            {
                GridView1.DataBind();
            }
        }
    }
}