using UnityEngine;
using Core.Item.Projectiles.DamageDealers;
using Core.Unit.Damage_Dealers;

namespace Core.Item.Projectiles.ProjectilePlash
{
    public abstract class Area : MonoBehaviour
    {
        [SerializeField] private LayerMask _targetLayerMask;

        [SerializeField] protected IDamageDealer _damageDealer;

        public bool IsAreaDisposed;
        [SerializeField]protected bool IsPeriodicalDamage;

        //protected int _damage;
        protected ItemStats _stats;
        //protected float _radius;
        

        private void OnTriggerStay2D(Collider2D collision)
        {
            
            if (IsAreaDisposed)
                return;
            if (!IsPeriodicalDamage)
                return;
            Debug.Log("collision Stay");
            if (collision.gameObject.TryGetComponent(out Unit.Unit unit))
            {
                if (1 << collision.gameObject.layer == _targetLayerMask.value) OnTargetCollision(collision, unit);
            }
            else
            {
                OnOtherCollision(collision);
            }

            OnAnyCollision(collision);
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            
            if (IsAreaDisposed)
                return;
            if (IsPeriodicalDamage)
                return;
            Debug.Log("Collision Enter");
            if (collision.gameObject.TryGetComponent(out Unit.Unit unit))
            {
                if (1 << collision.gameObject.layer == _targetLayerMask.value) OnTargetCollision(collision, unit);
            }
            else
            {
                OnOtherCollision(collision);
            }

            OnAnyCollision(collision);
        }
        public virtual void Initialize(ItemStats stats)
        {
            _stats = stats;
            
            if (TryGetComponent<PeriodicalDamageDealer>(out PeriodicalDamageDealer perDamageDealer))
            {
                _damageDealer = perDamageDealer;
                IsPeriodicalDamage = true;
            }
            else if(TryGetComponent<BasicDamageDealer>(out BasicDamageDealer damageDealer))
            {
                _damageDealer = damageDealer;
                IsPeriodicalDamage = false;
            }
            

            // TODO: Add changable radius of plash by attribute
        }

        public void DisposeArea()
        {
            OnProjectileDispose();
            Destroy(gameObject);
            IsAreaDisposed = true;
            Debug.Log("Plash Disposed");
        }

        protected virtual void OnProjectileDispose()
        {
        }

        protected virtual void OnAnyCollision(Collider2D collision)
        {
        }

        protected virtual void OnOtherCollision(Collider2D collision)
        {
        }

        protected virtual void OnTargetCollision(Collider2D collision, Unit.Unit unit)
        {
        }

        protected virtual void ManualDispose()
        {
        }
    }
}