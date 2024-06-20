using System.Windows;

namespace ButtleShip_MVVM.ViewModels
{
    public class MainCheck : ICheck
    {
        public bool CanStayShip(ICell cell, ICell[][] Map, MainMap mainMap)
        {
            int countPartOfShip = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (!Map[i][j].CellFree)
                        countPartOfShip++;
                }
            }
            if (countPartOfShip == 20)
            {
                MessageBox.Show("Превышен лимит суден.");
                return false;
            }

            Map[cell.Row][cell.Column].SetSecretiveShip();
            List<Ship> ships = GetShipsForCheck(Map);
            int countOfShip = ships.Count;
            if (countOfShip > 10)
            {
                Map[cell.Row][cell.Column].DeleteShip();
                MessageBox.Show("Превышен лимит суден.");
                return false;
            }

            mainMap.SingleShip = 0;
            mainMap.DuoShip = 0;
            mainMap.TriShip = 0;
            mainMap.FourShip = 0;
            for (int i = 0; i < ships.Count; i++)
            {
                if (ships[i].Place.Count == 1)
                {
                    mainMap.SingleShip++;
                }
                else if (ships[i].Place.Count == 2)
                {
                    mainMap.DuoShip++;
                }
                else if (ships[i].Place.Count == 3)
                {
                    mainMap.TriShip++;
                }
                else if (ships[i].Place.Count == 4)
                {
                    mainMap.FourShip++;
                }
                else
                {
                    Map[cell.Row][cell.Column].DeleteShip();
                    MessageBox.Show($"Превышен размер судна. {ships[i].Place.Count} из 4");
                    return false;
                }
            }
            Map[cell.Row][cell.Column].DeleteShip();

            if (cell.Row - 1 >= 0 && cell.Column - 1 >= 0 && !Map[cell.Row - 1][cell.Column - 1].CellFree)
            {
                MessageBox.Show("Размещение судна запрещено.");
                return false;
            }
            if (cell.Row - 1 >= 0 && cell.Column + 1 <= 9 && !Map[cell.Row - 1][cell.Column + 1].CellFree)
            {
                MessageBox.Show("Размещение судна запрещено.");
                return false;
            }
            if (cell.Row + 1 <= 9 && cell.Column - 1 >= 0 && !Map[cell.Row + 1][cell.Column - 1].CellFree)
            {
                MessageBox.Show("Размещение судна запрещено.");
                return false;
            }
            if (cell.Row + 1 <= 9 && cell.Column + 1 <= 9 && !Map[cell.Row + 1][cell.Column + 1].CellFree)
            {
                MessageBox.Show("Размещение судна запрещено.");
                return false;
            }

            return true;
        }

        public bool BtnNextCheck(ICell[][] Map, MainMap mainMap)
        {
            List<Ship> ships = GetShipsForCheck(Map);
            int countOfShip = ships.Count;
            if (countOfShip != 10)
            {
                MessageBox.Show($"Количество суден не удовлетворяет условие {countOfShip} из 10");
                return false;
            }

            mainMap.SingleShip = 0;
            mainMap.DuoShip = 0;
            mainMap.TriShip = 0;
            mainMap.FourShip = 0;
            for (int i = 0; i < ships.Count; i++)
            {
                if (ships[i].Place.Count == 1)
                {
                    mainMap.SingleShip++;
                }
                else if (ships[i].Place.Count == 2)
                {
                    mainMap.DuoShip++;
                }
                else if (ships[i].Place.Count == 3)
                {
                    mainMap.TriShip++;
                }
                else if (ships[i].Place.Count == 4)
                {
                    mainMap.FourShip++;
                }
            }

            if (mainMap.SingleShip != 4)
            {
                MessageBox.Show($"Количество суден размером 1 не удовлетворяет условие {mainMap.SingleShip} из 4");
                return false;
            }
            if (mainMap.DuoShip != 3)
            {
                MessageBox.Show($"Количество суден размером 2 не удовлетворяет условие {mainMap.DuoShip} из 3");
                return false;
            }
            if (mainMap.TriShip != 2)
            {
                MessageBox.Show($"Количество суден размером 3 не удовлетворяет условие {mainMap.TriShip} из 2");
                return false;
            }
            if (mainMap.FourShip != 1)
            {
                MessageBox.Show($"Количество суден размером 4 не удовлетворяет условие {mainMap.FourShip} из 1");
                return false;
            }

            return true;
        }

        public void ReGetCountOfTypeShips(ICell[][] Map, MainMap mainMap)
        {
            List<Ship> ships = GetShipsForCheck(Map);

            mainMap.SingleShip = 0;
            mainMap.DuoShip = 0;
            mainMap.TriShip = 0;
            mainMap.FourShip = 0;
            for (int i = 0; i < ships.Count; i++)
            {
                if (ships[i].Place.Count == 1)
                {
                    mainMap.SingleShip++;
                }
                else if (ships[i].Place.Count == 2)
                {
                    mainMap.DuoShip++;
                }
                else if (ships[i].Place.Count == 3)
                {
                    mainMap.TriShip++;
                }
                else if (ships[i].Place.Count == 4)
                {
                    mainMap.FourShip++;
                }
            }
        }

        private List<Ship> GetShipsForCheck(ICell[][] Map)
        {
            ICell[][] map = new Cell[10][];
            for (int i = 0; i < 10; i++)
            {
                map[i] = new Cell[10];
                for (int j = 0; j < 10; j++)
                {
                    map[i][j] = new Cell(i, j);
                    if (Map[i][j].IsShipVis())
                        map[i][j].SetSecretiveShip();
                }
            }

            List<Ship> ships = new List<Ship>();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (map[i][j].IsShipVis())
                    {
                        if (j + 1 <= 9)
                        {
                            if (map[i][j + 1].IsShipVis())
                            {
                                int size = 0;
                                for (int c = j; c < 10; c++)
                                {
                                    if (!map[i][c].IsShipVis())
                                        break;
                                    size++;
                                }

                                ships.Add(new Ship());
                                for (int m = j; m < j + size; m++)
                                {
                                    map[i][m].HideSecretiveShip();
                                    ships[^1].Place.Add(new int[] { i, m });
                                }

                                goto exit;
                            }
                        }
                        if (i + 1 <= 9)
                        {
                            if (map[i + 1][j].IsShipVis())
                            {
                                int size = 0;
                                for (int c = i; c < 10; c++)
                                {
                                    if (!map[c][j].IsShipVis())
                                        break;
                                    size++;
                                }

                                ships.Add(new Ship());
                                for (int m = i; m < i + size; m++)
                                {
                                    map[m][j].HideSecretiveShip();
                                    ships[^1].Place.Add(new int[] { m, j });
                                }

                                goto exit;
                            }
                        }
                        if (j + 1 <= 9 && i + 1 <= 9)
                        {
                            if (!map[i][j + 1].IsShipVis() && !map[i + 1][j].IsShipVis())
                            {
                                map[i][j].HideSecretiveShip();
                                ships.Add(new Ship());
                                ships[^1].Place.Add(new int[] { i, j });

                                goto exit;
                            }
                        }
                        if (j + 1 > 9 && i + 1 > 9)
                        {
                            map[i][j].HideSecretiveShip();
                            ships.Add(new Ship());
                            ships[^1].Place.Add(new int[] { i, j });

                            goto exit;
                        }
                        if (j + 1 <= 9 && i + 1 > 9)
                        {
                            if (!map[i][j + 1].IsShipVis())
                            {
                                map[i][j].HideSecretiveShip();
                                ships.Add(new Ship());
                                ships[^1].Place.Add(new int[] { i, j });

                                goto exit;
                            }
                        }
                        if (j + 1 > 9 && i + 1 <= 9)
                        {
                            if (!map[i + 1][j].IsShipVis())
                            {
                                map[i][j].HideSecretiveShip();
                                ships.Add(new Ship());
                                ships[^1].Place.Add(new int[] { i, j });

                                goto exit;
                            }
                        }

                    exit:;
                    }
                }
            }

            return ships;
        }
    }
}
