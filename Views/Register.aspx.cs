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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text) ||
                    string.IsNullOrWhiteSpace(TextBox3.Text) || string.IsNullOrWhiteSpace(TextBox4.Text))
                {
                    Response.Write("Username, Password, Name, and Gender cannot be blank!!!");

                }
                else if (IsPostBack)
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    conn.Open();
                    string checkuser = "select count(*) from User where Username ='" + TextBox1.Text + "'";
                    SqlCommand com = new SqlCommand(checkuser, conn);
                    int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                    if (temp == 1)
                    {
                        Response.Write("User already exists!!!");
                    }
                    else
                    {
                        string insertQuery = "insert into User(Username, Password, Name, Gender) values (@username, @password, @name, @gender)";
                        com = new SqlCommand(insertQuery, conn);
                        com.Parameters.AddWithValue("@username", TextBox1.Text);
                        com.Parameters.AddWithValue("@password", TextBox2.Text);
                        com.Parameters.AddWithValue("@name", TextBox3.Text);
                        com.Parameters.AddWithValue("@gender", TextBox4.Text);

                        com.ExecuteNonQuery();
                        Response.Redirect("Main.aspx");
                        Response.Write("Register success!!!");
                    }
                    conn.Close();
                }
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
    }
}