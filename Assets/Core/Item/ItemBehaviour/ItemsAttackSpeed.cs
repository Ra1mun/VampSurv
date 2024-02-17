using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsAttackSpeed : IAttackSpeed
{
    public float GetAttackInterval(float attackSpeed)
    {
        float attackInterval = 5 * Mathf.Pow(2.71828175f, -0.1f * attackSpeed);
        return attackInterval;
    }
}
