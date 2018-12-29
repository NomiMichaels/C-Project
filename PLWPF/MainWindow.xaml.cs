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

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Tester_Click(object sender, RoutedEventArgs e) //הגדרת פתיחת חלון הטסטר בלחיצה על הכפתור
        {
            Window testerWindow = new Tester();
            testerWindow.Show();
        }

        private void Trainee_Click(object sender, RoutedEventArgs e) //הגדרת פתיחת חלון התלמיד בלחיצה על הכפתור
        {
            Window traineeWindow = new Trainee();
            traineeWindow.Show();
        }

       

        private void Linq_Click(object sender, RoutedEventArgs e) //הגדרת פתיחת חלון השאילתות בלחיצה על הכפתור
        {
            Window linqWindow = new Linq();
            linqWindow.ShowDialog(); //לא נותן לפתוח עוד חלונות במקביל
        }

        private void Administration_Click(object sender, RoutedEventArgs e)
        {
            Window administrationWindow = new Administration(); //הגדרת פתיחת חלון ההנהלה בלחיצה על הכפתור
            administrationWindow.Show();
        }
    }
}
