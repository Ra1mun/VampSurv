using Core.Enemy;
using System.Collections.Generic;


namespace Assets.Scripts.Wave
{
    public class WaveEnemyPool
    {
        private int _totalThreat;
        private List<EnemyConfig> _enemyConfigs;
        public List<EnemyConfig> EnemyPool;
        //public List<EnemyConfig> EnemyPool => _enemyPool;
        public WaveEnemyPool(int threat, List<EnemyConfig> configs)
        {
            _totalThreat = threat;
            _enemyConfigs = configs;
        }
        public void MakePool()
        {
            EnemyPool = new List<EnemyConfig>();
            SortByThreat();
            for(int i = 0;i< _enemyConfigs.Count; i++)
            {
                while(_totalThreat > _enemyConfigs[i].Threat)
                {
                    EnemyPool.Add(_enemyConfigs[i]);
                    _totalThreat-= _enemyConfigs[i].Threat;
                }
            }
            EnemyPool.Reverse();
        }
        public void SortByThreat()
        {
            for(int i = 0;i< _enemyConfigs.Count;i++)
            {
                for(int j = 1;j< _enemyConfigs.Count;j++)
                {
                    if (_enemyConfigs[i].Threat < _enemyConfigs[j].Threat)
                        Swap(i, j);
                }
            }
        }
        void Swap(int i, int j)
        {
            EnemyConfig t = _enemyConfigs[i];
            _enemyConfigs[i] = _enemyConfigs[j];
            _enemyConfigs[j] = t;
        }
        
    }
}
