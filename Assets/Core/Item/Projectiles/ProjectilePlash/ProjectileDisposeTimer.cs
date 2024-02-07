using UnityEngine;

namespace Core.Item.Projectiles.ProjectilePlash
{
    public class ProjectileDisposeTimer : MonoBehaviour
    {
        [SerializeField] [Min(0f)] private float _countdown;
        [SerializeField] private Area _area;
        private float _elapsedTime;

        private void Update()
        {
            if (_area.IsAreaDisposed)
                return;
            _elapsedTime += Time.deltaTime;
            if (_elapsedTime >= _countdown) Dispose();
        }

        private void Dispose()
        {
            _area.DisposeArea();
        }
    }
}