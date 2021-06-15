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
    /// Seat02.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Seat02 : Window
    {
        public Seat02()
        {
            InitializeComponent();
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string consql = "Server=localhost;Database=project01;Uid=root;Pwd=root;";
                MySqlConnection con = new MySqlConnection(consql);

                con.Open();

                string select = "select * from client" + " where id ='" + id.Text + "'and pwd='" + pwd.Text + "';";

                MySqlCommand cmd = new MySqlCommand(select, con);

                MySqlDataReader reader = cmd.ExecuteReader();
               
                if(reader.Read())
                {
                    if(id.Text == reader["id"].ToString() && pwd.Text == reader["pwd"].ToString())
                    {
                        MessageBox.Show("로그인 성공");

                        /*if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("로그인 성공.");
                        }
                        else
                        {
                            MessageBox.Show("로그인 실패.");
                        }*/

                        //Main

                        Main main = new Main();
                        main.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("로그인 실패");
                    }
                    


                }
                con.Close();
                     
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
  
    
}
