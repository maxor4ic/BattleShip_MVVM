using System.Windows;

namespace ButtleShip_MVVM.ViewModels
{
    public class MainCheckWin : ICheckWin
    {
        public void CheckWin()
        {
            BattleShipVM battleShip = DataPort.GetDataPort().BattleShip;
            int countOfDestOurShips = 0;
            for (int i = 0; i < battleShip.OurMap.Ships.Length; i++)
            {
                if (battleShip.OurMap.Ships[i].IsDestroyed)
                    countOfDestOurShips++;
            }

            int countOfDestEnemyShips = 0;
            for (int i = 0; i < battleShip.EnemyMap.Ships.Length; i++)
            {
                if (battleShip.EnemyMap.Ships[i].IsDestroyed)
                    countOfDestEnemyShips++;
            }

            if (countOfDestOurShips == 10 && countOfDestEnemyShips != 10)
            {
                battleShip.Stop();
                MessageBox.Show("Выиграл робот!");
                battleShip.CanGame = false;
            }
            else if (countOfDestEnemyShips == 10 && countOfDestOurShips != 10)
            {
                battleShip.Stop();
                MessageBox.Show("Выиграл человек!");
                battleShip.CanGame = false;
            }
            else if (countOfDestEnemyShips == 10 && countOfDestOurShips == 10)
            {
                battleShip.Stop();
                MessageBox.Show("Ничья!");
                battleShip.CanGame = false;
            }
        }
    }
}
