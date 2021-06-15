using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// AddTime.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AddTime : Window
    {
        public AddTime()
        {
            InitializeComponent();
            fillCombo();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main main = new Main();
            main.Show();
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string consql = "Server=localhost;Database=project01;Uid=root;Pwd=root;";
            MySqlConnection con = new MySqlConnection(consql);

            con.Open();

            try
            {


                string select = "select * from client" + " where id ='" + finduser.Text + "';";
                MySqlDataAdapter adp = new MySqlDataAdapter(select, con);

                //MySqlDataReader reader = cmd.ExecuteReader();

                DataSet ds = new DataSet();
                adp.Fill(ds);
                datagrid.ItemsSource = ds.Tables[0].DefaultView;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string consql = "Server=localhost;Database=project01;Uid=root;Pwd=root;";
            MySqlConnection con = new MySqlConnection(consql);

            con.Open();

            try
            {
                string query = "UPDATE client SET add_time ='" + combobox.Text + "'WHERE id ='" + finduser.Text + "';";
                    //(total_time, currenttime) VALUES('" + combobox.Text + "','" + combobox.Text + "')" + "WHERE id = '" + finduser.Text + "';";
                MySqlCommand cmd = new MySqlCommand(query, con);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("시간 추가가 완료되었습니다.");
                }
                else
                {
                    MessageBox.Show("시간 추가가 실패 하였습니다.");
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
            string query = "select * from addtimes";
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
                    string add_time = myreader.GetString("add_time");
                    combobox.Items.Add(add_time);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
