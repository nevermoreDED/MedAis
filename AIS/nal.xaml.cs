using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace AIS
{
    /// <summary>
    /// Логика взаимодействия для nal.xaml
    /// </summary>
    public partial class nal : Window
    {

        public nal()
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(@"Data Source=KOMPUTER; Initial Catalog=MedAis; Integrated Security=True");

            connection.Open();
            string cmd = "SELECT * FROM Meds";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();

            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
            DataTable dt = new DataTable("meds");
            dataAdp.Fill(dt);
            dg.ItemsSource = dt.DefaultView;
            connection.Close();

        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           if(tb3.Text.Length >0)
            {
                SqlConnection connection = new SqlConnection(@"Data Source=KOMPUTER; Initial Catalog=MedAis; Integrated Security=True");

                connection.Open();
                string cmd = "SELECT * FROM Meds where Препарат='" + tb3.Text + "'";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("meds");
                dataAdp.Fill(dt);
                dg.ItemsSource = dt.DefaultView;
                connection.Close();
            } else
            {
                InitializeComponent();
                SqlConnection connection = new SqlConnection(@"Data Source=KOMPUTER; Initial Catalog=MedAis; Integrated Security=True");

                connection.Open();
                string cmd = "SELECT * FROM Meds";
                SqlCommand createCommand = new SqlCommand(cmd, connection);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("meds");
                dataAdp.Fill(dt);
                dg.ItemsSource = dt.DefaultView;
                connection.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(@"Data Source=KOMPUTER; Initial Catalog=MedAis; Integrated Security=True");

            connection.Open();
            string cmd = "update Meds  set Аптека=Аптека-'"+Convert.ToInt32(tb4.Text)+ "' where Препарат='"+tb5.Text+"'";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            string cmd2 = "SELECT * FROM Meds";
            SqlCommand createCommand2 = new SqlCommand(cmd2, connection);
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand2);
            DataTable dt = new DataTable("meds");
            dataAdp.Fill(dt);
            dg.ItemsSource = dt.DefaultView;
            connection.Close();
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            SqlConnection connection = new SqlConnection(@"Data Source=KOMPUTER; Initial Catalog=MedAis; Integrated Security=True");

            connection.Open();
            string cmd = "update Meds  set Аптека=Аптека+'" + Convert.ToInt32(tb6.Text) + "'  where Препарат='" + tb7.Text + "'";
            SqlCommand createCommand = new SqlCommand(cmd, connection);
            createCommand.ExecuteNonQuery();
            string cmd3 = "update Meds  set Склад=Склад-'" + Convert.ToInt32(tb6.Text) + "'  where Препарат='" + tb7.Text + "'";
            SqlCommand createCommand3 = new SqlCommand(cmd3, connection);
            createCommand3.ExecuteNonQuery();
            string cmd2 = "SELECT * FROM Meds";
            SqlCommand createCommand2 = new SqlCommand(cmd2, connection);
            SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand2);
            DataTable dt = new DataTable("meds");
            dataAdp.Fill(dt);
            dg.ItemsSource = dt.DefaultView;
            connection.Close();
        }
    }
}
