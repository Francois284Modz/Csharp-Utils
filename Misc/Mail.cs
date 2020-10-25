using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Auth;
namespace ModMenu_Genarator
{
    class Mail
    {
        public static string SMTPMail  { get; set;}
        public static string SMTPServer { get; set; }
        public static string SMTPPassword  { get; set;}


    public static void SendMail(string subject,string message)
        {
            try
            {
                RzyProtector.Protector.AntiShit();
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(SMTPServer);

                mail.From = new MailAddress(Auth.UserInfo.Email);
                mail.To.Add(SMTPMail);
                mail.Subject = subject;
                mail.Body = message;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(SMTPMail, SMTPPassword);
                SmtpServer.EnableSsl = false;
                RzyProtector.Protector.AntiShit();
                SmtpServer.Send(mail);
                MessageBox.Show("Message Send with sucess  \nPlease beware you can get a answer on 24 hours or more","Mod Menu Generator",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
            }
            catch (Exception ex)
            {
               
                //MessageBox.Show("Message not send Server is not responding", "Mod Menu Generator",MessageBoxButtons.OK,MessageBoxIcon.Error);
                  MessageBox.Show(ex.ToString());
            }
        }
    }
}
