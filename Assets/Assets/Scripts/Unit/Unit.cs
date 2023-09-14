using System;
using UnityEngine;
using UnityEngine.Serialization;

public abstract class Unit : MonoBehaviour
{
    protected UnitType _type;
    public UnitType Type => _type;
}
