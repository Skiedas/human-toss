using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;

    private void Update()
    {
        _animator.Play("Move");
        transform.LookAt(transform.position + transform.position - Target.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
    }
}