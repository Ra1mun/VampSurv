using Core.Enemy;
using System;
namespace Core.Enemy.Spawner
{

    public interface ISpawner
    {
        public event Action<Enemy> OnEnemySpawned;
    }
}
