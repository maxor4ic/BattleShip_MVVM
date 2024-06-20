namespace ButtleShip_MVVM.ViewModels
{
    public class CreatorMap : Creator
    {
        public override object FactoryMethod()
        {
            ICell[][] Map = new Cell[10][];
            for (int i = 0; i < 10; i++)
            {
                Map[i] = new Cell[10];
                for (int j = 0; j < 10; j++)
                {
                    Map[i][j] = new Cell(i, j);
                }
            }

            return Map;
        }
    }
}
