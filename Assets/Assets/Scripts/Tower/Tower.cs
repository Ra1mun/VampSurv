using System;
using UnityEngine;

public class Tower : Entity
{
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

    public override void ApplyDamage(int damage)
    {
        throw new NotImplementedException();
    }
}
