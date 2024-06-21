namespace ButtleShip_MVVM.ViewModels
{
    public class CreatorShips : Creator
    {
        public override object FactoryMethod()
        {
            IShip[] Ships = new Ship[10];
            for (int i = 0; i < 10; i++)
            {
                Ships[i] = new Ship();
            }

            return Ships;
        }
    }
}
