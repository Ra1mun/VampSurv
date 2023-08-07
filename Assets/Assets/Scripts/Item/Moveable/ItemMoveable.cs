using UnityEngine;

public abstract class ItemMoveable : MonoBehaviour
{
    protected Transform _center => transform.parent;
    public abstract void Move();
}
