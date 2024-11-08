namespace ShopManager
{
    partial class frmLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogin_register = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.close = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtLogin_username = new System.Windows.Forms.TextBox();
            this.txtLogin_password = new System.Windows.Forms.TextBox();
            this.chkLogin_showpass = new System.Windows.Forms.CheckBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Controls.Add(this.btnLogin_register);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 540);
            this.panel1.TabIndex = 0;
            // 
            // btnLogin_register
            // 
            this.btnLogin_register.BackColor = System.Drawing.Color.DarkOrange;
            this.btnLogin_register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin_register.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin_register.ForeColor = System.Drawing.Color.Transparent;
            this.btnLogin_register.Location = new System.Drawing.Point(43, 463);
            this.btnLogin_register.Name = "btnLogin_register";
            this.btnLogin_register.Size = new System.Drawing.Size(309, 50);
            this.btnLogin_register.TabIndex = 0;
            this.btnLogin_register.Text = "REGISTER";
            this.btnLogin_register.UseVisualStyleBackColor = false;
            this.btnLogin_register.Click += new System.EventHandler(this.btnLogin_register_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(127, 434);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 26);
            this.label5.TabIndex = 2;
            this.label5.Text = "Create an Account";
            // 
            // close
            // 
            this.close.AutoSize = true;
            this.close.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Location = new System.Drawing.Point(773, 0);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(23, 23);
            this.close.TabIndex = 1;
            this.close.Text = "X";
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(448, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "SIGN IN";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(450, 287);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(450, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Username:";
            // 
            // txtLogin_username
            // 
            this.txtLogin_username.Location = new System.Drawing.Point(454, 220);
            this.txtLogin_username.Name = "txtLogin_username";
            this.txtLogin_username.Size = new System.Drawing.Size(297, 30);
            this.txtLogin_username.TabIndex = 4;
            // 
            // txtLogin_password
            // 
            this.txtLogin_password.Location = new System.Drawing.Point(454, 313);
            this.txtLogin_password.Name = "txtLogin_password";
            this.txtLogin_password.PasswordChar = '*';
            this.txtLogin_password.Size = new System.Drawing.Size(297, 30);
            this.txtLogin_password.TabIndex = 5;
            // 
            // chkLogin_showpass
            // 
            this.chkLogin_showpass.AutoSize = true;
            this.chkLogin_showpass.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLogin_showpass.Location = new System.Drawing.Point(454, 349);
            this.chkLogin_showpass.Name = "chkLogin_showpass";
            this.chkLogin_showpass.Size = new System.Drawing.Size(145, 24);
            this.chkLogin_showpass.TabIndex = 6;
            this.chkLogin_showpass.Text = "Show password";
            this.chkLogin_showpass.UseVisualStyleBackColor = true;
            this.chkLogin_showpass.CheckedChanged += new System.EventHandler(this.chkLogin_showpass_CheckedChanged);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.DarkOrange;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.Transparent;
            this.btnLogin.Location = new System.Drawing.Point(538, 414);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(111, 35);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 540);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.chkLogin_showpass);
            this.Controls.Add(this.txtLogin_password);
            this.Controls.Add(this.txtLogin_username);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.close);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtLogin_username;
        private System.Windows.Forms.TextBox txtLogin_password;
        private System.Windows.Forms.CheckBox chkLogin_showpass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnLogin_register;
        private System.Windows.Forms.Label label5;
    }
}

