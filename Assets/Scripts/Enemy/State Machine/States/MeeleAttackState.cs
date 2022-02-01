using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeeleAttackState : State
{
    [SerializeField] private Animator _animator;
    [SerializeField] private int _damage;
    [SerializeField] private float _delay = 2f;

    private float _lastAttackTime;

    private void Update()
    {
        if(_lastAttackTime <= 0)
        {
            Attack();
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
    }

    private void Attack()
    {
        _animator.Play("MeeleAttack");
        Target.ApplyDamage(_damage);
    }
}