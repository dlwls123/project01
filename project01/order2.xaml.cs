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

namespace project01
{
    /// <summary>
    /// order2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class order2 : Window
    {
        public order2()
        {
            InitializeComponent();
            fillCombo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string consql = "Server=localhost;Database=project01;Uid=root;Pwd=root;";
            MySqlConnection con = new MySqlConnection(consql);

            con.Open();

            try
            {
                string insert = "INSERT INTO orders(count, ob_name) VALUES('" + count.Text + "','" + combobox.Text + "')";
                //(total_time, currenttime) VALUES('" + combobox.Text + "','" + combobox.Text + "')" + "WHERE id = '" + finduser.Text + "';";
                MySqlCommand cmd = new MySqlCommand(insert, con);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("주문을 완료하였습니다.");

                    Close();
                }
                else
                {
                    MessageBox.Show("주문을 실패 하였습니다.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void fillCombo()
        {
            string consql = "Server=localhost;Database=project01;Uid=root;Pwd=root;";
            string query = "select * from objmanage";
            MySqlConnection con = new MySqlConnection(consql);
            MySqlCommand cmd = new MySqlCommand(query, con);
            //MySqlDataReader myreader;

            try
            {

                con.Open();
                //myreader = con.ExecuteReader();
                MySqlDataReader myreader = cmd.ExecuteReader();

                while (myreader.Read())
                {
                    string ob_name = myreader.GetString("ob_name");
                    combobox.Items.Add(ob_name);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
