using BuildUnit.Helpers;
using BuildUnit.Views.Pages;
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

namespace BuildUnit.Views.Actions
{
    /// <summary>
    /// Interaction logic for TasksAction.xaml
    /// </summary>
    public partial class TasksAction : Page
    {
        private readonly Frame _navFrame;
        private readonly Task _task;
        public TasksAction(Frame navFrame, Task task)
        {
            InitializeComponent();

            _navFrame = navFrame;
            _task = task;

            OnPageInitialized();
        }

        private void OnPageInitialized()
        {
            ActionText.Text = _task != null ? "Редактирование" : "Добавление";

            using (var context = new BuildUnitWorkshop())
            {
                TaskDetail.ItemsSource = context.Details.ToList();

                if (_task != null)
                {
                    TaskName.Text = _task.nameOfTask;
                    TaskDetailsNumber.Text = _task.numberOfDetails;
                    TaskDetail.SelectedItem = context.Details
                        .SingleOrDefault(x => x.idDetail == _task.idDetail);
                    TaskDeadline.Text = _task.numberOfHours;
                }
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            if (_navFrame.CanGoBack) _navFrame.GoBack();
        }

        private void SaveTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StringChecker.ThrowErrorIfFailed(TaskName.Text, "Введите задачу") ||
                    StringChecker.ThrowErrorIfFailed(TaskDetail.Text, "Укажите деталь") ||
                    StringChecker.ThrowErrorIfFailed(TaskDetailsNumber.Text, "Введите количество деталей") ||
                    StringChecker.ThrowErrorIfFailed(TaskDeadline.Text, "Установите отведенное количество часов"))
                    return;
                using (var context = new BuildUnitWorkshop())
                {
                    if (_task != null)
                    {
                        var task = context.Tasks
                            .SingleOrDefault(x => x.idTask == _task.idTask);
                        task.nameOfTask = TaskName.Text;
                        task.idDetail = TaskDetail.SelectedIndex + 1;
                        task.numberOfDetails = TaskDetailsNumber.Text;
                        task.numberOfHours = TaskDeadline.Text;

                        context.SaveChanges();
                    }
                    else
                    {
                        var task = new Task
                        {
                            idTask = context.Tasks.Max(x => x.idTask) + 1,
                            nameOfTask = TaskName.Text,
                            idDetail = TaskDetail.SelectedIndex + 1,
                            numberOfDetails= TaskDetailsNumber.Text,
                            numberOfHours = TaskDeadline.Text
                        };

                        context.Tasks.Add(task);

                        context.SaveChanges();
                    }

                    if (_navFrame.CanGoBack)
                        _navFrame.GoBack();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка, попробуйте еще раз}", "Неизвестная ошибка");
            }
        }
    }
}
