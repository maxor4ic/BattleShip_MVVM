namespace ButtleShip_MVVM.ViewModels
{
    public class MainAccuarcy : IAccuarcy
    {
        public void Accuracy()
        {
            BattleShipVM battleShip = DataPort.GetDataPort().BattleShip;
            int countOfOurHit = 0;
            int countOfEnemyHit = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (battleShip.OurMap.Map[i][j].IsShot())
                        countOfOurHit++;

                    if (battleShip.EnemyMap.Map[i][j].IsShot())
                        countOfEnemyHit++;
                }
            }

            battleShip.OurMap.Accuracy = (int)((double)countOfOurHit / (double)battleShip.OurMap.Steps * 100);
            battleShip.EnemyMap.Accuracy = (int)((double)countOfEnemyHit / (double)battleShip.EnemyMap.Steps * 100);
        }
    }
}
