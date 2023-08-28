using UnityEngine;

public class RangeDamageDealer : MonoBehaviour, IDamageDealer
{
    private float _attackTime;
    private EntityStats _entityStats;

    private void Awake()
    {
        _entityStats = GetComponent<EntityStats>();
    }

    public void TryDamage(Entity target, int damage)
    {
        if (_attackTime <= 0)
        {
            _attackTime = Constants.ATTTACK_INTERVAL;
            if (target.TryGetComponent(out EntityDamageable damagable))
            {
                damagable.ApplyDamage(_entityStats.GetStats().Damage);
            }
        }

        _attackTime -= Time.deltaTime * _entityStats.GetStats().AttackSpeed;
    }

    public void Rest()
    {
        _attackTime = 0;
    }
}