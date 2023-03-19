using System;
<<<<<<< HEAD
=======
using UnityEngine;
>>>>>>> BorisBranch

public class Tower : Entity
{
    private int _maxHealth;
    private int _currentHealth;

    public event Action<int, int> OnHealthChanged;
    public override event Action<Entity> OnDie;

    private Entity _target;
    //TowerStats _stats;
    //private IDamageDealer _damageDealer;
    public static Tower instance;

    public override event Action<Entity> OnDie;

    private void Awake()
    {
        //_stats = new TowerStats();
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    //public void Initialize(int maxHealth, float attackDistance, float attackSpeed, int damage, EntityType type)
    //{

    //}

    private void Start()
    {
        //Debug.Log(_stats.DebugGetStats());
    }
    public void UpdateStats(int maxHealth) // В будущем лучше сделать прослойку. Типа StatsManager
    {
        //_stats._maxHealth += maxHealth;
    }

    public override void OnUpdate(ITargetFinder targetFinder)
    {

    }

<<<<<<< HEAD
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
=======
    public override void ApplyDamage(int damage)
>>>>>>> BorisBranch
    {
        throw new NotImplementedException();
    }
}
