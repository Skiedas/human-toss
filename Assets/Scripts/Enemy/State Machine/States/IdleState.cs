using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _animator.Play("Idle");
    }
}
