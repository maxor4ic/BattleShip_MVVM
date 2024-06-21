namespace ButtleShip_MVVM.ViewModels
{
    public class MainMap : ViewModelBase
    {
        public ICell[][] Map { get; set; }
        public IShip[] Ships { get; set; }

        int steps = 0;
        public int Steps { get => steps; set => Set(ref steps, value); }

        int goals = 0;
        public int Goals { get => goals; set => Set(ref goals, value); }

        int accuracy = 100;
        public int Accuracy { get => accuracy; set => Set(ref accuracy, value); }

        int fourShip = 0;
        public int FourShip { get => fourShip; set => Set(ref fourShip, value); }

        int triShip = 0;
        public int TriShip { get => triShip; set => Set(ref triShip, value); }

        int duoShip = 0;
        public int DuoShip { get => duoShip; set => Set(ref duoShip, value); }

        int singleShip = 0;
        public int SingleShip { get => singleShip; set => Set(ref singleShip, value); }

        public MainMap()
        {
            Map = (ICell[][])new CreatorMap().FactoryMethod();
            Ships = (IShip[])new CreatorShips().FactoryMethod();
        }
        
        public void FillMap()
        {
            IFillMap fillMap = new MainFillMap();
            fillMap.FillMap(Map, Ships);
        }

        public bool CanStayShip(ICell cell)
        {
            ICheck check = new MainCheck();
            return check.CanStayShip(cell, Map, this);
        }

        public bool BtnNextCheck()
        {
            ICheck check = new MainCheck();
            return check.BtnNextCheck(Map, this);
        }

        public void ReGetCountOfTypeShips()
        {
            ICheck check = new MainCheck();
            check.ReGetCountOfTypeShips(Map, this);
        }

        public void GetShips()
        {
            IGetShips getShips = new MainGetShips();
            getShips.GetShips(Map, Ships);
        }
    }
}
