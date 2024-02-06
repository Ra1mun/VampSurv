using UnityEngine;

namespace Core.Item.Moveable
{
    public class CircleMove : MonoBehaviour
    {
        public float radius = 2f;
        public float speed = 2f;
        private float angle;


        private void Start()
        {
        }


        private void Update()
        {
            angle += speed * Time.deltaTime;


            var x = Mathf.Sin(angle) * radius;
            var y = Mathf.Cos(angle) * radius;


            transform.position = new Vector3(x, y, 0f);
        }
    }
}