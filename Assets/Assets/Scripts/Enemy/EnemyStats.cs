using UnityEngine;

public class EnemyStats : UnitStats
{
    [SerializeField] private Enemy _enemy;
    protected override void Initialize()
    {
        Provider = new InitializeStats(_enemy.Config);
    }
}
