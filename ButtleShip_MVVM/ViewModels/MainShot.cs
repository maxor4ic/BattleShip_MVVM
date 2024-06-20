namespace ButtleShip_MVVM.ViewModels
{
    public class MainShot : IShot
    {
        public void Shot(ICell cell, int select)
        {
            cell.SetState();
            BattleShipVM battleShip = DataPort.GetDataPort().BattleShip;
            IPaint paint = new MainPaint();

            MainMap map;
            if (select == 0)
            {
                map = battleShip.OurMap;
            }
            else
            {
                map = battleShip.EnemyMap;
            }

            map.Steps++;

            if (cell.Ship)
            {
                Ship ship = null;
                for (int i = 0; i < map.Ships.Length; i++)
                {
                    for (int j = 0; j < map.Ships[i].Place.Count; j++)
                    {
                        if (cell.Row == map.Ships[i].Place[j][0] && cell.Column == map.Ships[i].Place[j][1])
                        {
                            ship = map.Ships[i] as Ship;
                            i = map.Ships.Length;
                            break;
                        }
                    }
                }

                if (ship.Place.Count == 1)
                {
                    paint.Paint(ship, map);
                }
                else
                {
                    bool check = true;
                    foreach (var item in ship.Place)
                    {
                        if (map.Map[item[0]][item[1]].CellFree)
                        {
                            check = false;
                            break;
                        }
                    }

                    if (check)
                    {
                        paint.Paint(ship, map);
                    }
                }
            }

        }
    }
}
