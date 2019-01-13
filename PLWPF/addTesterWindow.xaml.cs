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
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

//לדאוג שכל השדות נלחצו בצורתם התקנית בעזרת טריגר
//לעשות חיבור בין כתובת לטסטר
// לעשות לו"ז שבועי

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for addTesterWindow.xaml
    /// </summary>
    public partial class addTesterWindow : Window
    {
        BE.Tester tester;
        BL.IBL bl;
        public ObservableCollection<BE.GearBox> myGearBox;

        //BE.Address testerAddress;

        

        public addTesterWindow()
        {
            InitializeComponent();
            

            tester = new BE.Tester();
            this.DataContext = tester;

           // loadList();

            

            //testerAddress = new BE.Address();


            // this.addressStreet = testerAddress.street; &&



            bl = BL.FactoryBL.GetBL();
            myGearBox = new ObservableCollection<BE.GearBox>();


            this.gearBoxListBox.ItemsSource = Enum.GetValues(typeof(BE.GearBox));
            this.vehicleTypeListView.ItemsSource = Enum.GetValues(typeof(BE.VehicleType));
            this.genderComboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));
        }

        //public bool[,] myScedule1 = new bool[6, 5];


        //private void Window_Loaded(object sender, RoutedEventArgs e)
        //{

        //    System.Windows.Data.CollectionViewSource testerViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("testerViewSource")));
        //    // Load data by setting the CollectionViewSource.Source property:
        //    // testerViewSource.Source = [generic data source]
        //    System.Windows.Data.CollectionViewSource addressViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("addressViewSource")));
        //    // Load data by setting the CollectionViewSource.Source property:
        //    // addressViewSource.Source = [generic data source]
        //}

        public BE.Tester updateTester = new BE.Tester();


        private void Button_Click(object sender, RoutedEventArgs e1)
        {
            //tester.gearBox.
            //tester.gearBoxListBox.SetBinding(ListBox.SelectedItemProperty, new Binding("myGearBox"));
            

            //tester.scedule = myScedule1; //קישור מערכת השעות של הטסטר
            try
            {
                bl.addTester(tester);
            }
            catch (Exception e)
            {
                //if (e.Message == "invalid ID")
                //{
                //    Console.WriteLine("invalid ID, please enter your valid ID ");
                //    myID = System.Console.ReadLine();
                //    addTester(myID, myLastName, myFirstName,
                //                myBirthDate, myGender, myPhoneNum, myAddress,
                //                myValidCertification, myExperienceYears, myMaxTestPerWeek,
                //                myVehicleType, myGearBox, myScedule,
                //                myMaxDistenceToTest);
                //    return;
                //}
                if (e.Message == "Tester age is out of range")
                {
                    MessageBox.Show("גיל הטסטר אינו עומד בתנאים\n " + "  טווח הגלאים הוא " + BE.Configuration.minTesterAge +" - "+ BE.Configuration.maxTesterAge, "לא רשאי להרשם", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                if (e.Message == "Certification is not valid")
                {
                    MessageBox.Show("רשיון הטסטר אינו תקף\n ", "לא רשאי להרשם", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                //if (e.Message == "invalid phone number")
                //{
                //    Console.WriteLine("invalid phone number, please enter your valid phone number ");
                //    myPhoneNum = System.Console.ReadLine();
                //    addTester(myID, myLastName, myFirstName,
                //                myBirthDate, myGender, myPhoneNum, myAddress,
                //                myValidCertification, myExperienceYears, myMaxTestPerWeek,
                //                myVehicleType, myGearBox, myScedule,
                //                myMaxDistenceToTest);
                //    return;
                // }
                if (e.Message == ("This tester ID already exists"))
                    MessageBox.Show(", טסטר זה הינו רשום כבר במערכת\n " + " עדכן פרטיו בעת הצורך", "לא רשאי להרשם", MessageBoxButton.OK, MessageBoxImage.Information);
                //אפשר לפתוח פה את העדכון

            }
            //addTest addTest = new addTest();
            //addTest.trainee = trainee;
            //addTest.Show();
            TesterScedule testerScedule = new TesterScedule();
            testerScedule.updateTester = tester;
            testerScedule.Show();
            this.Close();
        }
        public int EmptyStringValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;
            else if (value is string)
                return value;
            else if (value is int && (int)value == EmptyStringValue)
                return string.Empty;
            else
                return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is string)
            {
                string s = (string)value;
                int isNum;
                if(int.TryParse(s, out isNum))
                    return System.Convert.ToInt32(s);
                else
                    return EmptyStringValue;
            }
            return value;
        }

        //private void loadList()
        //{
        //    SqlConnection connect = new SqlConnection();
        //    connect.ConnectionString = ConfigurationManager.ConnectionStrings.ToString();
        //}

        private void _IDTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text); //מקבל כקלט רק מספרים
        }

        private void firstNameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^א-ת, a-z, A-Z]+").IsMatch(e.Text); //מקבל כקלט רק אותיות
        }

        private void lastNameTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^א-ת, a-z, A-Z]+").IsMatch(e.Text); //מקבל כקלט רק אותיות
        }

        private void phoneNumTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text); //מקבל כקלט רק מספרים
        }

        private void experienceYearsTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text); //מקבל כקלט רק מספרים
        }

        private void maxTestPerWeekTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
           e.Handled = new Regex("[^0-9]+").IsMatch(e.Text); //מקבל כקלט רק מספרים
        }

        private void maxDistenceToTestTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text); //מקבל כקלט רק מספרים
        }

        private void addressNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9]+").IsMatch(e.Text); //מקבל כקלט רק מספרים
        }

        private void addressStreet_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^א-ת, a-z, A-Z]+").IsMatch(e.Text); //מקבל כקלט רק אותיות
        }

        private void addressCity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^א-ת, a-z, A-Z]+").IsMatch(e.Text); //מקבל כקלט רק אותיות
        }
    }
    
}


