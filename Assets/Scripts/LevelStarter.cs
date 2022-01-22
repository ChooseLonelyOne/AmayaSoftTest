using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    private void Start()
    {
        StartLevel();
    }

    private void StartLevel()
    {
        EventBus.OnChangeLevel?.Invoke();
        EventBus.OnStart?.Invoke();
        EventBus.OnFadeIn?.Invoke();
    }

    private void OnEnable()
    {
        EventBus.OnRestart.AddListener(StartLevel);
    }
    private void OnDisable()
    {
        EventBus.OnRestart.RemoveListener(StartLevel);
    }
}
