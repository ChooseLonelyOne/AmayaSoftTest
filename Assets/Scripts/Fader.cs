using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Fader : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }

    public void FadeIn()
    {
        Fade(.7f, 1f);
    }

    public void FadeOut()
    {
        Fade(0, 1f);
    }

    private void Fade(float value, float duration)
    {
        _text.DOFade(value, duration);
    }
}
