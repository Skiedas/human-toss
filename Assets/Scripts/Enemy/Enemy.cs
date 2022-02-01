using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using RootMotion.Dynamics;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private int _health;
    [SerializeField] private SkinnedMeshRenderer _renderer;
    [SerializeField] private Material _deathMaterial;
    [SerializeField] private PuppetMaster _puppetMaster;
    [SerializeField] private Target _arrow;

    public Player Target => _target;

    public event UnityAction<Enemy> Dying;

    public void TakeDamage(int damage)
    {
        _health -= damage;

        if(_health <= 0)
        {
            Dying?.Invoke(this);
            _renderer.material = _deathMaterial;
            _puppetMaster.Kill();
            _arrow.enabled = false;
        }
    }
}