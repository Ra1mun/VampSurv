using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverTimeDamageDealer : MonoBehaviour
{
    [SerializeField] private List<UnitDamageable> _entitiesToDamage = new List<UnitDamageable>();
    [SerializeField] private ProjectilePlash _plash;
    private Coroutine _attackInProgress;

    public void AddEntity(UnitDamageable unit)
    {
        _entitiesToDamage.Add(unit);
        if (_attackInProgress == null)
            _attackInProgress = StartCoroutine(OverTimeDamageDeal());
        //Needs check unit _isAlive?
    }
    public void RemoveEntity(UnitDamageable unit)
    {
        _entitiesToDamage.Remove(unit);
    }
    IEnumerator OverTimeDamageDeal()
    {
        while(_entitiesToDamage.Count > 0)
        {
            foreach(UnitDamageable entity in _entitiesToDamage)
            {
                entity.ApplyDamage(_plash.Damage);
            }
            //Debug.Log("Damage Tick");
            yield return new WaitForSeconds(1.0f);
        }
        _attackInProgress = null;
        
    }
    
}
