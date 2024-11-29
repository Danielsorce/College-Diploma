using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BuildUnit.Views.Actions;

namespace BuildUnit.Views.Pages
{
    /// <summary>
    ///     Interaction logic for Details.xaml
    /// </summary>
    public partial class DetailsPage : Page
    {
        private readonly Frame _navFrame;

        public DetailsPage(Frame navFrame)
        {
            InitializeComponent();

            _navFrame = navFrame;
        }

        private void DetailsPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            using (var context = new BuildUnitWorkshop())
            {
                DetailList.ItemsSource = context.Details.ToList();
            }
        }

        private void ApplyFilter()
        {
            var searchBarText = SearchBar.Text.ToLower();

            using (var context = new BuildUnitWorkshop())
            {
                DetailList.ItemsSource = context.Details
                    .Where(x => x.nameOfDetail.ToLower()
                        .Contains(searchBarText))
                    .ToList();
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }

        private void AddDetail_Click(object sender, RoutedEventArgs e)
        {
            _navFrame.Navigate(new DetailsAction(_navFrame, null));
        }

        private void EditDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var buttonContext = (sender as Button).DataContext as Detail;
                _navFrame.Navigate(new DetailsAction(_navFrame, buttonContext));
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, попробуйте снова", "Ошибка");
            }
        }

        private void DeleteDetail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var buttonContext = (sender as Button)?.DataContext as Detail;

                var result = MessageBox.Show($"Вы уверены, что хотите удалить деталь '{buttonContext.nameOfDetail}' ?",
                    "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Question);

                if (result == MessageBoxResult.Cancel)
                    return;

                using (var context = new BuildUnitWorkshop())
                {
                    var detail = context.Details
                        .SingleOrDefault(x => x.idDetail == buttonContext.idDetail);

                    context.Details.Remove(detail);
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