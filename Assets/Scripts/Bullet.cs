using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    public int Damage => _damage;

    private Player _target;
    private Vector3 _targetPosition;
    private Vector3 _shootPosition;

    private void OnEnable()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        if(_target)
            Move();
    }

    public void Init(Player target, Transform shootPoint)
    {
        _target = target;
        _targetPosition = _target.transform.position;
        _shootPosition = shootPoint.position;
    }

    private void Move()
    {
        Vector3 direction = (new Vector3(_targetPosition.x, _shootPosition.y, _targetPosition.z) - _shootPosition).normalized;
        transform.position += direction * _speed * Time.deltaTime;
    }
}
