using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackState : State
{
    [SerializeField] private Animator _animator;
    [SerializeField] private Bullet _template;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _delay = 4f;

    private float _lastAttackTime;

    private void OnEnable()
    {
        _lastAttackTime = 0;
    }

    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            Attack(Target);
            _lastAttackTime = _delay;
        }

        _lastAttackTime -= Time.deltaTime;
        transform.LookAt(transform.position + transform.position - Target.transform.position);
    }

    private void Attack(Player target)
    {
        _animator.Play("RangeAttack");
        var bullet = Instantiate(_template, _shootPoint.position, Quaternion.identity);
        bullet.Init(Target, _shootPoint);
    }
}
