using ButtleShip_MVVM.Commands;
using System.Windows.Threading;

namespace ButtleShip_MVVM.ViewModels
{
    public class BattleShipVM : ViewModelBase
    {
        NavigationCommand navigateToMenuPage = new NavigationCommand(NavigateToPage, new Uri("Views/Pages/MenuPage.xaml", UriKind.RelativeOrAbsolute));
        NavigationCommand navigateToMapPage = new NavigationCommand(NavigateToPage, new Uri("Views/Pages/MapPage.xaml", UriKind.RelativeOrAbsolute));
        NavigationCommand navigateToGamePage = new NavigationCommand(NavigateToPage, new Uri("Views/Pages/GamePage.xaml", UriKind.RelativeOrAbsolute));

        public NavigationCommand NavigateToMenuPage { get => navigateToMenuPage; }
        public NavigationCommand NavigateToMapPage { get => navigateToMapPage; }
        public NavigationCommand NavigateToGamePage { get => navigateToGamePage; }

        DispatcherTimer timer;
        DateTime startTime;

        string time = string.Empty;
        public string Time { get => time; private set => Set(ref time, value); }

        public MainMap OurMap { get; private set; }
        public MainMap EnemyMap { get; private set; }

        public bool CanGame { get; set; } = true;

        public BattleShipVM() 
        { 
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(100);
            timer.Tick += Timer_Tick;

            OurMap = new MainMap();
            EnemyMap = new MainMap();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan dt = now - startTime;
            Time = dt.ToString(@"mm\:ss");
        }

        public void Start()
        {
            startTime = DateTime.Now;
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void CheckWin()
        {
            MainCheckWin checkWin = new MainCheckWin();
            checkWin.CheckWin();
        }

        public void Accuracy()
        {
            MainAccuarcy accuracy = new MainAccuarcy();
            accuracy.Accuracy();
        }

        public void Bot()
        {
            MainBot bot = new MainBot();
            bot.Bot();
        }

        public void Shot(ICell cell, int select)
        {
            MainShot shot = new MainShot();
            shot.Shot(cell, select);
        }
    }
}
