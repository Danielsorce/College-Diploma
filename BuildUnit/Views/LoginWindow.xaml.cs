using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using BuildUnit.Helpers;

namespace BuildUnit.Views
{
    /// <summary>
    ///     Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StringChecker.ThrowErrorIfFailed(UserLogin.Text, "Заполните поле с логином пользователя") ||
                    StringChecker.ThrowErrorIfFailed(UserPassword.Password, "Заполните поле с паролем пользователя"))
                    return;

                using (var context = new BuildUnitWorkshop())
                {
                    var account = context.Users
                        .FirstOrDefault(x => x.Login == UserLogin.Text &&
                                             x.Password == UserPassword.Password);

                    if (account == null)
                    {
                        MessageBox.Show("Вы ввели неверный логин или пароль. Пожалуйста, проверьте введенные данные",
                            "Ошибка авторизации");

                        return;
                    }

                    var user = context.Users
                        .FirstOrDefault(x => x.UserID == account.UserID);

                    if (user == null)
                    {
                        MessageBox.Show("Вы ввели неверный логин или пароль. Пожалуйста, проверьте введенные данные",
                            "Ошибка авторизации");

                        return;
                    }

                    Hide();

                    var mainWindow = new MainWindow(user);
                    mainWindow.Show();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка, попробуйте еще раз", "Неизвестная ошибка");
            }
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}