using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private Experience _Exp;
    [SerializeField] private int _Level;
    [SerializeField] private int _ItemSelectionOnLevel;

    public Action SelectAttribute;
    public Action SelectItem;

    public int Level { get => _Level;}

    private void OnEnable()
    {
        _Exp.OnLevelChanged += LevelUp;
    }
    public void LevelUp()
    {
        _Level++;
        if (_Level % _ItemSelectionOnLevel == 0)
            SelectItem?.Invoke();
        else
            SelectAttribute?.Invoke();
    }

    
}
