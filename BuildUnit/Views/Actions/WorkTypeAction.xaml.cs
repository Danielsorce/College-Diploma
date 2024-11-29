using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BuildUnit.Helpers;

namespace BuildUnit.Views.Actions
{
    /// <summary>
    ///     Interaction logic for WorkTypeAction.xaml
    /// </summary>
    public partial class WorkTypeAction : Page
    {
        private readonly Frame _navFrame;
        private readonly TypeOfWork _typeOfWork;

        public WorkTypeAction(Frame navFrame, TypeOfWork typeOfWork)
        {
            InitializeComponent();

            _navFrame = navFrame;
            _typeOfWork = typeOfWork;

            OnPageInitialized();
        }

        private void OnPageInitialized()
        {
            ActionText.Text = _typeOfWork != null ? "Редактирование" : "Добавление";

            using (var context = new BuildUnitWorkshop())
            {
                if (_typeOfWork != null) WorkTypeName.Text = _typeOfWork.Title;
            }
        }

        private void SaveWorkType_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (StringChecker.ThrowErrorIfFailed(WorkTypeName.Text, "Введите вид работы"))
                    return;
                using (var context = new BuildUnitWorkshop())
                {
                    if (_typeOfWork != null)
                    {
                        var typeOfWork = context.TypeOfWorks
                            .SingleOrDefault(x => x.idtypeOfWork == _typeOfWork.idtypeOfWork);
                        typeOfWork.Title = WorkTypeName.Text;

                        context.SaveChanges();
                    }
                    else
                    {
                        var typeOfWork = new TypeOfWork
                        {
                            idtypeOfWork = context.TypeOfWorks.Max(x => x.idtypeOfWork) + 1,
                            Title = WorkTypeName.Text
                        };

                        context.TypeOfWorks.Add(typeOfWork);

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

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            if (_navFrame.CanGoBack) _navFrame.GoBack();
        }
    }
}