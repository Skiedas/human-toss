using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyCollisionHandler : MonoBehaviour
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerWeapon weapon))
        {
            _enemy.TakeDamage(weapon.Hit());
            Instantiate(weapon.HitParticle, other.ClosestPoint(weapon.transform.position), Quaternion.identity);
        }
    }
}
