using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponCombo : MonoBehaviour
{
    [SerializeField] private float _maxTimeBetweenHits;
    [SerializeField] private float _damageMultiplierStep;
    [SerializeField] private PlayerWeapon _weapon;

    private int _hitCount;
    private float _lastHitTime;
    private float _currentMultiplier = 1f;

    public event UnityAction<int> HitIncreased;

    private void OnEnable()
    {
        _weapon.Hiting += OnHiting;
    }

    private void OnDisable()
    {
        _weapon.Hiting -= OnHiting;
    }

    public void AddHit()
    {
        if(Time.time - _lastHitTime < _maxTimeBetweenHits)
        {
            _hitCount++;
            _currentMultiplier += _damageMultiplierStep;
            _weapon.ChangeDamage(_currentMultiplier);
            StartCoroutine(SlowDownTime(.5f, .75f));
        }
        else
        {
            _hitCount = 1;
            _currentMultiplier = 1f;
        }

        HitIncreased?.Invoke(_hitCount);
        _lastHitTime = Time.time;
    }

    private void OnHiting()
    {
        AddHit();
    }

    private IEnumerator SlowDownTime(float duration, float timeScale)
    {
        Time.timeScale = 1f * timeScale;
        yield return new WaitForSeconds(duration);
        Time.timeScale = 1f;
    }
}
