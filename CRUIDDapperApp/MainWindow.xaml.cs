using CRUIDDapperApp.DAL.Implementations;
using CRUIDDapperApp.DAL.Models;
using Microsoft.Win32;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace CRUIDDapperApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserRepositoryDAL userRepository = new UserRepositoryDAL();
        private User user = new User();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = user;
            /*textBoxFirstName.PreviewTextInput += OnInpuTextboxestInputPrewiew;
            textBoxLastName.PreviewTextInput += OnInpuTextboxestInputPrewiew;
            textBoxFatherName.PreviewTextInput += OnInpuTextboxestInputPrewiew;
            textBoxINN.PreviewTextInput += OnInpuTextboxestInputPrewiew;
            textBoxOrgName.PreviewTextInput += OnInpuTextboxestInputPrewiew;
            textBoxOrgINN.PreviewTextInput += OnInpuTextboxestInputPrewiew;
            textBoxOrgAdress.PreviewTextInput += OnInpuTextboxestInputPrewiew;*/
        }

        private void OnInpuTextboxestInputPrewiew(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            textBox.TextChanged += TextBox_TextChanged;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                textBox.Clear();
            }
            textBox.TextChanged -= TextBox_TextChanged;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                reestrGrid.ItemsSource = userRepository.GetUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EditUser_Click()
        {
            try
            {
                userRepository.UpdateUser(user);
                reestrGrid.ItemsSource = userRepository.GetUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                userRepository.AddUser(user);
                reestrGrid.ItemsSource = userRepository.GetUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void FindUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                reestrGrid.ItemsSource = userRepository.GetUsers((User)DataContext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user1 = (User)DataContext;
                userRepository.DeleteUser(userRepository.GetUserIdByContext(user));
                reestrGrid.ItemsSource = userRepository.GetUsers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void MenuItemHelpValues_Click(object sender, RoutedEventArgs e)
        {
            string outputMessage = "В правой части приложения вы можете видеть табличные представление бд.\n" +
                "В в левой части происходит ввод параметров пользователей.\n" +
                "После ввода параметров, также была добавлена кнопка: \"Добавление сертификата\", которая подразумевает прикрепление доп. файлов пользователя.\n" +
                "Далее находятся кнопки отправки запросов в бд.\n" +
                "Более подробно о функционале кнопок можно узнать в соответсвующих пунктах меню \"Помощь\".";

            MessageBox.Show(outputMessage);
        }

        private void MenuItemHelpFindData_Click(object sender, RoutedEventArgs e)
        {
            string outputMessage = "Для поиска данных (строк(-и)) в бд, воспользуйтесь кнопкой: \"Найти данные в бд\".\n" +
                "Поиск будет осуществляться по значениям параметров, введеных в соответсвующие области." +
                "результат поиска выводится в табличной области.\n" +
                "При отсутвии введенных параметров поиска и последующем нажатии кнопки, произойдет вывод всей таблицы.\n" +
                "Параметры пользователя(-ей) необходимо задавать корректно.";

            MessageBox.Show(outputMessage);
        }

        private void MenuItemHelpPushData_Click(object sender, RoutedEventArgs e)
        {
            string outputMessage = "Для добавления данных (строк(-и)) в бд, воспользуйтесь кнопкой: \"Загрузить данные в бд\".\n" +
                "Новые данные добавятся в конец таблицы, с соответсвующими параметрами, введенными в соответствующие поля выше.\n" +
                "Параметр Id не подлежит вводу и редактированию.\n" +
                "Параметры пользователя(-ей) необходимо задавать корректно.";

            MessageBox.Show(outputMessage);
        }

        private void MenuItemHelpDeleteData_Click(object sender, RoutedEventArgs e)
        {
            string outputMessage = "Для удаления данных (строк(-и)) из бд, воспользуйтесь кнопкой: \"Удалить данные из бд\".\n" +
                "Удаление затронет все строки, имеющие соответвствия по введенным параметрам, тоесть чтобы избежать избыточного удаления данных,\n" +
                "необходимо конкретнее задавать параметры пользователя(-ей).";

            MessageBox.Show(outputMessage);
        }
        private void addSertificates_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                var sr = new StreamReader(openFileDialog.FileName);
                string buffer = sr.ReadToEnd();
                sr.Close();
            }
        }
    }
}
