using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Entity : MonoBehaviour
{
    protected EntityType _type;
    public EntityType Type => _type;
}
