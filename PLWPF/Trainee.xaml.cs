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
using BL;
//using BE;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for Trainee.xaml
    /// </summary>
    public partial class Trainee : Window
    {
        IBL bl;

        public Trainee()
        {
            InitializeComponent();
            bl = BL.FactoryBL.GetBL();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window addTraineeWindow = new addTraineeWindow();
            addTraineeWindow.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string password = Trainee_Password.Password.ToString();
            bool traineeFound = true;
            BE.Trainee trainee;
            try
            {
                trainee = bl.findTrainee(password);
            }
            catch (Exception ex)
            {
                if (ex.Message == "This trainee does not exists")
                {
                    MessageBox.Show("תלמיד יקר, אינך רשום במערכת", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    traineeFound = false;
                }
            }
            if (traineeFound)
            {
                UpdateTrainee updateTrainee = new UpdateTrainee();
                updateTrainee.password = password; //העברת המידע לחלון הבא
                updateTrainee.Show();
               // Window updateTraineeWindow = new UpdateTrainee();
                //updateTrainee.func();
               // updateTraineeWindow.Show();
            }

        }
    }
}
