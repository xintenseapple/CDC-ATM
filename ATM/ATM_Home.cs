using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RabbitMQ.Client;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace ATM
{
    public partial class ATM_Home : Form
    {
        private long userID = -1;

        decimal bal = 0.00m;
        private long accountID = -1;
        private IModel channel;
        public ATM_Home(long userNum, String name)
        {
            InitializeComponent();
            //get account bal and set to global var

            // Remove hard-coded password and add to config file at least
            ConnectionFactory cf = new ConnectionFactory()
            {
                HostName = Program.rabbitmqIP, 
                UserName = Program.rabbitUser, 
                Password = Program.rabbitPass
            };
            var connection = cf.CreateConnection();
            channel = connection.CreateModel();
            channel.QueueDeclare("transfer.jobs", true, false, false, null);
            channel.BasicAcks += (sender, EventArgs) =>
            {
                //MessageBox.Show(sender.ToString());
            };
            channel.ConfirmSelect();

            gb_user.Text = name + "'s Accounts";
            userID = userNum;
            Program.connection.Open();
            SqlCommand cmd;
            SqlDataReader data;
            String sql;
            
            // Prepared statement!
            cmd = new SqlCommand(null, Program.connection);
            cmd.CommandText = "Select * from [banko].[dbo].[users] where username = '@username'";
            SqlParameter username = new SqlParameter("@username", SqlDbType.Text);
            username.Value = userID;

            cmd.Parameters.Add(username);
            cmd.Prepare();

            data = cmd.ExecuteReader();
            while (data.Read())
            {
                cb_accounts.Items.Add(data["name"].ToString());
            }
            Program.connection.Close();

            Program.connection.Open();

            sql = "Select * from [banko].[dbo].[users]";
            cmd = new SqlCommand(sql, Program.connection);
            data = cmd.ExecuteReader();
            while (data.Read())
            {
                cb_otherUsers.Items.Add(data["name"].ToString());
            }
            Program.connection.Close();

            cb_accounts.SelectedIndex = 0;
            updatebal();
        }

        private void b_withdraw_Click(object sender, EventArgs e)
        {
            decimal withdraw;
            if (!decimal.TryParse(tb_withdraw.Text, out withdraw) && withdraw < 0.00m)
            {
                MessageBox.Show("Invalid input!");
            }
            else if (withdraw > bal)
            {
                MessageBox.Show("Insufficent Funds!");
            }
            else
            {
                //bal -= withdraw;
                //send updated balence
                var json = JsonConvert.SerializeObject(new { Action = "Withdraw", AccountID = accountID, amount = withdraw });
                //MessageBox.Show(json);
                channel.BasicPublish(exchange: "", routingKey: "transfer.jobs", mandatory: false, basicProperties: null, body: Encoding.UTF8.GetBytes(json));
                channel.WaitForConfirmsOrDie();
                //MessageBox.Show("Past Confirm or Die");
            }
            updatebal();
        }

        private void b_deposit_Click(object sender, EventArgs e)
        {
            int checkNum = 0;
            decimal deposit;
            if (!decimal.TryParse(tb_deposit.Text, out deposit) && !int.TryParse(tb_checkNum.Text, out checkNum) && deposit < 0.00m)
            {
                MessageBox.Show("Invalid input!");
            }
            else if ((checkNum != 0))
            {
                MessageBox.Show("This check has already been cashed!");
            }
            else
            {
                //bal += deposit;
                //send updated balence and check number to prevent duplicate checks from being entered
                var json = JsonConvert.SerializeObject(new { Action = "Deposit", AccountID = accountID, amount = deposit, checkID = tb_checkNum.Text});
                //MessageBox.Show(json);
                channel.BasicPublish(exchange: "", routingKey: "transfer.jobs", mandatory: false, basicProperties: null, body: Encoding.UTF8.GetBytes(json));
                channel.WaitForConfirmsOrDie();
            }
            updatebal();
        }

        private void b_transfer_Click(object sender, EventArgs e)
        {
            decimal transfer = 0.00m;
            if (cb_otherUsersAccounts.SelectedIndex <= -1)
            {
                MessageBox.Show("Please select a user and account to transfer money to");
            }
            else if (!decimal.TryParse(tb_transfer.Text, out transfer) || transfer < 0.00m)
            {
                MessageBox.Show("Invalid input!");
            }
            else if(transfer > bal)
            {
                MessageBox.Show("Insufficent Funds");
            }
            else
            {
                long destinationAccountID = -1;
                Program.connection.Open();
                SqlCommand cmd;
                SqlDataReader data;
                
                // Prepared Statement
                cmd = new SqlCommand(null, Program.connection);
                cmd.CommandText = 
                    "Select account_id from [banko].[dbo].[accounts] where owner_id in ( select owner_id from users where name = '@name')";
                SqlParameter name = new SqlParameter("@name", SqlDbType.Text);
                name.Value = cb_otherUsers.Text;

                cmd.Parameters.Add(name);
                cmd.Prepare();
                
                data = cmd.ExecuteReader();
                while (data.Read())
                { 
                    destinationAccountID = (long)data["account_id"];
                }
                Program.connection.Close();

                var json = JsonConvert.SerializeObject(new { Action = "Transfer", AccountID = accountID, amount = transfer, DestinationAccountID = destinationAccountID });
                //MessageBox.Show(json);
                channel.BasicPublish(exchange: "", routingKey: "transfer.jobs", mandatory: false, basicProperties: null, body: Encoding.UTF8.GetBytes(json));
                channel.WaitForConfirmsOrDie();
                updatebal();
            }
        }

        private void b_logout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cb_accounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatebal();
        }

        private void updatebal()
        {
            //get updated balence
            Program.connection.Open();
            SqlCommand cmd;
            SqlDataReader data;

            cmd = new SqlCommand(null, Program.connection);
            cmd.CommandText = "Select * from [banko].[dbo].[accounts] where owner_id = '@userID' and name = '@name'";
            
            SqlParameter userid = new SqlParameter("@userID", SqlDbType.Text);
            userid.Value = userID;

            SqlParameter name = new SqlParameter("@name", SqlDbType.Text);
            name.Value = cb_accounts.Text;

            cmd.Parameters.Add(userid);
            cmd.Parameters.Add(name);
            cmd.Prepare();
            
            data = cmd.ExecuteReader();
            while (data.Read())
            {
                bal = (decimal)data["amount"];
                accountID = (long)data["account_id"];
            }
            Program.connection.Close();

            l_bal.Text = "$" + bal.ToString();
            tb_checkNum.Text = string.Empty;
            tb_deposit.Text = string.Empty;
            tb_transfer.Text = string.Empty;
            tb_withdraw.Text = string.Empty;
        }

        private long getAccountID()
        {
            long accntID = -1;
            Program.connection.Open();
            SqlCommand cmd;
            SqlDataReader data;

            // Prepared Statement
            cmd = new SqlCommand(null, Program.connection);
            cmd.CommandText = 
                "Select account_id from [banko].[dbo].[accounts] where owner_id = '@userid' and name = '@name'";
            
            SqlParameter userid = new SqlParameter("@userID", SqlDbType.Text);
            userid.Value = userID;

            SqlParameter name = new SqlParameter("@name", SqlDbType.Text);
            name.Value = cb_accounts.Text;
            
            cmd.Parameters.Add(userid);
            cmd.Parameters.Add(name);
            cmd.Prepare();
            
            data = cmd.ExecuteReader();
            while (data.Read())
            {
                accntID = (long)data.GetValue(0);
            }
            Program.connection.Close();
            return accntID;
        }

        private void cb_otherUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            cb_otherUsersAccounts.Items.Clear();
            Program.connection.Open();
            SqlCommand cmd;
            SqlDataReader data;
            
            // Prepared Statement
            //sql = "Select name from [banko].[dbo].[accounts] where owner_id = " + cb_otherUsers.Text + "";
            cmd = new SqlCommand(null, Program.connection);
            cmd.CommandText = 
                "Select * from accounts where owner_id in ( select user_id from users where name = '@name')";
            
            SqlParameter name = new SqlParameter("@name", SqlDbType.Text);
            name.Value = cb_accounts.Text;
            
            cmd.Parameters.Add(name);
            cmd.Prepare();

            data = cmd.ExecuteReader();
            while (data.Read())
            {
                cb_otherUsersAccounts.Items.Add(data["name"].ToString());
            }
            Program.connection.Close();
            try { cb_otherUsersAccounts.SelectedIndex = 0; } catch (Exception es) { }
            
        }
    }
}
