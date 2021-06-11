using MySql.Data.MySqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace project01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //MySqlConnection conn = new MySqlConnection("Server=localhost;Databases=user;Uid=root;Pwd=root;");

        public MainWindow()
        {
            InitializeComponent();

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (id.Text=="admin" && pwd.Password=="admin")
            {

            Main main = new Main();
            main.Show();
            Close();

            } else
            {
                MessageBox.Show("아이디나 비밀번호가 틀렸습니다.");
            }
            
           
            
        }

    }
}
