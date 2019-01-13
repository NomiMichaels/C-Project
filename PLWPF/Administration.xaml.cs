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
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Administration.xaml
    /// </summary>
    public partial class Administration : Window
    {
        public Administration()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string password = Tester_Password.Password.ToString();
            if (password == "1111")
            {
                //להכניס את תנאי הסיסמא האמיתית
                Window MainAdministrationWindow = new MainAdministrationWindow();
                MainAdministrationWindow.Show();
                this.Close();
            }
            else
                MessageBox.Show("הוכנסה סיסמא שגויה, נסה שנית", "", MessageBoxButton.OK, MessageBoxImage.Error);

        }
    }
}
