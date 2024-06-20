namespace ButtleShip_MVVM.ViewModels
{
    public class MainPaint : IPaint
    {
        public void Paint(Ship ship, MainMap map)
        {
            if (ship.Place.Count == 1)
            {
                int row = ship.Place[0][0];
                int col = ship.Place[0][1];
                map.Map[row][col].SetShipVis();
                ship.IsDestroyed = true;
                map.Goals++;

                if (row - 1 >= 0)
                {
                    map.Map[row - 1][col].SetMissVis();
                }
                if (row + 1 <= 9)
                {
                    map.Map[row + 1][col].SetMissVis();
                }
                if (col - 1 >= 0)
                {
                    map.Map[row][col - 1].SetMissVis();
                }
                if (col + 1 <= 9)
                {
                    map.Map[row][col + 1].SetMissVis();
                }
                if (row - 1 >= 0 && col - 1 >= 0)
                {
                    map.Map[row - 1][col - 1].SetMissVis();
                }
                if (row - 1 >= 0 && col + 1 <= 9)
                {
                    map.Map[row - 1][col + 1].SetMissVis();
                }
                if (row + 1 <= 9 && col - 1 >= 0)
                {
                    map.Map[row + 1][col - 1].SetMissVis();
                }
                if (row + 1 <= 9 && col + 1 <= 9)
                {
                    map.Map[row + 1][col + 1].SetMissVis();
                }
            }
            else
            {
                if (ship.Place[0][0] == ship.Place[^1][0])
                {
                    ship.IsDestroyed = true;
                    map.Goals++;
                    if (ship.Place[0][1] < ship.Place[^1][1])
                    {
                        for (int i = 0; i < ship.Place.Count; i++)
                        {
                            int[] temp = ship.Place[i];
                            int row = temp[0];
                            int col = temp[1];
                            map.Map[row][col].SetShipVis();

                            if (i == 0)
                            {
                                if (col - 1 >= 0)
                                {
                                    map.Map[row][col - 1].SetMissVis();
                                }
                                if (col - 1 >= 0 && row - 1 >= 0)
                                {
                                    map.Map[row - 1][col - 1].SetMissVis();
                                }
                                if (col - 1 >= 0 && row + 1 <= 9)
                                {
                                    map.Map[row + 1][col - 1].SetMissVis();
                                }
                                if (row - 1 >= 0)
                                {
                                    map.Map[row - 1][col].SetMissVis();
                                }
                                if (row + 1 <= 9)
                                {
                                    map.Map[row + 1][col].SetMissVis();
                                }
                            }
                            else if (i == ship.Place.Count - 1)
                            {
                                if (col + 1 <= 9)
                                {
                                    map.Map[row][col + 1].SetMissVis();
                                }
                                if (col + 1 <= 9 && row - 1 >= 0)
                                {
                                    map.Map[row - 1][col + 1].SetMissVis();
                                }
                                if (col + 1 <= 9 && row + 1 <= 9)
                                {
                                    map.Map[row + 1][col + 1].SetMissVis();
                                }
                                if (row - 1 >= 0)
                                {
                                    map.Map[row - 1][col].SetMissVis();
                                }
                                if (row + 1 <= 9)
                                {
                                    map.Map[row + 1][col].SetMissVis();
                                }
                            }
                            else
                            {
                                if (row - 1 >= 0)
                                {
                                    map.Map[row - 1][col].SetMissVis();
                                }
                                if (row + 1 <= 9)
                                {
                                    map.Map[row + 1][col].SetMissVis();
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < ship.Place.Count; i++)
                        {
                            int[] temp = ship.Place[i];
                            int row = temp[0];
                            int col = temp[1];
                            map.Map[row][col].SetShipVis();

                            if (i == 0)
                            {
                                if (col + 1 <= 9)
                                {
                                    map.Map[row][col + 1].SetMissVis();
                                }
                                if (col + 1 <= 9 && row - 1 >= 0)
                                {
                                    map.Map[row - 1][col + 1].SetMissVis();
                                }
                                if (col + 1 <= 9 && row + 1 <= 9)
                                {
                                    map.Map[row + 1][col + 1].SetMissVis();
                                }
                                if (row - 1 >= 0)
                                {
                                    map.Map[row - 1][col].SetMissVis();
                                }
                                if (row + 1 <= 9)
                                {
                                    map.Map[row + 1][col].SetMissVis();
                                }
                            }
                            else if (i == ship.Place.Count - 1)
                            {
                                if (col - 1 >= 0)
                                {
                                    map.Map[row][col - 1].SetMissVis();
                                }
                                if (col - 1 >= 0 && row - 1 >= 0)
                                {
                                    map.Map[row - 1][col - 1].SetMissVis();
                                }
                                if (col - 1 >= 0 && row + 1 <= 9)
                                {
                                    map.Map[row + 1][col - 1].SetMissVis();
                                }
                                if (row - 1 >= 0)
                                {
                                    map.Map[row - 1][col].SetMissVis();
                                }
                                if (row + 1 <= 9)
                                {
                                    map.Map[row + 1][col].SetMissVis();
                                }
                            }
                            else
                            {
                                if (row - 1 >= 0)
                                {
                                    map.Map[row - 1][col].SetMissVis();
                                }
                                if (row + 1 <= 9)
                                {
                                    map.Map[row + 1][col].SetMissVis();
                                }
                            }
                        }
                    }
                }
                else
                {
                    ship.IsDestroyed = true;
                    map.Goals++;
                    if (ship.Place[0][0] < ship.Place[^1][0])
                    {
                        for (int i = 0; i < ship.Place.Count; i++)
                        {
                            int[] temp = ship.Place[i];
                            int row = temp[0];
                            int col = temp[1];
                            map.Map[row][col].SetShipVis();

                            if (i == 0)
                            {
                                if (row - 1 >= 0)
                                {
                                    map.Map[row - 1][col].SetMissVis();
                                }
                                if (row - 1 >= 0 && col - 1 >= 0)
                                {
                                    map.Map[row - 1][col - 1].SetMissVis();
                                }
                                if (row - 1 >= 0 && col + 1 <= 9)
                                {
                                    map.Map[row - 1][col + 1].SetMissVis();
                                }
                                if (col - 1 >= 0)
                                {
                                    map.Map[row][col - 1].SetMissVis();
                                }
                                if (col + 1 <= 9)
                                {
                                    map.Map[row][col + 1].SetMissVis();
                                }
                            }
                            else if (i == ship.Place.Count - 1)
                            {
                                if (row + 1 <= 9)
                                {
                                    map.Map[row + 1][col].SetMissVis();
                                }
                                if (row + 1 <= 9 && col - 1 >= 0)
                                {
                                    map.Map[row + 1][col - 1].SetMissVis();
                                }
                                if (row + 1 <= 9 && col + 1 <= 9)
                                {
                                    map.Map[row + 1][col + 1].SetMissVis();
                                }
                                if (col - 1 >= 0)
                                {
                                    map.Map[row][col - 1].SetMissVis();
                                }
                                if (col + 1 <= 9)
                                {
                                    map.Map[row][col + 1].SetMissVis();
                                }
                            }
                            else
                            {
                                if (col - 1 >= 0)
                                {
                                    map.Map[row][col - 1].SetMissVis();
                                }
                                if (col + 1 <= 9)
                                {
                                    map.Map[row][col + 1].SetMissVis();
                                }
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < ship.Place.Count; i++)
                        {
                            int[] temp = ship.Place[i];
                            int row = temp[0];
                            int col = temp[1];
                            map.Map[row][col].SetShipVis();

                            if (i == 0)
                            {
                                if (row + 1 <= 9)
                                {
                                    map.Map[row + 1][col].SetMissVis();
                                }
                                if (row + 1 <= 9 && col - 1 >= 0)
                                {
                                    map.Map[row + 1][col - 1].SetMissVis();
                                }
                                if (row + 1 <= 9 && col + 1 <= 9)
                                {
                                    map.Map[row + 1][col + 1].SetMissVis();
                                }
                                if (col - 1 >= 0)
                                {
                                    map.Map[row][col - 1].SetMissVis();
                                }
                                if (col + 1 <= 9)
                                {
                                    map.Map[row][col + 1].SetMissVis();
                                }
                            }
                            else if (i == ship.Place.Count - 1)
                            {
                                if (row - 1 >= 0)
                                {
                                    map.Map[row - 1][col].SetMissVis();
                                }
                                if (row - 1 >= 0 && col - 1 >= 0)
                                {
                                    map.Map[row - 1][col - 1].SetMissVis();
                                }
                                if (row - 1 >= 0 && col + 1 <= 9)
                                {
                                    map.Map[row - 1][col + 1].SetMissVis();
                                }
                                if (col - 1 >= 0)
                                {
                                    map.Map[row][col - 1].SetMissVis();
                                }
                                if (col + 1 <= 9)
                                {
                                    map.Map[row][col + 1].SetMissVis();
                                }
                            }
                            else
                            {
                                if (col - 1 >= 0)
                                {
                                    map.Map[row][col - 1].SetMissVis();
                                }
                                if (col + 1 <= 9)
                                {
                                    map.Map[row][col + 1].SetMissVis();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
