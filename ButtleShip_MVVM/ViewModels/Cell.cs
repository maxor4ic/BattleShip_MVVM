using System.Windows;
using System.Windows.Input;

namespace ButtleShip_MVVM.ViewModels
{
    public class Cell : ViewModelBase, ICell
    {
        Visibility miss = Visibility.Collapsed;
        public Visibility Miss { get => miss; private set => Set(ref miss, value); }

        Visibility shot = Visibility.Collapsed;
        public Visibility Shot { get => shot; private set => Set(ref shot, value); }

        Visibility shipVis = Visibility.Collapsed;
        public Visibility ShipVis { get => shipVis; private set => Set(ref shipVis, value); }

        Cursor cursor = Cursors.Hand;
        public Cursor Cursor { get => cursor; private set => Set(ref cursor, value); }

        public bool CellFree { get; set; } = true;
        public bool Ship { get; set; } = false;
        
        public int Row { get; } = 0;
        public int Column { get; } = 0;
        
        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public void SetState()
        {
            if (Ship)
            {
                Shot = Visibility.Visible;
            }
            else
            {
                Miss = Visibility.Visible;
            }
            CellFree = false;
            Cursor = Cursors.Arrow;
        }

        public void SetShip()
        {
            ShipVis = Visibility.Visible;
            CellFree = false;
            Ship = true;
        }

        public void DeleteShip()
        {
            ShipVis = Visibility.Collapsed;
            CellFree = true;
            Ship = false;
        }

        public void HideShip()
        {
            ShipVis = Visibility.Collapsed;
            CellFree = true;
        }

        public bool IsShipVis()
        {
           return ShipVis == Visibility.Visible;
        }

        public bool IsShot()
        {
            return Shot == Visibility.Visible;
        }

        public void SetShipVis()
        {
            ShipVis = Visibility.Visible;
        }

        public void SetMissVis()
        {
            Miss = Visibility.Visible;
            CellFree = false;
            Cursor = Cursors.Arrow;
        }

        public void SetSecretiveShip()
        {
            shipVis = Visibility.Visible;
            CellFree = false;
            Ship = true;
        }

        public void HideSecretiveShip()
        {
            shipVis = Visibility.Collapsed;
            CellFree = true;
        }
    }
}