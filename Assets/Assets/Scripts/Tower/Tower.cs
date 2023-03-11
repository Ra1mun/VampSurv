using System;

public class Tower : Entity
{
    private int _maxHealth;
    private int _currentHealth;

    public event Action<int, int> OnHealthChanged;
    public override event Action<Entity> OnDie;

    private Entity _target;

    private IDamageDealer _damageDealer;
    
    public void Initialize(int maxHealth, float attackDistance, float attackSpeed, int damage, EntityType type)
    {
        _maxHealth = maxHealth;
        _attackDistance = attackDistance;
        _attackSpeed = attackSpeed;
        _damage = damage;
        _type = type;
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public override void OnUpdate(ITargetFinder targetFinder)
    {
        
    }

    private bool IsAlive()
    {
        return _currentHealth > 0;
    }

    public override void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        OnHealthChanged?.Invoke(_maxHealth, _currentHealth);

        if (!IsAlive())
        {
            OnDie?.Invoke(this);
        }
    }

    private void Awake()
    {
        _damageDealer = GetComponent<IDamageDealer>();
    }
}
