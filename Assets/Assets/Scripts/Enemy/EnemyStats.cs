using UnityEngine;

public class EnemyStats : EntityStats
{
    [SerializeField] private Enemy _enemy;
    protected override void Initialize()
    {
        Provider = new InitializeStats(_enemy.Config);
    }
}
