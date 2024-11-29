using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BuildUnit.Views.Actions;

namespace BuildUnit.Views.Pages
{
    /// <summary>
    ///     Interaction logic for StaffPage.xaml
    /// </summary>
    public partial class StaffPage : Page
    {
        private readonly Frame _navFrame;

        public StaffPage(Frame navFrame)
        {
            InitializeComponent();
            _navFrame = navFrame;
        }

        private void StaffPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            using (var context = new BuildUnitWorkshop())
            {
                StaffList.ItemsSource = context.Staffs.ToList();
            }
        }

        private void ApplyFilter()
        {
            var searchBarText = SearchBar.Text.ToLower();

            using (var context = new BuildUnitWorkshop())
            {
                StaffList.ItemsSource = context.Staffs
                    .Where(x => x.LastName.ToLower()
                        .Contains(searchBarText) || x.Name.ToLower()
                        .Contains(searchBarText) || x.Patronymic.ToLower()
                        .Contains(searchBarText) || x.Title.ToLower()
                        .Contains(searchBarText) || x.Phone.ToLower()
                        .Contains(searchBarText))
                    .ToList();
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e) => ApplyFilter();

            private void AddStaff_Click(object sender, RoutedEventArgs e)
        {
            _navFrame.Navigate(new StaffAction(_navFrame, null));
        }

        private void EditClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var buttonContext = (sender as Button).DataContext as Staff;
                _navFrame.Navigate(new StaffAction(_navFrame, buttonContext));
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, попробуйте снова", "Ошибка");
            }
        }

        private void DeleteClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var buttonContext = (sender as Button)?.DataContext as Staff;

                var result = MessageBox.Show($"Вы уверены, что хотите удалить сотрудника '{buttonContext.LastName}' ?",
                    "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Question);

                if (result == MessageBoxResult.Cancel)
                    return;

                using (var context = new BuildUnitWorkshop())
                {
                    var staff = context.Staffs
                        .SingleOrDefault(x => x.idStaff == buttonContext.idStaff);

                    context.Staffs.Remove(staff);
                    context.SaveChanges();

                    ApplyFilter();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, попробуйте снова", "Ошибка");
            }
        }
    }
}