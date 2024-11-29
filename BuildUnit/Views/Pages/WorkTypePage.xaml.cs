using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BuildUnit.Views.Actions;

namespace BuildUnit.Views.Pages
{
    /// <summary>
    ///     Interaction logic for WorkTypePage.xaml
    /// </summary>
    public partial class WorkTypePage : Page
    {
        private readonly Frame _navFrame;

        public WorkTypePage(Frame navFrame)
        {
            InitializeComponent();

            _navFrame = navFrame;
        }

        private void WorkType_OnLoaded(object sender, RoutedEventArgs e)
        {
            using (var context = new BuildUnitWorkshop())
            {
                WorkTypeList.ItemsSource = context.TypeOfWorks.ToList();
            }
        }

        private void ApplyFilter()
        {
            var searchBarText = SearchBar.Text.ToLower();

            using (var context = new BuildUnitWorkshop())
            {
                WorkTypeList.ItemsSource = context.TypeOfWorks
                    .Where(x => x.Title.ToLower()
                        .Contains(searchBarText))
                    .ToList();
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ApplyFilter();
        }

        private void AddWorkType_Click(object sender, RoutedEventArgs e)
        {
            _navFrame.Navigate(new WorkTypeAction(_navFrame, null));
        }

        private void EditWorkType_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var buttonContext = (sender as Button).DataContext as TypeOfWork;
                _navFrame.Navigate(new WorkTypeAction(_navFrame, buttonContext));
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, попробуйте снова", "Ошибка");
            }
        }

        private void DeleteWorkType_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var buttonContext = (sender as Button)?.DataContext as TypeOfWork;

                var result = MessageBox.Show($"Вы уверены, что хотите удалить вид работы '{buttonContext.Title}' ?",
                    "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Question);

                if (result == MessageBoxResult.Cancel)
                    return;

                using (var context = new BuildUnitWorkshop())
                {
                    var typeOfWork = context.TypeOfWorks
                        .SingleOrDefault(x => x.idtypeOfWork == buttonContext.idtypeOfWork);

                    context.TypeOfWorks.Remove(typeOfWork);
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