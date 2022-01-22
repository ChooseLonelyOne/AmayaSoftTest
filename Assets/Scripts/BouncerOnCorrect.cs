using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BouncerOnCorrect : MonoBehaviour
{
    private Sequence _sequence;
    private bool _launched = false;

    private void BounceOnCorrect()
    {
        if (!_launched)
        {
            StartCoroutine(Bounce());
        }
    }

    private IEnumerator Bounce()
    {
        _sequence?.Kill();
        _sequence = DOTween.Sequence();

        _launched = true;

        _sequence.Append(transform.DOScale(1f, .1f));
        _sequence.Append(transform.DOScale(.9f, .1f));
        _sequence.Append(transform.DOScale(1.2f, .3f));
        _sequence.Append(transform.DOScale(1f, .1f));

        enabled = false;

        yield return new WaitForSeconds(.6f);

        EventBus.OnChangeLevel?.Invoke();
    }

    private void OnEnable()
    {
        EventBus.OnCorrect.AddListener(BounceOnCorrect);
    }

    private void OnDisable()
    {
        EventBus.OnCorrect.RemoveListener(BounceOnCorrect);
    }
}
