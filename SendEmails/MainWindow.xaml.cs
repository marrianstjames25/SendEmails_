using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SendEmails
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Send(object sender, RoutedEventArgs e)
        {
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("marrianstjames@gmail.com");
                msg.To.Add(txtTo.Text);
                msg.Subject = txtSubject.Text;
                msg.Body = txtBody.Text;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                NetworkCredential ntcd = new NetworkCredential();
                ntcd.UserName = "marrianstjames@gmail.com";
                ntcd.Password = "";// the password here you take from visiting ->myaccount.google.com->security->app passwords->create a new one and copy paste it here

                smtp.Credentials = ntcd;
                smtp.Port = 587;
                smtp.Send(msg);

                MessageBox.Show("Successfully sent");


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            txtTo.Text = string.Empty;
            txtSubject.Text = "";
            txtBody.Text = string.Empty;    
        }
    }
}
