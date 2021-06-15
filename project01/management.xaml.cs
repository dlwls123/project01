﻿using MySql.Data.MySqlClient;
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
    /// management.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class management : Window
    {
        public management()
        {
            InitializeComponent();
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
    }
}
