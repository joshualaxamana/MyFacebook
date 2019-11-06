using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net.Mail;
using System.Security.Cryptography;

namespace MyFacebook_LaxamanaJ
{
    class Sir
    {
        /// <summary>
        ///Allows you to get the connection string
        ///value from your app.config file
        /// </summary>
        /// <returns>A connection string value</returns>
        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString;
        }

        public static void SendEmail(string email, string subject, string message)
        {
            MailMessage emailMessage = new MailMessage();
            emailMessage.From = new MailAddress("isprog2@gmail.com", "The Administrator");
            emailMessage.To.Add(new MailAddress(email));
            emailMessage.Subject = subject;
            emailMessage.Body = message;
            emailMessage.IsBodyHtml = true;
            emailMessage.Priority = MailPriority.Normal;
            SmtpClient MailClient = new SmtpClient("smtp.gmail.com", 587);
            MailClient.EnableSsl = true;
            MailClient.Credentials = new System.Net.NetworkCredential("isprog2@gmail.com", "thisisaverylongpassword");
            MailClient.Send(emailMessage);

        }

        public static string CreateSHAHash(string Phrase)
        {
            SHA512Managed HashTool = new SHA512Managed();
            Byte[] PhraseAsByte = System.Text.Encoding.UTF8.GetBytes(string.Concat(Phrase));
            Byte[] EncryptedBytes = HashTool.ComputeHash(PhraseAsByte);
            HashTool.Clear();
            return Convert.ToBase64String(EncryptedBytes);
        }
    }
}
