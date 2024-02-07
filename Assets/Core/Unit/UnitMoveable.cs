using Core.Pause.Scripts;
using UnityEngine;

namespace Core.Unit
{
    public abstract class UnitMoveable : MonoBehaviour
    {
        protected bool IsPaused => ProjectContext.Instance.PauseManager.IsPaused;

        public abstract void Move(Vector2 direction);
    }
}