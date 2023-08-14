using UnityEngine;

public abstract class ItemMovable : MonoBehaviour
{
    protected Transform _center => transform.parent;
    public abstract void Move();
}
