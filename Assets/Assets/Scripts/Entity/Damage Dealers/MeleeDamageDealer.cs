using UnityEngine;

public class MeleeDamageDealer : MonoBehaviour, IDamageDealer
{
    private float _attackTime;
    private Entity _entity;

    private void Awake()
    {
        _entity = GetComponent<Entity>();
    }

    public void TryDamage(Entity target, int damage)
    {
        if (_attackTime <= 0)
        {
            _attackTime = Constants.ATTTACK_INTERVAL;
            target.Damagable.ApplyDamage(damage);
        }

        _attackTime -= Time.deltaTime * _entity.Stats.GetStats().AttackSpeed;
    }

    public void Rest()
    {
        _attackTime = 0;
    }
}