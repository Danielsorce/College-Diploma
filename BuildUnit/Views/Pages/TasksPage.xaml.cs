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
    /// Interaction logic for TasksPage.xaml
    /// </summary>
    public partial class TasksPage : Page
    {
        private readonly Frame _navFrame;
        public TasksPage(Frame navFrame)
        {
            InitializeComponent();

            _navFrame = navFrame;
        }
        private void TasksPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            using (var context = new BuildUnitWorkshop())
            {
                TasksList.ItemsSource = context.Tasks.ToList();
            }
        }
        private void ApplyFilter()
        {
            var searchBarText = SearchBar.Text.ToLower();

            using (var context = new BuildUnitWorkshop())
            {
                TasksList.ItemsSource = context.Tasks
                    .Where(x => x.nameOfTask.ToLower()
                        .Contains(searchBarText) || x.idDetail.ToString().ToLower()
                        .Contains(searchBarText) || x.numberOfDetails.ToLower()
                        .Contains(searchBarText) || x.numberOfHours.ToLower()
                        .Contains(searchBarText))
                    .ToList();
            }
        }


        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e) => ApplyFilter();

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            _navFrame.Navigate(new TasksAction(_navFrame, null));
        }

        private void EditTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var buttonContext = (sender as Button).DataContext as Task;
                _navFrame.Navigate(new TasksAction(_navFrame, buttonContext));
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, попробуйте снова", "Ошибка");
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var buttonContext = (sender as Button)?.DataContext as Task;

                var result = MessageBox.Show($"Вы уверены, что хотите удалить задачу'{buttonContext.nameOfTask}' ?",
                    "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Question);

                if (result == MessageBoxResult.Cancel)
                    return;

                using (var context = new BuildUnitWorkshop())
                {
                    var task = context.Tasks
                        .SingleOrDefault(x => x.idTask == buttonContext.idTask);

                    context.Tasks.Remove(task);
                    context.SaveChanges();

                    ApplyFilter();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так, попробуйте снова", "Ошибка");
            }
        }

        private void TaskPrint_Click(object sender, RoutedEventArgs e)
        {
            _navFrame.Navigate(new TaskPrintPage(_navFrame, null));
        }
    }
}