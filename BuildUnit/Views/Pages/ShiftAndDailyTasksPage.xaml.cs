using BuildUnit.Views.Actions;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BuildUnit.Views.Pages
{
    /// <summary>
    /// Interaction logic for ShiftAndDailyTasksPage.xaml
    /// </summary>
    public partial class ShiftAndDailyTasksPage : Page
    {
        private readonly Frame _navFrame;
        public ShiftAndDailyTasksPage(Frame navFrame)
        {
            InitializeComponent();
            _navFrame = navFrame;
        }
        
        private void ShiftAndDailyTasksPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            using (var context = new BuildUnitWorkshop())
            {
                ShiftAndDailyTasksList.ItemsSource = context.ShiftAndDailyTasks.ToList();
            }
        }

        private void ApplyFilter()
        {
            var searchBarText = SearchBar.Text.ToLower();

            using (var context = new BuildUnitWorkshop())
            {
                ShiftAndDailyTasksList.ItemsSource = context.ShiftAndDailyTasks
                    .Where(x => x.idTask.ToString().ToLower()
                        .Contains(searchBarText) || x.typeOfWork.ToString().ToLower()
                        .Contains(searchBarText) || x.idBuild.ToString().ToLower()
                        .Contains(searchBarText) || x.Employeer.ToString().ToLower()
                        .Contains(searchBarText) || x.dateOfTheTask.ToString().ToLower()
                        .Contains(searchBarText) || x.dateOfComplete.ToString().ToLower()
                        .Contains(searchBarText))
                    .ToList();
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e) => ApplyFilter();

        private void TaskPrint_Click(object sender, RoutedEventArgs e)
        {
            //_navFrame.Navigate(new ShiftAndDailyTasksPrint(_navFrame, null));
        }

        private void AddShiftAndDailyTask_Click(object sender, RoutedEventArgs e)
        {
            //_navFrame.Navigate(new ShiftAndDailyTasksAction(_navFrame, null));
        }

        private void ShiftAndDailyTaskDateFilter_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var searchBarText = ShiftAndDailyTaskDateFilter.Text.ToLower();

            using (var context = new BuildUnitWorkshop())
            {
                ShiftAndDailyTasksList.ItemsSource = context.ShiftAndDailyTasks
                    .Where(x => x.dateOfTheTask.ToString().ToLower()
                        .Contains(searchBarText) || x.dateOfComplete.ToString().ToLower()
                        .Contains(searchBarText))
                    .ToList();
            }
        }

        private void DeleteShiftAndDailyTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var buttonContext = (sender as Button)?.DataContext as ShiftAndDailyTask;

                var result = MessageBox.Show($"Вы уверены, что хотите удалить сменно-суточное задание N№'{buttonContext.workNumber}' ?",
                    "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Question);

                if (result == MessageBoxResult.Cancel)
                    return;

                using (var context = new BuildUnitWorkshop())
                {
                    var shiftAndDailyTask = context.ShiftAndDailyTasks
                        .SingleOrDefault(x => x.workNumber == buttonContext.workNumber);

                    context.ShiftAndDailyTasks.Remove(shiftAndDailyTask);
                    context.SaveChanges();

                    ApplyFilter();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, попробуйте снова", "Ошибка");
            }
        }

        private void EditShiftAndDailyTask_Click(object sender, RoutedEventArgs e)
        {
            //_navFrame.Navigate(new ShiftAndDailyTasksAction(_navFrame, null));
        }
    }
}
