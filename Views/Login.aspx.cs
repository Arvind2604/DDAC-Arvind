using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace ExportManagementSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(TextBox1.Text) || string.IsNullOrWhiteSpace(TextBox2.Text))
                {
                    Response.Write("Username and Password cannot be blank!!!");

                }
                else if (IsPostBack)
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
                    conn.Open();
                    string checkuser = "select count(*) from User where Username = @username and Password = @password";
                    SqlCommand com = new SqlCommand(checkuser, conn);
                    com.Parameters.AddWithValue("@username", TextBox1.Text);
                    com.Parameters.AddWithValue("@password", TextBox2.Text);
                    int temp = Convert.ToInt32(com.ExecuteScalar().ToString());
                    if (temp == 1)
                    {
                        Response.Redirect("Main.aspx");
                        Response.Write("Login success!!!");
                    }
                    else
                    {
                        Response.Write("Wrong Username and Password!!!");
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
            Response.Redirect("Register.aspx");
        }
    }
}