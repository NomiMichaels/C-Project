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
using BL;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl;

        public MainWindow()
        {
            InitializeComponent();
            BE.Tester tester;// = new BE.Tester();
            BE.Trainee trainee;// = new BE.Trainee();
            bl = BL.FactoryBL.GetBL();

            //הוספת כמה טסטים לרשימות שלנו
            tester = new BE.Tester("123456789", "Orna", "Levi", new DateTime(1967, 12, 1), BE.Gender.נקבה, "026543212", new BE.Address("Rakefet", 7, "Beit Shemesh"), new DateTime(2020, 1, 1), 10, 20,
                new List<BE.VehicleType> { BE.VehicleType.משאית_בינונית, BE.VehicleType.אופנוע, BE.VehicleType.רכב_פרטי }, new List<BE.GearBox> { BE.GearBox.אוטומטי, BE.GearBox.ידני },
                new bool[6, 5] {{ true, true, true, true, true } ,
                { true, true, true, true, true },
                { true, true, true, true, true },
                { true, true, true, true, true },
                { true, true, true, true, true },
                { true, true, true, true, true } }, (float)100);
            bl.addTester(tester);

            tester = new BE.Tester("456456456", "Yoav", "Gefen", new DateTime(1972, 12, 5), BE.Gender.זכר, "0545531001", new BE.Address("Ein Gedi", 15, "Eilat"), new DateTime(2019, 12, 5), 10, 6,
                new List<BE.VehicleType> { BE.VehicleType.רכב_פרטי, BE.VehicleType.אופנוע, BE.VehicleType.משאית_בינונית, BE.VehicleType.משאית_כבדה, BE.VehicleType.אוטובוס }, new List<BE.GearBox> { BE.GearBox.אוטומטי, BE.GearBox.ידני },
                new bool[6, 5]{ { false, true, true, true, true },
                { true, false, true, true, true },
                { true, true, false, true, true },
                { true, true, true, false, true },
                { true, true, true, true, false },
                { true, true, true, false, true }}, (float)80);
            bl.addTester(tester);

            trainee = new BE.Trainee("315443499", "Maayan", "Seizel", new DateTime(1997, 5, 28), BE.Gender.נקבה, "0526155661", new BE.Address("Rabbi Tarfon", 6, "Jerusalem"), BE.VehicleType.רכב_פרטי, BE.GearBox.אוטומטי, "Eli", "Lamed", 20);
            bl.addTrainee(trainee);
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
