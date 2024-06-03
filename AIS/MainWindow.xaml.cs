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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AIS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public DataTable Select(string selectSQL) 
        {
            DataTable dataTable = new DataTable("dataBase");                
            SqlConnection sqlConnection = new SqlConnection("server=KOMPUTER;Trusted_Connection=Yes;DataBase=MedAis;");
            sqlConnection.Open();                                           
            SqlCommand sqlCommand = sqlConnection.CreateCommand();       
            sqlCommand.CommandText = selectSQL;                           
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); 
            sqlDataAdapter.Fill(dataTable);                                 
            return dataTable;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void LogoContainer_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LeftGrid.Visibility == Visibility.Hidden)
            {
                LeftGrid.Visibility = Visibility.Visible;
            }
            else
                LeftGrid.Visibility = Visibility.Hidden;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            if (tb2.Password.Length > 0)
            {
                WaterMark.Visibility = Visibility.Collapsed;
            }
            else
            {
                WaterMark.Visibility = Visibility.Visible;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (tb1.Text.Length > 0)    
            {
                if (tb2.Password.Length > 0) // проверяем введён ли пароль         
                {             // ищем в базе данных пользователя с такими данными         
                    DataTable dt_user = Select("SELECT * FROM [dbo].[users] WHERE [login] = '" + tb1.Text + "' AND [password] = '" + tb2.Password + "'");
                    if (dt_user.Rows.Count > 0) // если такая запись существует       
                    {
                        MessageBox.Show("Пользователь авторизовался");
                        vibor taskWindow = new vibor();
                        taskWindow.Show();
                        this.Close();       
                    }
                    else MessageBox.Show("Пользователя не найден");
                }
                else MessageBox.Show("Введите пароль");  
            }
            else MessageBox.Show("Введите логин");

        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            regin taskWindow = new regin();
            taskWindow.Show();
            this.Close();
        }
    }
}
