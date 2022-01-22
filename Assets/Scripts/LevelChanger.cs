using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private CardBundleData[] _data;

    private int _currentDataIndex = -1;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeLevel();
        }
    }

    private void ChangeLevel()
    {
        if (_currentDataIndex < _data.Length - 1)
        {
            _currentDataIndex++;
            EventBus.OnCreateLevel?.Invoke(_data[_currentDataIndex]);
        }
        else
        {
            EventBus.OnEndGame?.Invoke();
        }
    }

    private void OnEnable()
    {
        EventBus.OnChangeLevel.AddListener(ChangeLevel);
    }

    private void OnDisable()
    {
        EventBus.OnChangeLevel.RemoveListener(ChangeLevel);
    }
}
