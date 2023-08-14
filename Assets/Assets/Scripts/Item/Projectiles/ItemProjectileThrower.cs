using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemProjectileThrower : MonoBehaviour
{
    protected Transform _parent => transform.parent;
    public abstract void SpawnProjectile();
}
