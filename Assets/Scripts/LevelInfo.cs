using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] private Enemy[] _enemies;
    [SerializeField] private GameOverScreen _overScreen;
    [SerializeField] private ComboView _comboView;

    private int _enemyCount;
    private int _enemyLeft;

    private void Awake()
    {
        _enemyCount = _enemies.Length;
        _enemyLeft = _enemyCount;
    }

    private void OnEnable()
    {
        foreach (var enemy in _enemies)
        {
            enemy.Dying += OnEnemyDying;
        }
    }

    private void OnEnemyDying(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDying;
        _enemyLeft--;
        Debug.Log(_enemyLeft);

        if(_enemyLeft == 0)
        {
            _comboView.gameObject.SetActive(false);
            _overScreen.Enable();
            Time.timeScale = .1f;
        }
    }

}
