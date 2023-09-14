using UnityEngine;

public class RangeDamageDealer : MonoBehaviour, IDamageDealer
{
    private float _attackTime;
    private UnitStats _unitStats;

    private void Awake()
    {
        _unitStats = GetComponent<UnitStats>();
    }

    public void TryDamage(Unit target, int damage)
    {
        if (_attackTime <= 0)
        {
            _attackTime = Constants.ATTTACK_INTERVAL;
            if (target.TryGetComponent(out IDamageable damageable))
            {
                damageable.ApplyDamage(_unitStats.GetStats().Damage);
            }
        }

        _attackTime -= Time.deltaTime * _unitStats.GetStats().AttackSpeed;
    }

    public void Rest()
    {
        _attackTime = 0;
    }
}