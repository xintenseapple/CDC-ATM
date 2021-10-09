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
using System.Security.Cryptography;


namespace ATM
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void b_login_Click(object sender, EventArgs e)
        {
            try
            {
                if(String.IsNullOrEmpty(tb_password.Text)|| String.IsNullOrEmpty(tb_username.Text))
                {
                    MessageBox.Show("Username and/or Password cannot be blank");
                    return;
                }
                Program.connection.Open();
                SqlCommand cmd;
                SqlDataReader data;
                String sql, user = "", pass = "", name = "";
                long userID = -1;
                
                // Prepared statement
                cmd = new SqlCommand(null, Program.connection);
                cmd.CommandText = "Select * from [banko].[dbo].[users] where username = '@username'";
                SqlParameter username = new SqlParameter("@username", SqlDbType.Text);
                username.Value = tb_username.Text;

                cmd.Parameters.Add(username);
                cmd.Prepare();
                
                data = cmd.ExecuteReader();
                while (data.Read())
                {
                    user += data.GetValue(0);
                    pass += data.GetValue(1);
                    name += data["name"].ToString();
                    userID = (long)data.GetValue(3);
                }
                Program.connection.Close();
                
                // Hashed password check (would require changes to API and current database data!
                if (ComputeHash(tb_password.Text) == pass && tb_username.Text == user)
                {
                    this.Hide();
                    ATM_Home home = new ATM_Home(userID, name);
                    home.ShowDialog();
                    this.Show();
                    tb_username.Text = string.Empty;
                    tb_password.Text = string.Empty;
                }
                else
                {
                    failedLogin();
                }
            }
            catch(Exception es)
            {
                MessageBox.Show(es.ToString());
                failedLogin();
            }

        }
        private void failedLogin()
        {
            MessageBox.Show("Invalid login creds\nPlease try again.");
            tb_username.Text = string.Empty;
            tb_password.Text = string.Empty;
        }
        
        private static string ComputeHash(string input) {
            using (HashAlgorithm algorithm = new SHA256Managed())
                return BitConverter.ToString(algorithm.ComputeHash(Encoding.UTF8.GetBytes(input)));
        }
    }
}
