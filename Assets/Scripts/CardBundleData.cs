using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New CardBundleData", menuName = "Card Bundle Data", order = 10)]
public class CardBundleData : ScriptableObject
{
    [SerializeField] private CardData[] _cardData;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _gridSizeX;

    public CardData[] CardData => _cardData;
    public GameObject Prefab => _prefab;
    public int GridSizeX => _gridSizeX;
    public int GridSizeY => GetGridSizeY(_cardData.Length, _gridSizeX);

    private int GetGridSizeY(int length, int sizeX)
    {
        int size = Mathf.CeilToInt((float)length / (float)sizeX);
        return size;
    }
}
