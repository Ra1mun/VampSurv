using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverTimeDamageDealer : MonoBehaviour
{
    [SerializeField] private List<EntityDamageable> _entitiesToDamage = new List<EntityDamageable>();
    [SerializeField] private ProjectilePlash _plash;
    private Coroutine _attackInProgress;

    public void AddEntity(EntityDamageable entity)
    {
        _entitiesToDamage.Add(entity);
        if (_attackInProgress == null)
            _attackInProgress = StartCoroutine(OverTimeDamageDeal());
        //Needs check entity _isAlive?
    }
    public void RemoveEntity(EntityDamageable entity)
    {
        _entitiesToDamage.Remove(entity);
    }
    IEnumerator OverTimeDamageDeal()
    {
        while(_entitiesToDamage.Count > 0)
        {
            foreach(EntityDamageable entity in _entitiesToDamage)
            {
                entity.ApplyDamage(_plash.Damage);
            }
            //Debug.Log("Damage Tick");
            yield return new WaitForSeconds(1.0f);
        }
        _attackInProgress = null;
        
    }
    
}
