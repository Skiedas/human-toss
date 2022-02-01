using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Bullet bullet))
        {
            _player.ApplyDamage(bullet.Damage);
        }
    }
}
