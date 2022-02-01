using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRagdoll : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodyParts;
    [SerializeField] private Collider[] _colliderParts;

    public void Enable()
    {
        foreach (var collider in _colliderParts)
        {
            collider.enabled = true;
        }

        foreach (var rigidbody in _rigidbodyParts)
        {
            rigidbody.isKinematic = false;
        }

    }

    public void Disable()
    {
        foreach (var collider in _colliderParts)
        {
            collider.enabled = false;
        }

        foreach (var rigidbody in _rigidbodyParts)
        {
            rigidbody.isKinematic = true;
        }
    }

    public void SetActive(bool state)
    {
        foreach (var collider in _colliderParts)
        {
            collider.enabled = state;
        }

        foreach (var rigidbody in _rigidbodyParts)
        {
            rigidbody.isKinematic = !state;
        }
    }
}
