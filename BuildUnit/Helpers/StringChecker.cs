using System.Windows;

namespace BuildUnit.Helpers
{
    public class StringChecker
    {
        public static bool ThrowErrorIfFailed(string stringToCheck, string errorMessage,
            string captionMessage = "Ошибка")
        {
            if (string.IsNullOrWhiteSpace(stringToCheck))
            {
                MessageBox.Show(errorMessage, captionMessage, MessageBoxButton.OK, MessageBoxImage.Error);

                return true;
            }

            return false;
        }
    }
}