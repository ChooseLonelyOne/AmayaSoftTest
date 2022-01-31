using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private CardBundleData[] _data;
    [SerializeField] private UnityEventCardBundleData OnCreateLevel;
    [SerializeField] private UnityEvent OnEndGame;
    [SerializeField] private UnityEvent OnInteractable;

    private int _currentDataIndex = -1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeLevel();
        }
    }

    public void ChangeLevel()
    {
        OnInteractable?.Invoke();
        if (_currentDataIndex < _data.Length - 1)
        {
            _currentDataIndex++;
            OnCreateLevel?.Invoke(_data[_currentDataIndex]);
        }
        else
        {
            OnEndGame?.Invoke();
        }
    }
}

[System.Serializable]
public class UnityEventCardBundleData : UnityEvent<CardBundleData> { }
