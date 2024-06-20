using ButtleShip_MVVM.ViewModels;
using System.Windows.Controls;

namespace ButtleShip_MVVM.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        BattleShipVM battleShip = DataPort.GetDataPort().BattleShip;
        public MenuPage()
        {
            DataContext = battleShip;
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }
    }
}
