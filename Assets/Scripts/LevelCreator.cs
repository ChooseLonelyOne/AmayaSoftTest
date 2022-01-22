using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    private Grid _grid;

    private float _sizeX;
    private float _sizeY;
    private SpriteRenderer spriteRenderer;

    private CardBundleData _data;
    private List<GameObject> _cardList = new List<GameObject>();

    private int _purposeIndex;

    private void CreateLevel(CardBundleData data)
    {
        _data = data;
        spriteRenderer = _data.Prefab.GetComponent<SpriteRenderer>();

        CleanLevel();

        _sizeX = spriteRenderer.size.x;
        _sizeY = spriteRenderer.size.y;

        _grid = new Grid(_data.GridSizeX, _data.GridSizeY, _sizeX, _sizeY, _data.CardData.Length);

        int count = 0;
        for (int y = 0; y < _data.GridSizeY; y++)
        {
            for (int x = 0; x < _data.GridSizeX; x++)
            {
                if (count >= _data.CardData.Length)
                {
                    break;
                }
                GameObject clone = Instantiate(data.Prefab, _grid.GetWorldPosition(x, y), Quaternion.identity, transform);
                _cardList.Add(clone);

                count++;
            }
        }
        _purposeIndex = RandomPurpose();
        InitClones();
    }

    private int RandomPurpose()
    {
        int random = Random.Range(0, _cardList.Count);
        return random;
    }

    private void InitClones()
    {
        for (int i = 0; i < _cardList.Count; i++)
        {
            GameObject clone = _cardList[i];

            clone.name = _data.CardData[i].Name;
            clone.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = _data.CardData[i].Sprite;
        }

        _cardList[_purposeIndex].GetComponent<Card>().Goal = true;
        EventBus.OnFind?.Invoke(_cardList[_purposeIndex].name);
    }

    private void CleanLevel()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        _cardList.Clear();
    }

    private void OnEnable()
    {
        EventBus.OnCreateLevel.AddListener(CreateLevel);
    }

    private void OnDisable()
    {
        EventBus.OnCreateLevel.RemoveListener(CreateLevel);
    }
}
