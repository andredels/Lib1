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
        public ForgotPassword()
        {
            InitializeComponent();
        }
        private string generatedCode;
        private string userEmail;

        private void btnSendCode_Click(object sender, EventArgs e)
        {
            /*userEmail = txtbxEmail.TextValue.Trim();

            if (string.IsNullOrEmpty(userEmail))
            {
                MessageBox.Show("Please enter your email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if email exists in the database
            string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
            OleDbParameter[] parameters = { new OleDbParameter("@Email", userEmail) };

            using (OleDbDataReader reader = DatabaseHelper.ExecuteQuery(query, parameters))
            {
                reader.Read();
                int count = Convert.ToInt32(reader[0]);

                if (count == 0)
                {
                    MessageBox.Show("Email not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            // Generate a 6-digit verification code
            Random random = new Random();
            generatedCode = random.Next(100000, 999999).ToString();

            try
            {
                // Configure the SMTP client (Use your Gmail, Outlook, or SMTP provider)
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("dredels1@gmail.com", "hubi okyc ohdx dmtc"); // Use an app password!
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

                // Create the email message
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
            }*/

        }

        private void btnVerifyCode_Click(object sender, EventArgs e)
        {
            /*if (txtbxVerificationCode.TextValue.Trim() == generatedCode)
            {
                isVerified = true;
                MessageBox.Show("Verification successful! You can now reset your password.", "Verified", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Incorrect verification code!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            /*if (!isVerified)
            {
                MessageBox.Show("Please verify your email first by entering the correct verification code!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newPassword = tbxNewPassword.TextValue.Trim();
            string confirmPassword = tbxConfirmPassword.TextValue.Trim();

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Encrypt the new password before saving
            string encryptedPassword = SecurityHelper.EncryptPassword(newPassword);

            string query = "UPDATE [Users Table] SET [Password] = @Password WHERE Email = @Email";
            OleDbParameter[] parameters = {
        new OleDbParameter("@Password", encryptedPassword),
        new OleDbParameter("@Email", userEmail)
    };

            if (DatabaseHelper.ExecuteNonQuery(query, parameters))
            {
                MessageBox.Show("Password successfully reset! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to reset password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();*/
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }
    }
}
