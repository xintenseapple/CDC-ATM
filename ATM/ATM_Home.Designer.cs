
namespace ATM
{
    partial class ATM_Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gb_user = new System.Windows.Forms.GroupBox();
            this.cb_accounts = new System.Windows.Forms.ComboBox();
            this.l_bal = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_checkNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.b_deposit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_deposit = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.b_withdraw = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_withdraw = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cb_otherUsersAccounts = new System.Windows.Forms.ComboBox();
            this.cb_otherUsers = new System.Windows.Forms.ComboBox();
            this.b_transfer = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_transfer = new System.Windows.Forms.TextBox();
            this.b_logout = new System.Windows.Forms.Button();
            this.gb_user.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_user
            // 
            this.gb_user.Controls.Add(this.cb_accounts);
            this.gb_user.Controls.Add(this.l_bal);
            this.gb_user.Location = new System.Drawing.Point(3, 0);
            this.gb_user.Name = "gb_user";
            this.gb_user.Size = new System.Drawing.Size(200, 100);
            this.gb_user.TabIndex = 0;
            this.gb_user.TabStop = false;
            this.gb_user.Text = "Account and Account Info";
            // 
            // cb_accounts
            // 
            this.cb_accounts.FormattingEnabled = true;
            this.cb_accounts.Location = new System.Drawing.Point(6, 32);
            this.cb_accounts.MaxDropDownItems = 100;
            this.cb_accounts.Name = "cb_accounts";
            this.cb_accounts.Size = new System.Drawing.Size(188, 23);
            this.cb_accounts.TabIndex = 1;
            this.cb_accounts.SelectedIndexChanged += new System.EventHandler(this.cb_accounts_SelectedIndexChanged);
            // 
            // l_bal
            // 
            this.l_bal.AutoSize = true;
            this.l_bal.Location = new System.Drawing.Point(6, 69);
            this.l_bal.Name = "l_bal";
            this.l_bal.Size = new System.Drawing.Size(103, 15);
            this.l_bal.TabIndex = 0;
            this.l_bal.Text = "You\'re Broke lmao";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_checkNum);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.b_deposit);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tb_deposit);
            this.groupBox2.Location = new System.Drawing.Point(3, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 134);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Deposit";
            // 
            // tb_checkNum
            // 
            this.tb_checkNum.Location = new System.Drawing.Point(59, 37);
            this.tb_checkNum.Name = "tb_checkNum";
            this.tb_checkNum.PlaceholderText = "1234567890";
            this.tb_checkNum.Size = new System.Drawing.Size(135, 23);
            this.tb_checkNum.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Check Number";
            // 
            // b_deposit
            // 
            this.b_deposit.Location = new System.Drawing.Point(119, 95);
            this.b_deposit.Name = "b_deposit";
            this.b_deposit.Size = new System.Drawing.Size(75, 23);
            this.b_deposit.TabIndex = 4;
            this.b_deposit.Text = "Deposit";
            this.b_deposit.UseVisualStyleBackColor = true;
            this.b_deposit.Click += new System.EventHandler(this.b_deposit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "$";
            // 
            // tb_deposit
            // 
            this.tb_deposit.Location = new System.Drawing.Point(59, 66);
            this.tb_deposit.Name = "tb_deposit";
            this.tb_deposit.PlaceholderText = "00.00";
            this.tb_deposit.Size = new System.Drawing.Size(135, 23);
            this.tb_deposit.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.b_withdraw);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tb_withdraw);
            this.groupBox3.Location = new System.Drawing.Point(209, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Withdraw";
            // 
            // b_withdraw
            // 
            this.b_withdraw.Location = new System.Drawing.Point(119, 61);
            this.b_withdraw.Name = "b_withdraw";
            this.b_withdraw.Size = new System.Drawing.Size(75, 23);
            this.b_withdraw.TabIndex = 1;
            this.b_withdraw.Text = "Withdraw";
            this.b_withdraw.UseVisualStyleBackColor = true;
            this.b_withdraw.Click += new System.EventHandler(this.b_withdraw_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "$";
            // 
            // tb_withdraw
            // 
            this.tb_withdraw.Location = new System.Drawing.Point(94, 32);
            this.tb_withdraw.Name = "tb_withdraw";
            this.tb_withdraw.PlaceholderText = "00.00";
            this.tb_withdraw.Size = new System.Drawing.Size(100, 23);
            this.tb_withdraw.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cb_otherUsersAccounts);
            this.groupBox4.Controls.Add(this.cb_otherUsers);
            this.groupBox4.Controls.Add(this.b_transfer);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.tb_transfer);
            this.groupBox4.Location = new System.Drawing.Point(209, 106);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 134);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Transfer";
            // 
            // cb_otherUsersAccounts
            // 
            this.cb_otherUsersAccounts.FormattingEnabled = true;
            this.cb_otherUsersAccounts.Location = new System.Drawing.Point(6, 66);
            this.cb_otherUsersAccounts.Name = "cb_otherUsersAccounts";
            this.cb_otherUsersAccounts.Size = new System.Drawing.Size(188, 23);
            this.cb_otherUsersAccounts.TabIndex = 9;
            // 
            // cb_otherUsers
            // 
            this.cb_otherUsers.FormattingEnabled = true;
            this.cb_otherUsers.Location = new System.Drawing.Point(6, 37);
            this.cb_otherUsers.Name = "cb_otherUsers";
            this.cb_otherUsers.Size = new System.Drawing.Size(188, 23);
            this.cb_otherUsers.TabIndex = 8;
            this.cb_otherUsers.SelectedIndexChanged += new System.EventHandler(this.cb_otherUsers_SelectedIndexChanged);
            // 
            // b_transfer
            // 
            this.b_transfer.Location = new System.Drawing.Point(119, 95);
            this.b_transfer.Name = "b_transfer";
            this.b_transfer.Size = new System.Drawing.Size(75, 23);
            this.b_transfer.TabIndex = 7;
            this.b_transfer.Text = "Transfer";
            this.b_transfer.UseVisualStyleBackColor = true;
            this.b_transfer.Click += new System.EventHandler(this.b_transfer_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Destination Account Number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(13, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "$";
            // 
            // tb_transfer
            // 
            this.tb_transfer.Location = new System.Drawing.Point(19, 95);
            this.tb_transfer.Name = "tb_transfer";
            this.tb_transfer.PlaceholderText = "00.00";
            this.tb_transfer.Size = new System.Drawing.Size(94, 23);
            this.tb_transfer.TabIndex = 6;
            // 
            // b_logout
            // 
            this.b_logout.Location = new System.Drawing.Point(6, 246);
            this.b_logout.Name = "b_logout";
            this.b_logout.Size = new System.Drawing.Size(403, 23);
            this.b_logout.TabIndex = 8;
            this.b_logout.Text = "Logout";
            this.b_logout.UseVisualStyleBackColor = true;
            this.b_logout.Click += new System.EventHandler(this.b_logout_Click);
            // 
            // ATM_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 282);
            this.ControlBox = false;
            this.Controls.Add(this.b_logout);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gb_user);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ATM_Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ATM Home";
            this.gb_user.ResumeLayout(false);
            this.gb_user.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_user;
        private System.Windows.Forms.Label l_bal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button b_deposit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_deposit;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button b_withdraw;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_withdraw;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_checkNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button b_transfer;
        private System.Windows.Forms.Button b_logout;
        private System.Windows.Forms.ComboBox cb_accounts;
        private System.Windows.Forms.ComboBox cb_otherUsersAccounts;
        private System.Windows.Forms.ComboBox cb_otherUsers;
        private System.Windows.Forms.TextBox tb_transfer;
    }
}