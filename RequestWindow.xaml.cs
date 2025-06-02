using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Repair3v.Models;
using Microsoft.SqlServer;
using Microsoft.EntityFrameworkCore;

namespace Repair3v
{
    /// <summary>
    /// Логика взаимодействия для RequestWindow.xaml
    /// </summary>
    public partial class RequestWindow : Window
    {

        private AppDataContext dbContext;
        public ObservableCollection<Request> Requests { get; set; }

        public ObservableCollection<User> Users { get; set; }
        public RequestWindow(User u)
        {
            InitializeComponent();
            dbContext = new AppDataContext();
            Requests = new ObservableCollection<Request>();
            Users = new ObservableCollection<User>();
            LoadInventorys();
            LoadUsers();
            RequestsGrid.DataContext = this;
        }

        private void LoadInventorys()
        {
            Requests.Clear();
            var inventorys = dbContext.Requests.ToList();
            foreach (var inventory in inventorys)
            {
                Requests.Add(inventory);
            }
        }

        private void LoadUsers()
        {
            Users.Clear();
            var users = dbContext.Users.ToList();
            foreach (var user in users)
            {
                Users.Add(user);
            }
        }


        private void AddRequest_Click(object sender, RoutedEventArgs e)
        {
            var changeWindow = new ChangeWindow(dbContext);
            if (changeWindow.ShowDialog() == true)
            {
                LoadInventorys();
                LoadUsers();
            }
        }
    }
}
