using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shaker : MonoBehaviour
{
    private Sequence _sequence;
    private void Shake()
    {
        _sequence?.Kill();
        _sequence = DOTween.Sequence();

        _sequence.Append(transform.DOLocalMoveX(.15f, .1f));
        _sequence.Append(transform.DOLocalMoveX(-.15f, .1f));
        _sequence.Append(transform.DOLocalMoveX(.15f, .1f));
        _sequence.Append(transform.DOLocalMoveX(-.15f, .1f));
        _sequence.Append(transform.DOLocalMoveX(0f, .1f));

        enabled = false;
    }

    private void OnEnable()
    {
        EventBus.OnWrong.AddListener(Shake);
    }

    private void OnDisable()
    {
        EventBus.OnWrong.RemoveListener(Shake);
    }
}
