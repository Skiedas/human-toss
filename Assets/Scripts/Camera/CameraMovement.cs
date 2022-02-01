using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _offsetZ;
    [SerializeField] private float _speed;

    private void Update()
    {
        if (transform.position != _target.position)
            Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(_target.position.x, transform.position.y, _target.position.z + _offsetZ), _speed * Time.deltaTime);
    }
}
