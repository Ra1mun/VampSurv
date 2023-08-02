using UnityEngine;

public class RangeDamageDealer : MonoBehaviour, IDamageDealer
{
    private float _attackTime;
    private Entity _entity;

    private void Awake()
    {
        _entity = GetComponent<Entity>();
    }

    public void TryDamage(EntityHealth target, int damage)
    {
        if (_attackTime <= 0)
        {
            _attackTime = Constants.ATTTACK_INTERVAL;
            target.ApplyDamage(damage);
        }

        _attackTime -= Time.deltaTime * _entity.Config.AttackSpeed;
    }

    public void Rest()
    {
        _attackTime = 0;
    }
}