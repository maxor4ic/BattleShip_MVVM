namespace ButtleShip_MVVM.ViewModels
{
    public class MainGetShips : IGetShips
    {
        public void GetShips(ICell[][] Map, IShip[] Ships)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (Map[i][j].IsShipVis())
                    {
                        if (j + 1 <= 9)
                        {
                            if (Map[i][j + 1].IsShipVis())
                            {
                                int size = 0;
                                for (int c = j; c < 10; c++)
                                {
                                    if (!Map[i][c].IsShipVis())
                                        break;
                                    size++;
                                }

                                int curIndex = 0;
                                for (int ind = 0; ind < Ships.Length; ind++)
                                {
                                    if (Ships[ind].Place.Count == 0)
                                    {
                                        curIndex = ind;
                                        break;
                                    }
                                }

                                for (int m = j; m < j + size; m++)
                                {
                                    Map[i][m].HideShip();
                                    Ships[curIndex].Place.Add(new int[] { i, m });
                                }

                                goto exit;
                            }
                        }
                        if (i + 1 <= 9)
                        {
                            if (Map[i + 1][j].IsShipVis())
                            {
                                int size = 0;
                                for (int c = i; c < 10; c++)
                                {
                                    if (!Map[c][j].IsShipVis())
                                        break;
                                    size++;
                                }

                                int curIndex = 0;
                                for (int ind = 0; ind < Ships.Length; ind++)
                                {
                                    if (Ships[ind].Place.Count == 0)
                                    {
                                        curIndex = ind;
                                        break;
                                    }
                                }

                                for (int m = i; m < i + size; m++)
                                {
                                    Map[m][j].HideShip();
                                    Ships[curIndex].Place.Add(new int[] { m, j });
                                }

                                goto exit;
                            }
                        }
                        if (j + 1 <= 9 && i + 1 <= 9)
                        {
                            if (!Map[i][j + 1].IsShipVis() && !Map[i + 1][j].IsShipVis())
                            {
                                Map[i][j].HideShip();

                                for (int ind = 0; ind < Ships.Length; ind++)
                                {
                                    if (Ships[ind].Place.Count == 0)
                                    {
                                        Ships[ind].Place.Add(new int[] { i, j });
                                        break;
                                    }
                                }

                                goto exit;
                            }
                        }
                        if (j + 1 > 9 && i + 1 > 9)
                        {
                            Map[i][j].HideShip();

                            for (int ind = 0; ind < Ships.Length; ind++)
                            {
                                if (Ships[ind].Place.Count == 0)
                                {
                                    Ships[ind].Place.Add(new int[] { i, j });
                                    break;
                                }
                            }

                            goto exit;
                        }
                        if (j + 1 <= 9 && i + 1 > 9)
                        {
                            if (!Map[i][j + 1].IsShipVis())
                            {
                                Map[i][j].HideShip();

                                for (int ind = 0; ind < Ships.Length; ind++)
                                {
                                    if (Ships[ind].Place.Count == 0)
                                    {
                                        Ships[ind].Place.Add(new int[] { i, j });
                                        break;
                                    }
                                }

                                goto exit;
                            }
                        }
                        if (j + 1 > 9 && i + 1 <= 9)
                        {
                            if (!Map[i + 1][j].IsShipVis())
                            {
                                Map[i][j].HideShip();

                                for (int ind = 0; ind < Ships.Length; ind++)
                                {
                                    if (Ships[ind].Place.Count == 0)
                                    {
                                        Ships[ind].Place.Add(new int[] { i, j });
                                        break;
                                    }
                                }

                                goto exit;
                            }
                        }

                    exit:;
                    }
                }
            }
        }
    }
}
