using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Repair3v.Models;

namespace Repair3v
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly AppDataContext _dbContext;
        private readonly User _user;
        

        
        public List<User> Users { get; set; }

        public MainWindow()
        {
            _dbContext = new AppDataContext();
            _user = new User();
            InitializeComponent();
            InitializeData();
        }

        public MainWindow(AppDataContext dbContext, User user = null)
        {
            _dbContext = dbContext;
            _user = user ?? new User();
            InitializeComponent();
            InitializeData();
        }


        private void InitializeData()
        {
            DataContext = _user;
           
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            try

            {

                //Логин(string) - логин авторизации
                //○ Пароль (string) - пароль авторизации
                //○ Дата регистрации (DateOnly) - дата регистрации аккаунта
                //○ ФИО (string) - ФИО пользователя
                //○ Номер телефона (string)
                _user.DateS = DateOnly.FromDateTime(DateTime.Now);
                if (string.IsNullOrWhiteSpace(_user.Login) ||
                    string.IsNullOrWhiteSpace(_user.Password) ||
                    string.IsNullOrWhiteSpace(_user.PhoneNumber) ||
                    string.IsNullOrWhiteSpace(_user.FullName))
                {
                    MessageBox.Show("Заполните все обязательные поля!");
                    return;
                }

                if (_user.Id == 0)
                {
                    _dbContext.Users.Add(_user);
                }
                else
                {
                    _dbContext.Users.Update(_user);
                }

                _dbContext.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно!");
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }


        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var users = _dbContext.Users.ToList();
            foreach (User u in users)
            {
                if (u.Login == _user.Login)
                {
                    if (u.Password == _user.Password)
                    {
                        MessageBox.Show("Авторизация прошла успешно!");
                        // var requestWindow = new RequestWindow(u);
                        var requestWindow = new RequestWindow(u);
                        requestWindow.Show();
                        Close();
                    }
                    else { MessageBox.Show("Неправильный пароль"); }
                }

            }

        }


    }
}