using System;
using System.Collections.Generic;
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

namespace Repair3v
{
    /// <summary>
    /// Логика взаимодействия для ChangeWindow.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {
        private readonly AppDataContext _dbContext;
        private readonly Request _request;
        private readonly User _user;

        public ChangeWindow(AppDataContext dbContext, Request request = null)
        {
            InitializeComponent();
            _dbContext = dbContext;
            _request = request ?? new Request();
            DataContext = _request;

            DateAddedPicker.SelectedDate = DateTime.Now;
            StatusComboBox.SelectedIndex = 0; // "Новая" по умолчанию


        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                _dbContext.Requests.Add(_request);

                _dbContext.SaveChanges();
                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сохранения: {ex.Message}");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
