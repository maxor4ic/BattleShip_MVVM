using ButtleShip_MVVM.Commands;

namespace ButtleShip_MVVM.ViewModels
{
    public class DataPort
    {
        public BattleShipVM BattleShip { get; set; } = new BattleShipVM();

        private static DataPort dataPort;
        private DataPort() { }

        public static DataPort GetDataPort()
        {
            if (dataPort == null)
                dataPort = new DataPort();
            return dataPort;
        }
    }
}
