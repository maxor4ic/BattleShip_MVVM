namespace ButtleShip_MVVM.ViewModels
{
    public class MainFillMap : IFillMap
    {
        public void FillMap(ICell[][] Map, IShip[] Ships)
        {
            Random rnd = new Random();
            Dictionary<int, int> ps = new Dictionary<int, int>()
            {
                { 4, 1 },
                { 3, 2 },
                { 2, 3 },
                { 1, 4 },
            };

            for (int size = 4; size > 0; size--)
            {
                int count = ps[size];
                for (int c = 0; c < count; c++)
                {
                    bool check = true;
                    while (check)
                    {
                        int row = rnd.Next(10);
                        int col = rnd.Next(10);

                        if (size != 1)
                        {
                            if (!Map[row][col].Ship)
                            {
                                bool flag = false;
                                int orientation = rnd.Next(2);
                            repid:
                                if (orientation == 0)
                                {
                                    if (col >= 4)
                                    {
                                        if (CanStayFlot(row, col, size, orientation, 0, Map))
                                        {
                                            int curIndex = 0;
                                            for (int i = 0; i < Ships.Length; i++)
                                            {
                                                if (Ships[i].Place.Count == 0)
                                                {
                                                    curIndex = i;
                                                    break;
                                                }
                                            }

                                            for (int i = col; i > col - size; i--)
                                            {
                                                Map[row][i].Ship = true;
                                                Ships[curIndex].Place.Add(new int[] { row, i });
                                            }
                                            check = false;
                                        }
                                        else
                                        {
                                            if (!flag)
                                            {
                                                orientation = 1;
                                                flag = true;
                                                goto repid;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (CanStayFlot(row, col, size, orientation, 1, Map))
                                        {
                                            int curIndex = 0;
                                            for (int i = 0; i < Ships.Length; i++)
                                            {
                                                if (Ships[i].Place.Count == 0)
                                                {
                                                    curIndex = i;
                                                    break;
                                                }
                                            }

                                            for (int i = col; i < col + size; i++)
                                            {
                                                Map[row][i].Ship = true;
                                                Ships[curIndex].Place.Add(new int[] { row, i });
                                            }
                                            check = false;
                                        }
                                        else
                                        {
                                            if (!flag)
                                            {
                                                orientation = 1;
                                                flag = true;
                                                goto repid;
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (row >= 4)
                                    {
                                        if (CanStayFlot(row, col, size, orientation, 0, Map))
                                        {
                                            int curIndex = 0;
                                            for (int i = 0; i < Ships.Length; i++)
                                            {
                                                if (Ships[i].Place.Count == 0)
                                                {
                                                    curIndex = i;
                                                    break;
                                                }
                                            }

                                            for (int i = row; i > row - size; i--)
                                            {
                                                Map[i][col].Ship = true;
                                                Ships[curIndex].Place.Add(new int[] { i, col });
                                            }
                                            check = false;
                                        }
                                        else
                                        {
                                            if (!flag)
                                            {
                                                orientation = 0;
                                                flag = true;
                                                goto repid;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (CanStayFlot(row, col, size, orientation, 1, Map))
                                        {
                                            int curIndex = 0;
                                            for (int i = 0; i < Ships.Length; i++)
                                            {
                                                if (Ships[i].Place.Count == 0)
                                                {
                                                    curIndex = i;
                                                    break;
                                                }
                                            }

                                            for (int i = row; i < row + size; i++)
                                            {
                                                Map[i][col].Ship = true;
                                                Ships[curIndex].Place.Add(new int[] { i, col });
                                            }
                                            check = false;
                                        }
                                        else
                                        {
                                            if (!flag)
                                            {
                                                orientation = 0;
                                                flag = true;
                                                goto repid;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (!Map[row][col].Ship)
                            {
                                if (CanStaySmallFlot(row, col, Map))
                                {
                                    Map[row][col].Ship = true;

                                    for (int i = 0; i < Ships.Length; i++)
                                    {
                                        if (Ships[i].Place.Count == 0)
                                        {
                                            Ships[i].Place.Add(new int[] { row, col });
                                            break;
                                        }
                                    }

                                    check = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool CanStayFlot(int row, int column, int size, int orientation, int vector, ICell[][] Map)
        {
            if (orientation == 0)
            {
                if (vector == 0)
                {
                    for (int i = column; i > column - size; i--)
                    {
                        if (Map[row][i].Ship)
                            return false;

                        if (i == column)
                        {
                            if (i + 1 <= 9)
                            {
                                if (Map[row][i + 1].Ship)
                                    return false;
                            }
                            if (i + 1 <= 9 && row - 1 >= 0)
                            {
                                if (Map[row - 1][i + 1].Ship)
                                    return false;
                            }
                            if (i + 1 <= 9 && row + 1 <= 9)
                            {
                                if (Map[row + 1][i + 1].Ship)
                                    return false;
                            }
                            if (row - 1 >= 0)
                            {
                                if (Map[row - 1][i].Ship)
                                    return false;
                            }
                            if (row + 1 <= 9)
                            {
                                if (Map[row + 1][i].Ship)
                                    return false;
                            }
                        }
                        else if (i == column - size + 1)
                        {
                            if (i - 1 >= 0)
                            {
                                if (Map[row][i - 1].Ship)
                                    return false;
                            }
                            if (i - 1 >= 0 && row - 1 >= 0)
                            {
                                if (Map[row - 1][i - 1].Ship)
                                    return false;
                            }
                            if (i - 1 >= 0 && row + 1 <= 9)
                            {
                                if (Map[row + 1][i - 1].Ship)
                                    return false;
                            }
                            if (row - 1 >= 0)
                            {
                                if (Map[row - 1][i].Ship)
                                    return false;
                            }
                            if (row + 1 <= 9)
                            {
                                if (Map[row + 1][i].Ship)
                                    return false;
                            }
                        }
                        else
                        {
                            if (row - 1 >= 0)
                            {
                                if (Map[row - 1][i].Ship)
                                    return false;
                            }
                            if (row + 1 <= 9)
                            {
                                if (Map[row + 1][i].Ship)
                                    return false;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = column; i < column + size; i++)
                    {
                        if (Map[row][i].Ship)
                            return false;

                        if (i == column)
                        {
                            if (i - 1 >= 0)
                            {
                                if (Map[row][i - 1].Ship)
                                    return false;
                            }
                            if (i - 1 >= 0 && row - 1 >= 0)
                            {
                                if (Map[row - 1][i - 1].Ship)
                                    return false;
                            }
                            if (i - 1 >= 0 && row + 1 <= 9)
                            {
                                if (Map[row + 1][i - 1].Ship)
                                    return false;
                            }
                            if (row - 1 >= 0)
                            {
                                if (Map[row - 1][i].Ship)
                                    return false;
                            }
                            if (row + 1 <= 9)
                            {
                                if (Map[row + 1][i].Ship)
                                    return false;
                            }
                        }
                        else if (i == column + size - 1)
                        {
                            if (i + 1 <= 9)
                            {
                                if (Map[row][i + 1].Ship)
                                    return false;
                            }
                            if (i + 1 <= 9 && row - 1 >= 0)
                            {
                                if (Map[row - 1][i + 1].Ship)
                                    return false;
                            }
                            if (i + 1 <= 9 && row + 1 <= 9)
                            {
                                if (Map[row + 1][i + 1].Ship)
                                    return false;
                            }
                            if (row - 1 >= 0)
                            {
                                if (Map[row - 1][i].Ship)
                                    return false;
                            }
                            if (row + 1 <= 9)
                            {
                                if (Map[row + 1][i].Ship)
                                    return false;
                            }
                        }
                        else
                        {
                            if (row - 1 >= 0)
                            {
                                if (Map[row - 1][i].Ship)
                                    return false;
                            }
                            if (row + 1 <= 9)
                            {
                                if (Map[row + 1][i].Ship)
                                    return false;
                            }
                        }
                    }
                }
            }
            else
            {
                if (vector == 0)
                {
                    for (int i = row; i > row - size; i--)
                    {
                        if (Map[i][column].Ship)
                            return false;

                        if (i == row)
                        {
                            if (i + 1 <= 9)
                            {
                                if (Map[i + 1][column].Ship)
                                    return false;
                            }
                            if (i + 1 <= 9 && column - 1 >= 0)
                            {
                                if (Map[i + 1][column - 1].Ship)
                                    return false;
                            }
                            if (i + 1 <= 9 && column + 1 <= 9)
                            {
                                if (Map[i + 1][column + 1].Ship)
                                    return false;
                            }
                            if (column - 1 >= 0)
                            {
                                if (Map[i][column - 1].Ship)
                                    return false;
                            }
                            if (column + 1 <= 9)
                            {
                                if (Map[i][column + 1].Ship)
                                    return false;
                            }
                        }
                        else if (i == row - size + 1)
                        {
                            if (i - 1 >= 0)
                            {
                                if (Map[i - 1][column].Ship)
                                    return false;
                            }
                            if (i - 1 >= 0 && column - 1 >= 0)
                            {
                                if (Map[i - 1][column - 1].Ship)
                                    return false;
                            }
                            if (i - 1 >= 0 && column + 1 <= 9)
                            {
                                if (Map[i - 1][column + 1].Ship)
                                    return false;
                            }
                            if (column - 1 >= 0)
                            {
                                if (Map[i][column - 1].Ship)
                                    return false;
                            }
                            if (column + 1 <= 9)
                            {
                                if (Map[i][column + 1].Ship)
                                    return false;
                            }
                        }
                        else
                        {
                            if (column - 1 >= 0)
                            {
                                if (Map[i][column - 1].Ship)
                                    return false;
                            }
                            if (column + 1 <= 9)
                            {
                                if (Map[i][column + 1].Ship)
                                    return false;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = row; i < row + size; i++)
                    {
                        if (Map[i][column].Ship)
                            return false;

                        if (i == row)
                        {
                            if (i - 1 >= 0)
                            {
                                if (Map[i - 1][column].Ship)
                                    return false;
                            }
                            if (i - 1 >= 0 && column - 1 >= 0)
                            {
                                if (Map[i - 1][column - 1].Ship)
                                    return false;
                            }
                            if (i - 1 >= 0 && column + 1 <= 9)
                            {
                                if (Map[i - 1][column + 1].Ship)
                                    return false;
                            }
                            if (column - 1 >= 0)
                            {
                                if (Map[i][column - 1].Ship)
                                    return false;
                            }
                            if (column + 1 <= 9)
                            {
                                if (Map[i][column + 1].Ship)
                                    return false;
                            }
                        }
                        else if (i == row + size - 1)
                        {
                            if (i + 1 <= 9)
                            {
                                if (Map[i + 1][column].Ship)
                                    return false;
                            }
                            if (i + 1 <= 9 && column - 1 >= 0)
                            {
                                if (Map[i + 1][column - 1].Ship)
                                    return false;
                            }
                            if (i + 1 <= 9 && column + 1 <= 9)
                            {
                                if (Map[i + 1][column + 1].Ship)
                                    return false;
                            }
                            if (column - 1 >= 0)
                            {
                                if (Map[i][column - 1].Ship)
                                    return false;
                            }
                            if (column + 1 <= 9)
                            {
                                if (Map[i][column + 1].Ship)
                                    return false;
                            }
                        }
                        else
                        {
                            if (column - 1 >= 0)
                            {
                                if (Map[i][column - 1].Ship)
                                    return false;
                            }
                            if (column + 1 <= 9)
                            {
                                if (Map[i][column + 1].Ship)
                                    return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        private bool CanStaySmallFlot(int row, int column, ICell[][] Map)
        {
            if (row - 1 >= 0)
            {
                if (Map[row - 1][column].Ship)
                    return false;
            }
            if (row + 1 <= 9)
            {
                if (Map[row + 1][column].Ship)
                    return false;
            }
            if (column - 1 >= 0)
            {
                if (Map[row][column - 1].Ship)
                    return false;
            }
            if (column + 1 <= 9)
            {
                if (Map[row][column + 1].Ship)
                    return false;
            }
            if (row - 1 >= 0 && column - 1 >= 0)
            {
                if (Map[row - 1][column - 1].Ship)
                    return false;
            }
            if (row - 1 >= 0 && column + 1 <= 9)
            {
                if (Map[row - 1][column + 1].Ship)
                    return false;
            }
            if (row + 1 <= 9 && column - 1 >= 0)
            {
                if (Map[row + 1][column - 1].Ship)
                    return false;
            }
            if (row + 1 <= 9 && column + 1 <= 9)
            {
                if (Map[row + 1][column + 1].Ship)
                    return false;
            }

            return true;
        }
    }
}
