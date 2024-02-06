using System;
using Core.Player.Experience;
using UnityEngine;

namespace Core.Player
{
    public class PlayerLevelObserver : MonoBehaviour
    {
        [SerializeField] private PlayerLevel _playerLevel;

        private void OnEnable()
        {
            _playerLevel.OnLevelChangedEvent += OnLevelChanged;
        }

        private void OnDisable()
        {
            _playerLevel.OnLevelChangedEvent -= OnLevelChanged;
        }

        public event Action OnItemSelectionEvent;
        public event Action OnAttributeSelectionEvent;

        private void OnLevelChanged(int level)
        {
            if (level % Constants.ITEM_SELECTION_ON_LEVEL == 0)
                OnItemSelectionEvent?.Invoke();
            else
                OnAttributeSelectionEvent?.Invoke();
        }
    }
}