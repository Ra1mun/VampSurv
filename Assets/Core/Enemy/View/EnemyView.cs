using Core.Enemy;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace Assets.Scripts.Enemy
{
    public class EnemyView : MonoBehaviour
    {

        [SerializeField] private Animator _animator;
        [SerializeField] private EnemyHealth _health;

        void Start()
        {
            _health.OnHealthChanged += DamagedAimation;

        }

        void Update()
        {
        }
        private void DamagedAimation(int damage)
        {
            if(damage>0)
            {
                _animator.SetTrigger("GetDamage");
            }
        }

    }
}
