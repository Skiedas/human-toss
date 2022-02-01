using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private void Update()
    {
        Move();
    }


    private void Move()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
}
