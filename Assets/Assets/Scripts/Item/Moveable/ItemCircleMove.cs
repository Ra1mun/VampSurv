using UnityEngine;

namespace Assets.Scripts.Item.Moveable
{
    public class ItemCircleMove : ItemMovable
    {
        [SerializeField] private float _radius = 0.5f;
    
        private Transform _center => transform.parent;
    
        private float _angle;
    
    
        public override void Move()
        {
            _angle += Time.deltaTime;

            var x = Mathf.Cos(_angle) * _radius;
            var y = Mathf.Cos(_angle) * _radius;
            transform.position = _center.position + new Vector3(x, y, 0);
        }
    }
}
