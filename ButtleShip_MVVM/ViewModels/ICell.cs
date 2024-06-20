using System.Windows;

namespace ButtleShip_MVVM.ViewModels
{
    public interface ICell
    {
        public bool CellFree { get; set; }
        public int Row { get; }
        public int Column { get; }
        public bool Ship { get; set; }

        public void SetState();
        public void HideShip();
        public void DeleteShip();
        public void SetShip();
        public bool IsShipVis();
        public void SetShipVis();
        public void SetMissVis();
        public bool IsShot();
        public void SetSecretiveShip();
        public void HideSecretiveShip();
    }
}
