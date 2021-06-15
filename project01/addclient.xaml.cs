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
    /// addclient.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class addclient : Window
    {
        


        public addclient()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (id.Text != null && name.Text != null && pwd.Text != null && phone.Text != null && birth.Text != null)
            {
                try
                {
                    string consql = "Server=localhost;Database=project01;Uid=root;Pwd=root;";
                    MySqlConnection con = new MySqlConnection(consql);

                    con.Open();

                    //MessageBox.Show("데베 연결이 잘 됨");

                    string insert = "INSERT INTO client(name, id, pwd, phone, birth) VALUES('" + name.Text + "','" + id.Text + "','" + pwd.Text + "','" + phone.Text + "','" + birth.Text +"')";
                    MySqlCommand cmd = new MySqlCommand(insert, con);

                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("회원 추가가 완료되었습니다.");
                        }
                        else
                        {
                            MessageBox.Show("회원 추가가 실패 하였습니다.");
                        }

                    Main main = new Main();
                    main.Show();
                    Close();
                    con.Close();
   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        
            }
            else
            {
                MessageBox.Show("모든 항목을 입력해주세요");
            }
           
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main main = new Main();
            main.Show();
            Close();
        }
    }
}
