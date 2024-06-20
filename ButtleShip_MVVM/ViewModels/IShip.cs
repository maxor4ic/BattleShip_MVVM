namespace ButtleShip_MVVM.ViewModels
{
    public interface IShip
    {
        public List<int[]> Place { get; set; }
        public bool IsDestroyed { get; set; }
    }
}
