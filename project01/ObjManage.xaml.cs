using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data;
using System.Data;

namespace project01
{
    /// <summary>
    /// ObjManage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ObjManage : Window
    {
        public ObjManage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.Show();
            Close();
        }

        private void outdatagrid_Click(object sender, RoutedEventArgs e)
        {
            string consql = "Server=localhost;Database=project01;Uid=root;Pwd=root;";
            MySqlConnection con = new MySqlConnection(consql);

            con.Open();

            try
            {
                

                string select = "select * from objmanage";
                MySqlDataAdapter adp = new MySqlDataAdapter(select, con);

                //MySqlDataReader reader = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                adp.Fill(ds);
                datagrid.ItemsSource = ds.Tables[0].DefaultView;
                

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
