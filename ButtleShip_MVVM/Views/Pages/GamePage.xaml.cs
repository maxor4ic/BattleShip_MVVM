using ButtleShip_MVVM.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace ButtleShip_MVVM.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для GamePage.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        BattleShipVM battleShip = DataPort.GetDataPort().BattleShip;
        public GamePage()
        {
            battleShip.EnemyMap.FillMap();
            battleShip.Start();
            DataContext = battleShip;
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (((Cell)((Border)sender).DataContext).CellFree && battleShip.CanGame)
            {
                battleShip.Shot((Cell)((Border)sender).DataContext, 1);
                battleShip.Bot();
                battleShip.Accuracy();
                battleShip.CheckWin();
            }
        }

        private void Btn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            battleShip.Stop();
            DataPort.GetDataPort().BattleShip = new BattleShipVM();
        }
    }
}
