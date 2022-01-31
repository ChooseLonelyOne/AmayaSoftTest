using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BouncerOnStart : MonoBehaviour
{
    private Sequence _sequence;

    private void Start()
    {
        BounceOnStart();
    }

    public void BounceOnStart()
    {
        _sequence?.Kill();
        _sequence = DOTween.Sequence();

        _sequence.Append(transform.DOScale(0f, 0f));
        _sequence.Append(transform.DOScale(1.2f, .3f));
        _sequence.Append(transform.DOScale(.9f, .1f));
        _sequence.Append(transform.DOScale(1f, .1f));
    }
}
