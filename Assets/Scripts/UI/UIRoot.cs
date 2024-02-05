using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIRoot : MonoBehaviour
{
    public RectTransform Container => _container;
    public RectTransform PoolContainer => _poolContainer;
    
    [SerializeField] private RectTransform _container;
    [SerializeField] private RectTransform _poolContainer;
}
