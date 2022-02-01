using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarMover : MonoBehaviour
{
    [SerializeField] private Player _target;

    private void Update()
    {
        SetLookRotation();
        FollowTarget();
    }

    private void SetLookRotation()
    {
        transform.LookAt(Camera.main.transform);
    }

    private void FollowTarget()
    {
        transform.position = new Vector3(_target.transform.position.x, transform.position.y, _target.transform.position.z);
    }
}
