using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollState : State
{
    [SerializeField] private Animator _animator;
    [SerializeField] private EnemyRagdoll _ragdoll;

    private void OnEnable()
    {
        _ragdoll.SetActive(true);
        _animator.enabled = false;
    }

    private void OnDisable()
    {
        _ragdoll.SetActive(false);
        _animator.enabled = true;
    }
}