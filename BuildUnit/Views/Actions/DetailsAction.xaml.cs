using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using BuildUnit.Helpers;

namespace BuildUnit.Views.Actions
{
    /// <summary>
    ///     Interaction logic for DetailsAction.xaml
    /// </summary>
    public partial class DetailsAction : Page
    {
        private readonly Detail _detail;
        private readonly Frame _navFrame;

        public DetailsAction(Frame navFrame, Detail detail)
        {
            InitializeComponent();

            _navFrame = navFrame;
            _detail = detail;

            OnPageInitialized();
        }

        private void OnPageInitialized()
        {
            ActionText.Text = _detail != null ? "Редактирование" : "Добавление";

            using (var context = new BuildUnitWorkshop())
            {
                if (_detail != null) DetailName.Text = _detail.nameOfDetail;
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
                if (StringChecker.ThrowErrorIfFailed(DetailName.Text, "Введите название детали"))
                    return;
                using (var context = new BuildUnitWorkshop())
                {
                    if (_detail != null)
                    {
                        var detail = context.Details
                            .SingleOrDefault(x => x.idDetail == _detail.idDetail);
                        detail.nameOfDetail = DetailName.Text;

                        context.SaveChanges();
                    }
                    else
                    {
                        var detail = new Detail
                        {
                            idDetail = context.Details.Max(x => x.idDetail) + 1,
                            nameOfDetail = DetailName.Text
                        };

                        context.Details.Add(detail);

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