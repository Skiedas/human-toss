using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitParticle : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 2f);
    }
}
