using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTransition : Transition
{
    [SerializeField] private float _time;

    private float _timeLeft;

    private void OnEnable()
    {
        _timeLeft = _time;
    }

    private void Update()
    {
        if(_timeLeft <= 0)
        {
            NeedTransit = true;
        }

        _timeLeft -= Time.deltaTime;
    }
}
