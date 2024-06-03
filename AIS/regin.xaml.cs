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
    /// Логика взаимодействия для regin.xaml
    /// </summary>
    public partial class regin : Window
    {
        public regin()
        {
            InitializeComponent();
        }

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

            if (tb2_Копировать.Password.Length > 0)
            {
                WaterMark_Копировать.Visibility = Visibility.Collapsed;
            }
            else
            {
                WaterMark_Копировать.Visibility = Visibility.Visible;
            }

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (tb1.Text.Length > 0)
{
                if (tb2_Копировать.Password.Length > 0)
	{
                    if (tb2.Password.Length > 0)
		{
                        if (tb2_Копировать.Password.Length >= 6)
{
                            bool en = true; // английская раскладка
                            bool symbol = false; // символ
                            bool number = false; // цифра

                            for (int i = 0; i < tb2_Копировать.Password.Length; i++)
                            {
                                if (tb2_Копировать.Password[i] >= 'А' && tb2_Копировать.Password[i] <= 'Я') en = false;
                            if (tb2_Копировать.Password[i] >= '0' && tb2_Копировать.Password[i] <= '9') number = true;
                            if (tb2_Копировать.Password[i] == '_' || tb2_Копировать.Password[i] == '-' || tb2_Копировать.Password[i] == '!') symbol = true;
                        }

                        if (!en)
                            MessageBox.Show("Доступна только английская раскладка");
                        else if (!symbol)
                            MessageBox.Show("Добавьте один из следующих символов: _ - !");
                        else if (!number)
                            MessageBox.Show("Добавьте хотя бы одну цифру");
                        if (en && symbol && number)
                        {
                                if (tb2_Копировать.Password == tb2.Password)
                                {
                                    MessageBox.Show("Пользователь зарегистрирован");
                                    MainWindow taskWindow = new MainWindow();
                                    taskWindow.Show();
                                    this.Close();
                                    DataTable dt_user = Select("INSERT INTO [dbo].[users] VALUES ('" + tb1.Text + "', '" + tb2.Password + "')");
                                }
                                else MessageBox.Show("Пароли не совподают");
                            }
                    }
                    else MessageBox.Show("пароль слишком короткий, минимум 6 символов");

                }
                else MessageBox.Show("Повторите пароль");
                }else MessageBox.Show("Укажите пароль");
            }else MessageBox.Show("Укажите логин");
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainWindow taskWindow = new MainWindow();
            taskWindow.Show();
            this.Close();
        }
    }
}
