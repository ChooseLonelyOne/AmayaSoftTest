using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CardData
{
    [SerializeField] private string _name;

    [SerializeField] private Sprite _sprite;

    public string Name => _name;

    public Sprite Sprite => _sprite;
}
