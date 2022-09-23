using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WpfLoginRapiD
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
        SqlConnection conn = new SqlConnection("Data Source=LAPTOP-IS69AVIT\\SQLEXPRESS;Initial Catalog=Rapid;Integrated Security=True;");
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txt_Password_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            String username, user_password;

            username = txt_Username.Text;
            user_password = txt_Password.Text;

            try
            {
                String querry = "SELECT * FROM loginrapid WHERE username = '" + txt_Username.Text + "' AND password = '" + txt_Password.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(querry, conn);

                DataTable dtable = new DataTable();
                sda.Fill(dtable);

                if (dtable.Rows.Count > 0)
                {
                    username = txt_Username.Text;
                    user_password = txt_Password.Text;


                    MainForm form2 = new MainForm();
                    form2.Show();
                    this.Hide();

                }
                else
                {
                    MessageBox.Show("Invalid login details", "Error");
                    txt_Username.Clear();
                    txt_Password.Clear();

                    txt_Username.Focus();
                }
            }

            catch
            {
                MessageBox.Show("Error");
            }

            finally
            {
                conn.Close();
            }
        }

        private void button_clear_Click(object sender, RoutedEventArgs e)

        {
            txt_Username.Clear();
            txt_Password.Clear();

            txt_Username.Focus();
        }

        private void button_exit_Click(object sender, RoutedEventArgs e)
        {

            {
                //System.Windows.Application.Current.Shutdown();
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Are you sure?", "Delete Confirmation", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                    System.Windows.Application.Current.Shutdown();

                else
                    this.Hide();
   

            }
        }

        private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            ChangePasswordForm form3 = new ChangePasswordForm();
            form3.Show();
            this.Hide();
        }
    }
}
