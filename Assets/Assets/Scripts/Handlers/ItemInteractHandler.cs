using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractHandler : MonoBehaviour
{
    [SerializeField] private GameLogic _gameLogic;
    [SerializeField] private List<ItemInteractable> _interactables;

    /*private void OnEnable()
    {
        foreach (var interactable in _interactables)
        {
            interactable.OnItemInteracted += _gameLogic.OnItemInteracted;
        }
    }

    public void AddInteractableItem(ItemInteractable interactable)
    {
        _interactables.Add(interactable);
        interactable.OnItemInteracted += _gameLogic.OnItemInteracted;
    }
    
    public void RemoveInteractableItem(ItemInteractable interactable)
    {
        _interactables.Remove(interactable);
        interactable.OnItemInteracted -= _gameLogic.OnItemInteracted;
    }

    private void OnDisable()
    {
        foreach (var interactable in _interactables)
        {
            interactable.OnItemInteracted -= _gameLogic.OnItemInteracted;
        }
    }*/
}
