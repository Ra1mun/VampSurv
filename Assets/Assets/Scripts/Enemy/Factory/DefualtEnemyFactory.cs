using System;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

[CreateAssetMenu(fileName = "Defualt Enemy Factory", menuName = "Source/Factories/Default Enemies", order = 0)]
public class DefualtEnemyFactory : EnemyFactory
{
    [SerializeField] private EnemyConfig _testEnemy;

    protected override EnemyConfig GetConfig(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.TestEnemy:
                return _testEnemy;
            default:
                throw new ArgumentOutOfRangeException($"Enemy type: {type} wasn't set!");
        }

        return _testEnemy;
    }
}