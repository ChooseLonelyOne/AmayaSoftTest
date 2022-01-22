using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private Shaker _shaker;
    private BouncerOnCorrect _bouncerOnCorrect;

    private bool _purpose = false;
    private bool _interactable = true;

    public bool Goal { set { _purpose = value; } }

    private void Start()
    {
        _shaker = GetComponentInChildren<Shaker>();
        _bouncerOnCorrect = GetComponentInChildren<BouncerOnCorrect>();
    }

    private void OnMouseDown()
    {
        if (_interactable)
        {
            if (_purpose)
            {
                _bouncerOnCorrect.enabled = true;
                EventBus.OnCorrect?.Invoke();
            }
            else
            {
                _shaker.enabled = true;
                EventBus.OnWrong?.Invoke();
            }
        }
    }

    private void OffInteractable()
    {
        _interactable = false;
    }    

    private void OnEnable()
    {
        EventBus.OnEndGame.AddListener(OffInteractable);
    }

    private void OnDisable()
    {
        EventBus.OnEndGame.RemoveListener(OffInteractable);
    }
}
