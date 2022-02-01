using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private CanvasGroup _group;

    private void Awake()
    {
        _group = GetComponent<CanvasGroup>();
    }

    public void Enable()
    {
        _animator.Play("Enable");
        _group.alpha = 1f;
        _group.interactable = true;
        _group.blocksRaycasts = true;
    }
}
