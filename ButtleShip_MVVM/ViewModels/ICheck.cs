namespace ButtleShip_MVVM.ViewModels
{
    public interface ICheck
    {
        public bool CanStayShip(ICell cell, ICell[][] map, MainMap mainMap);
        public bool BtnNextCheck(ICell[][] map, MainMap mainMap);
        public void ReGetCountOfTypeShips(ICell[][] Map, MainMap mainMap);
    }
}
