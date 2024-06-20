namespace ButtleShip_MVVM.ViewModels
{
    public class MainBot : Ibot
    {
        public void Bot()
        {
            BattleShipVM battleShip = DataPort.GetDataPort().BattleShip;
            IShot shot = new MainShot();
            int[,] weight = new int[10, 10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (battleShip.OurMap.Map[i][j].CellFree)
                    {
                        weight[i, j] = 1;
                    }
                    else
                    {
                        if (battleShip.OurMap.Map[i][j].IsShot())
                        {
                            weight[i, j] = -1;
                        }
                        else
                        {
                            weight[i, j] = 0;
                        }
                    }
                }
            }

            Random rnd = new Random();
            bool check = true;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (weight[i, j] != 1)
                    {
                        check = false;
                        break;
                    }
                }
            }

            if (check)
            {
                int row = rnd.Next(10);
                int col = rnd.Next(10);
                shot.Shot(battleShip.OurMap.Map[row][col], 0);
            }
            else
            {
                int countOfShot = 0;
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (weight[i, j] == -1)
                            countOfShot++;
                    }
                }

                if (countOfShot == 0)
                {
                    while (true)
                    {
                        int row = rnd.Next(10);
                        int col = rnd.Next(10);
                        if (battleShip.OurMap.Map[row][col].CellFree)
                        {
                            shot.Shot(battleShip.OurMap.Map[row][col], 0);
                            break;
                        }
                    }
                }
                else
                {
                    List<int[]> ship = new List<int[]>();
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (weight[i, j] == -1)
                            {
                                for (int m = 0; m < battleShip.OurMap.Ships.Length; m++)
                                {
                                    for (int n = 0; n < battleShip.OurMap.Ships[m].Place.Count; n++)
                                    {
                                        if (i == battleShip.OurMap.Ships[m].Place[n][0] && j == battleShip.OurMap.Ships[m].Place[n][1])
                                        {
                                            if (battleShip.OurMap.Ships[m].IsDestroyed)
                                            {
                                                weight[i, j] = 0;
                                            }
                                            else
                                            {
                                                ship.Add(new int[] { i, j });
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                    List<int[]> variantes = new List<int[]>();
                    if (ship.Count == 0)
                    {
                        while (true)
                        {
                            int row = rnd.Next(10);
                            int col = rnd.Next(10);
                            if (battleShip.OurMap.Map[row][col].CellFree)
                            {
                                shot.Shot(battleShip.OurMap.Map[row][col], 0);
                                break;
                            }
                        }
                    }
                    else if (ship.Count == 1)
                    {
                        int row = ship[0][0];
                        int col = ship[0][1];

                        if (row - 1 >= 0)
                        {
                            if (battleShip.OurMap.Map[row - 1][col].CellFree)
                                variantes.Add(new int[] { row - 1, col });
                        }
                        if (row + 1 <= 9)
                        {
                            if (battleShip.OurMap.Map[row + 1][col].CellFree)
                                variantes.Add(new int[] { row + 1, col });
                        }
                        if (col - 1 >= 0)
                        {
                            if (battleShip.OurMap.Map[row][col - 1].CellFree)
                                variantes.Add(new int[] { row, col - 1 });
                        }
                        if (col + 1 <= 9)
                        {
                            if (battleShip.OurMap.Map[row][col + 1].CellFree)
                                variantes.Add(new int[] { row, col + 1 });
                        }

                        int index = rnd.Next(variantes.Count);
                        shot.Shot(battleShip.OurMap.Map[variantes[index][0]][variantes[index][1]], 0);
                    }
                    else
                    {
                        if (ship[0][0] == ship[^1][0])
                        {
                            int startCol = ship[0][1];
                            int stopCol = ship[^1][1];
                            int row = ship[0][0];

                            if (startCol - 1 >= 0)
                            {
                                if (battleShip.OurMap.Map[row][startCol - 1].CellFree)
                                    variantes.Add(new int[] { row, startCol - 1 });
                            }
                            if (stopCol + 1 <= 9)
                            {
                                if (battleShip.OurMap.Map[row][stopCol + 1].CellFree)
                                    variantes.Add(new int[] { row, stopCol + 1 });
                            }
                        }
                        else
                        {
                            int startRow = ship[0][0];
                            int stopRow = ship[^1][0];
                            int col = ship[0][1];

                            if (startRow - 1 >= 0)
                            {
                                if (battleShip.OurMap.Map[startRow - 1][col].CellFree)
                                    variantes.Add(new int[] { startRow - 1, col });
                            }
                            if (stopRow + 1 <= 9)
                            {
                                if (battleShip.OurMap.Map[stopRow + 1][col].CellFree)
                                    variantes.Add(new int[] { stopRow + 1, col });
                            }
                        }

                        int index = rnd.Next(variantes.Count);
                        shot.Shot(battleShip.OurMap.Map[variantes[index][0]][variantes[index][1]], 0);
                    }
                }
            }
        }
    }
}
