using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace Core.Item.Projectiles
{
    public class ProjectileView : MonoBehaviour
    {
        public Vector2 target;
        
        
        private void Start()
        {
            if(target != null)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y,
                    Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x) * Mathf.Rad2Deg - 90);
            }
                
        }
    }
}