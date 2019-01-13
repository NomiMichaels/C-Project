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
using System.Text.RegularExpressions;

//צריך לעשות כשכמשו נהיה אדום אז אי אפשר לעשות הוסף

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for addTraineeWindow.xaml
    /// </summary>
    public partial class addTraineeWindow : Window
    {
        BE.Trainee trainee;
        BL.IBL bl;

        public addTraineeWindow()
        {
            InitializeComponent();

            trainee = new BE.Trainee();
            this.DataContext = trainee;


            bl = BL.FactoryBL.GetBL();

            this.genderComboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));
            this.vehicleTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.VehicleType));
            this.gearBoxComboBox.ItemsSource = Enum.GetValues(typeof(BE.GearBox));

                       
        }



        private void Button_Click(object sender, RoutedEventArgs e1)
        {
            //this.DataContext = trainee;
            try
            {
                bl.addTrainee(trainee);
                // trainee = new BE.Trainee(); //איפוס המשתנה בשביל שנוכל להכניס חדש
                // this.DataContext = trainee;

            }
            catch (Exception e)
            {
                //if (e.Message == "invalid ID")
                //{
                //    _IDTextBox.Foreground = Brushes.Green;
                //    return;
                //}
                if (e.Message == "Trainee is too young")
                {
                    MessageBox.Show("תלמיד יקר, עקב גילך הצעיר לא תוכל להרשם לטסט\n" + " הגיל המינימלי הוא" + BE.Configuration.minTrainieeAge, "לא רשאי להרשם", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                if (e.Message == "not enough lessons taken")
                {
                    MessageBox.Show("תלמיד יקר, לא הגעת למכסת השיעורים המינימלית\n " + " " + "  מספר השיעורים המינמלי הוא" + " " + BE.Configuration.minLessonNum, "לא רשאי להרשם", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                //if (e.Message == "invalid phone number")
                //{
                //    phoneNumTextBox.Foreground = Brushes.Red;
                //    return;
                //}
                if (e.Message == ("This trainee ID already exists"))
                    MessageBox.Show("תלמיד יקר, הינך רשום כבר במערכת\n " + " עדכן פרטיך בעת הצורך", "לא רשאי להרשם", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            addTest addTest = new addTest();
            addTest.trainee = trainee;
            addTest.Show();
            this.Close();

        }

        private void _IDTextBox_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text); //מקבל כקלט רק מספרים
        }

        private void firstNameTextBox_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^א-ת, a-z, A-Z]+").IsMatch(e.Text); //מקבל כקלט רק אותיות
        }

        private void lastNameTextBox_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^א-ת, a-z, A-Z]+").IsMatch(e.Text); //מקבל כקלט רק אותיות
        }

        private void phoneNumTextBox_previewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text); //מקבל כקלט רק מספרים
        }
    }
}





//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;
//using System.Text.RegularExpressions;

////צריך לעשות כשכמשו נהיה אדום אז אי אפשר לעשות הוסף

//namespace PLWPF
//{
//    /// <summary>
//    /// Interaction logic for addTraineeWindow.xaml
//    /// </summary>
//    public partial class addTraineeWindow : Window
//    {
//        BE.Trainee trainee;
//        BL.IBL bl;

//        public addTraineeWindow()
//        {
//            InitializeComponent();

//            trainee = new BE.Trainee();
//            this.DataContext = trainee;


//            bl = BL.FactoryBL.GetBL();

//            this.genderComboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));
//            this.vehicleTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.VehicleType));
//            this.gearBoxComboBox.ItemsSource = Enum.GetValues(typeof(BE.GearBox));


//        }

//        private void Button_Click(object sender, RoutedEventArgs e1)
//        {
//            //this.DataContext = trainee;
//            try
//            {
//               bl.addTrainee(trainee);
//               // trainee = new BE.Trainee(); //איפוס המשתנה בשביל שנוכל להכניס חדש
//               // this.DataContext = trainee;

//            }
//            catch (Exception e)
//            {
//                //if (e.Message == "invalid ID")
//                //{
//                //    _IDTextBox.Foreground = Brushes.Green;
//                //    return;
//                //}
//                if (e.Message == "Trainee is too young")
//                {
//                   // MessageBox.Show("תלמיד יקר, עקב גילך הצעיר לא תוכל להרשם לטסט\n (הגיל המינמלי הוא)", "לא רשאי להרשם", MessageBoxButton.OK, MessageBoxImage.Information);
//                     MessageBox.Show("תלמיד יקר, עקב גילך הצעיר לא תוכל להרשם לטסט\n" + " הגיל המינימלי הוא" + BE.Configuration.minTrainieeAge, "לא רשאי להרשם",  MessageBoxButton.OK, MessageBoxImage.Information);
//                    return;
//                }
//                if (e.Message == "not enough lessons taken")
//                {
//                    MessageBox.Show("תלמיד יקר, לא הגעת למכסת השיעורים המינימלית\n "+"  מספר השיעורים המינמלי הוא"+ BE.Configuration.minLessonNum, "לא רשאי להרשם", MessageBoxButton.OK, MessageBoxImage.Information);
//                }
//                //if (e.Message == "invalid phone number")
//                //{
//                //    phoneNumTextBox.Foreground = Brushes.Red;
//                //    return;
//                //}
//                if (e.Message == ("This trainee ID already exists"))
//                    MessageBox.Show("תלמיד יקר, הינך רשום כבר במערכת\n " + " עדכן פרטיך בעת הצורך", "לא רשאי להרשם", MessageBoxButton.OK, MessageBoxImage.Information);


//            }

//            this.Close();

//        }

//        private void _IDTextBox_previewTextInput(object sender, TextCompositionEventArgs e)
//        {
//            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text); //מקבל כקלט רק מספרים
//        }

//        private void firstNameTextBox_previewTextInput(object sender, TextCompositionEventArgs e)
//        {
//            e.Handled = new Regex("[^א-ת, a-z, A-Z]+").IsMatch(e.Text); //מקבל כקלט רק אותיות
//        }

//        private void lastNameTextBox_previewTextInput(object sender, TextCompositionEventArgs e)
//        {
//            e.Handled = new Regex("[^א-ת, a-z, A-Z]+").IsMatch(e.Text); //מקבל כקלט רק אותיות
//        }

//        private void phoneNumTextBox_previewTextInput(object sender, TextCompositionEventArgs e)
//        {
//            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text); //מקבל כקלט רק מספרים
//        }
//    }
//}
