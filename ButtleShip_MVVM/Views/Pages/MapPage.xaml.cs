using ButtleShip_MVVM.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace ButtleShip_MVVM.Views.Pages
{
    /// <summary>
    /// Логика взаимодействия для MapPage.xaml
    /// </summary>
    public partial class MapPage : Page
    {
        BattleShipVM battleShip = DataPort.GetDataPort().BattleShip;
        public MapPage()
        {
            DataContext = battleShip;
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (((Cell)((Border)sender).DataContext).CellFree)
            {
                if (battleShip.OurMap.CanStayShip(((Cell)((Border)sender).DataContext)))
                {
                    ((Cell)((Border)sender).DataContext).SetShip();
                }
            } else
            {
                ((Cell)((Border)sender).DataContext).DeleteShip();
                battleShip.OurMap.ReGetCountOfTypeShips();
            }
        }

        private void BtnNext_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (battleShip.OurMap.BtnNextCheck())
            {
                battleShip.OurMap.GetShips();
                ((Button)sender).Command = battleShip.NavigateToGamePage;
            }
        }
    }
}
