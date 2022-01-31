using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelCreator : MonoBehaviour
{
    [SerializeField] private UnityEventString OnFind;

    private Grid _grid;

    private float _sizeX;
    private float _sizeY;
    private SpriteRenderer _spriteRenderer;

    private CardBundleData _data;
    private List<Card> _cardList = new List<Card>();

    private int _purposeIndex;

    public void CreateLevel(CardBundleData data)
    {
        _data = data;
        _spriteRenderer = _data.Prefab.GetComponent<SpriteRenderer>();
        CleanLevel();

        _sizeX = _spriteRenderer.size.x;
        _sizeY = _spriteRenderer.size.y;

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
                _cardList.Add(clone.GetComponent<Card>());

                count++;
            }
        }
        _purposeIndex = RandomPurpose();
        InitClones();
    }

    public void OffInteractable()
    {
        for (int i = 0; i < _cardList.Count; i++)
        {
            _cardList[i].OffInteractable();
        }
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
            Card clone = _cardList[i];

            clone.name = _data.CardData[i].Name;
            clone.ChangeSprite(_data.CardData[i].Sprite);
        }

        _cardList[_purposeIndex].Goal = true;
        OnFind?.Invoke(_cardList[_purposeIndex].name);
    }

    private void CleanLevel()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        _cardList.Clear();
    }
}

[System.Serializable]
public class UnityEventString : UnityEvent<string> { }
