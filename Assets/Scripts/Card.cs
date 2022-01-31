using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Card : MonoBehaviour
{
    [SerializeField] private UnityEvent OnCorrect;
    [SerializeField] private UnityEvent OnWrong;

    [SerializeField] private SpriteRenderer _spriteOfSymbol;

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
            print("click");
            if (_purpose)
            {
                print("right click");
                _bouncerOnCorrect.enabled = true;
                OnCorrect?.Invoke();
            }
            else
            {
                print("wrong click");
                _shaker.enabled = true;
                OnWrong?.Invoke();
            }
        }
    }

    public void ChangeSprite(Sprite sprite)
    {
        _spriteOfSymbol.sprite = sprite;
    }

    public void OffInteractable()
    {
        _interactable = false;
    }
}
