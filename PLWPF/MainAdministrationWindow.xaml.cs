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
    /// Interaction logic for MainAdministrationWindow.xaml
    /// </summary>
    public partial class MainAdministrationWindow : Window
    {
        public MainAdministrationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window addTesterWindow = new addTesterWindow();
            addTesterWindow.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window deleteTesterWindow = new DeleteTesterWindow();
            deleteTesterWindow.Show();
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window deleteTestWindow = new DeleteTesterWindow();
            deleteTestWindow.Show();
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window deleteTraineeWindow = new DeleteTraineeWindow();
            deleteTraineeWindow.Show();
        }

    }
}
