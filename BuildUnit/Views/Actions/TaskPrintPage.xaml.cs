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
    /// Interaction logic for TaskPrintPage.xaml
    /// </summary>
    public partial class TaskPrintPage : Page
    {
        private readonly Frame _navFrame;
        private readonly Task _task;
        public TaskPrintPage(Frame navFrame, Task task)
        {
            InitializeComponent();

            _task = task;
            _navFrame = navFrame;

            OnPageInitialized();
        }
        private void OnPageInitialized()
        {
            ActionText.Text = "Печать";

            using (var context = new BuildUnitWorkshop())
            {
                TaskDetailBox.ItemsSource = context.Details.ToList();
                
                if (_task != null)
                {
                    var _staff = new Staff();
                    StaffLastName.Text = _staff.LastName;
                    StaffName.Text = _staff.Name;
                    StaffPatronymic.Text = _staff.Patronymic;
                    StaffTitle.Text = _staff.Title;
                    TaskDetailBox.SelectedItem = context.Details
                        .SingleOrDefault(x => x.idDetail == _task.idDetail);
                }
            }
        }

        private void TaskPrint_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            if (_navFrame.CanGoBack) 
                _navFrame.GoBack();
        }
    }
}
