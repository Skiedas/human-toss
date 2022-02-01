using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ComboView : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;
    [SerializeField] private WeaponCombo _combo;
    [SerializeField] private CanvasGroup _group;

    private Sequence _sequence;

    private void OnEnable()
    {
        _combo.HitIncreased += OnHitIncreased;
    }

    private void OnDisable()
    {
        _combo.HitIncreased -= OnHitIncreased;
    }

    private void OnHitIncreased(int hitcount)
    {
        if(hitcount > 1)
        {
            PanelSetState(true);
            _view.text = $"COMBO X{hitcount}";
            StartEffect(1f, 1.3f, .2f);
        }
        else
        {
            PanelSetState(false);
        }
    }

    private void PanelSetState(bool state)
    {
        if (state)
            _group.alpha = 1f;
        else
            _group.alpha = 0f;

        _group.interactable = state;
        _group.blocksRaycasts = state;
    }

    private void StartEffect(float startValue, float endValue, float duration)
    {
        _sequence = null;
        _sequence = DOTween.Sequence();
        _sequence.Append(_view.rectTransform.DOScale(endValue, duration)).Append(_view.rectTransform.DOScale(startValue, duration))
            .AppendInterval(2f).AppendCallback(new TweenCallback(DisablePanel)).SetLoops(1).Play();
    }

    private void DisablePanel()
    {
        PanelSetState(false);
    }
}
