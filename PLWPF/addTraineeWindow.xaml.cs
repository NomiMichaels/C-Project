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
    /// Interaction logic for addTraineeWindow.xaml
    /// </summary>
    public partial class addTraineeWindow : Window
    {
        public addTraineeWindow()
        {
            InitializeComponent();

            this.genderComboBox.ItemsSource = Enum.GetValues(typeof(BE.Gender));
            this.vehicleTypeComboBox.ItemsSource = Enum.GetValues(typeof(BE.VehicleType));
            this.gearBoxComboBox.ItemsSource = Enum.GetValues(typeof(BE.GearBox));


        }




    }
}
