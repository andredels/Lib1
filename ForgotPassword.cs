using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Data.OleDb;
using System.Net;
using static QRCoder.PayloadGenerator;

namespace Lib1
{
    public partial class ForgotPassword : Form
    {
        private bool isVerified = false;
        private string generatedCode;
        private string userEmail;
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Andre\Documents\Library.accdb;";

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            userEmail = txtbxEmail.Text.Trim();

            if (string.IsNullOrEmpty(userEmail))
            {
                MessageBox.Show("Please enter your email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool emailExistsAndApproved = false;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE Email = ? AND ApprovalStatus = 'Approved'";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", userEmail);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    emailExistsAndApproved = count > 0;
                }
            }

            if (!emailExistsAndApproved)
            {
                MessageBox.Show("Email not found or account not approved!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Random random = new Random();
            generatedCode = random.Next(100000, 999999).ToString();

            try
            {
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("dredels1@gmail.com", "hubi okyc ohdx dmtc"); // Use your app password!
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("dredels1@gmail.com");
                mail.To.Add(userEmail);
                mail.Subject = "Password Reset Verification Code";
                mail.Body = $"Your verification code is: {generatedCode}";

                smtp.Send(mail);

                MessageBox.Show("Verification code sent! Check your email.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error sending email: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVerifyCode_Click(object sender, EventArgs e)
        {
            if (txtbxVerificationCode.Text.Trim() == generatedCode)
            {
                isVerified = true;
                MessageBox.Show("Verification successful! You can now reset your password.", "Verified", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Incorrect verification code!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if (!isVerified)
            {
                MessageBox.Show("Please verify your email first by entering the correct verification code!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newPassword = txtbxNewPassword.Text.Trim();
            string confirmPassword = txtbxVerifyNewPassword.Text.Trim();

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string hashedPassword = SecurityHelper.HashPassword(newPassword);

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET [Password] = ? WHERE Email = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("?", hashedPassword);
                    cmd.Parameters.AddWithValue("?", userEmail);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Password successfully reset! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        Form1 form1 = new Form1();
                        form1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Failed to reset password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
