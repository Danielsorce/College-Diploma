using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BuildUnit.Views.Pages;
using Application = System.Windows.Application;
using MessageBox = System.Windows.MessageBox;

namespace BuildUnit.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly User _user;
        public MainWindow(User user)
        {
            InitializeComponent();
            _user = user;
        }
        private void Dashboard_Loaded(object sender, RoutedEventArgs e)
        {
            if (_user == null)
                return;

            UserName.Text = _user.Name;
            UserPatronymic.Text = _user.Patronymic;
        }
        private void Dashboard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void UserInfoList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /* Log out the user */
            if (UserInfoList.SelectedIndex == 0)
            {
                Application.Current.Shutdown();
            }
            else if (UserInfoList.SelectedIndex == 1)
            {
                Hide();

                var loginWindow = new LoginWindow();
                loginWindow.Show();
            }
        }

        private void UserInfo_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            bool isVisible = UserInfoPopup.Visibility == Visibility.Visible;
            UserInfoPopup.Visibility = isVisible ? Visibility.Hidden : Visibility.Visible;
        }

        private void NavigationBar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        { 
            switch (NavigationBar.SelectedIndex)
            {
                case 2: 
                    ContentFrame.Navigate(new DetailsPage(ContentFrame)); 
                    break;
                case 3: 
                    ContentFrame.Navigate(new ShiftAndDailyTasksPage(ContentFrame)); 
                    break;
                case 4:
                    ContentFrame.Navigate(new StaffPage(ContentFrame)); 
                    break;
                case 5:
                    ContentFrame.Navigate(new TasksPage(ContentFrame));
                    break;
                case 6:
                    ContentFrame.Navigate(new WorkTypePage(ContentFrame)); 
                    break;
            }
        }
    }
}
