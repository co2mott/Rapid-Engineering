using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Configuration;

namespace WpfLoginRapiD
{
    /// <summary>
    /// Interaction logic for ChangePasswordForm.xaml
    /// </summary>
    public partial class ChangePasswordForm : Window
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void TxtUsername_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-IS69AVIT\\SQLEXPRESS;Initial Catalog=Rapid;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("Update loginrapid set password=@password where ID = @ID", con);

                cmd.Parameters.AddWithValue("@ID", int.Parse(TxtID.Text));
                cmd.Parameters.AddWithValue("@password", TxtChangePassword.Text);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Succsesfully Updated");
            }
        }

        private void TxtCurrentPassword_Leave(object sender, TextChangedEventArgs e)
        {
        }

        private void TxtCurrentPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}