using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private int _damage;
    [SerializeField] private int _spreadRange;
    [SerializeField] private HitParticle _hitParticle;

    private int _currentDamage;

    public HitParticle HitParticle => _hitParticle;
    public float Speed => _rigidbody.velocity.magnitude;

    public event UnityAction Hiting;

    private void Awake()
    {
        ChangeDamage();
    }

    public void ChangeDamage(float damageMultiplier = 1f)
    {
        _currentDamage = Mathf.RoundToInt((_damage + Random.Range(0, _spreadRange)) * damageMultiplier);
    }

    public int Hit()
    {
        Hiting?.Invoke();
        return _currentDamage;
    }
}
