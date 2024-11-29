using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BuildUnit.Helpers;

namespace BuildUnit.Views.Actions
{
    /// <summary>
    ///     Interaction logic for StaffAction.xaml
    /// </summary>
    public partial class StaffAction : Page
    {
        private readonly Frame _navFrame;
        private readonly Staff _staff;

        public StaffAction(Frame navFrame, Staff staff)
        {
            InitializeComponent();

            _navFrame = navFrame;
            _staff = staff;

            OnPageInitialized();
        }

        private void OnPageInitialized()
        {
            ActionText.Text = _staff != null ? "Редактирование" : "Добавление";

            using (var context = new BuildUnitWorkshop())
            {
                if (_staff != null)
                {
                    StaffLastName.Text = _staff.LastName;
                    StaffName.Text = _staff.Name;
                    StaffTitle.Text = _staff.Title;
                    StaffPatronymic.Text = _staff.Patronymic;
                    StaffPhoneNumber.Text = _staff.Phone;
                }
            }
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            if (_navFrame.CanGoBack) _navFrame.GoBack();
        }

        private void SaveClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StringChecker.ThrowErrorIfFailed(StaffLastName.Text, "Введите фамилию сотрудника") ||
                    StringChecker.ThrowErrorIfFailed(StaffName.Text, "Введите имя сотрудника") ||
                    StringChecker.ThrowErrorIfFailed(StaffPatronymic.Text, "Введите отчество сотрудника") ||
                    StringChecker.ThrowErrorIfFailed(StaffTitle.Text, "Введите должность сотрудника") ||
                    StringChecker.ThrowErrorIfFailed(StaffPhoneNumber.Text, "Введите номер сотрудника"))
                    return;
                using (var context = new BuildUnitWorkshop())
                {
                    if (_staff != null)
                    {
                        var staff = context.Staffs
                            .SingleOrDefault(x => x.idStaff == _staff.idStaff);
                        staff.Name = StaffName.Text;
                        staff.LastName = StaffLastName.Text;
                        staff.Patronymic = StaffPatronymic.Text;
                        staff.Title = StaffTitle.Text;
                        staff.Phone = StaffPhoneNumber.Text;

                        context.SaveChanges();
                    }
                    else
                    {
                        var staff = new Staff
                        {
                            idStaff = context.Staffs.Max(x => x.idStaff) + 1,
                            LastName = StaffLastName.Text,
                            Name = StaffName.Text,
                            Patronymic = StaffPatronymic.Text,
                            Title = StaffTitle.Text,
                            Phone = StaffPhoneNumber.Text
                        };

                        context.Staffs.Add(staff);

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