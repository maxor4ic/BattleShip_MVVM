namespace ButtleShip_MVVM.ViewModels
{
    public class Ship : IShip
    {
        public List<int[]> Place { get; set; } = new List<int[]>();
        public bool IsDestroyed { get; set; } = false;
    }
}
