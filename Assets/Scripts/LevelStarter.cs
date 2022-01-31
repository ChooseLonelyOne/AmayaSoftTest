using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelStarter : MonoBehaviour
{
    [SerializeField] private UnityEvent OnFadeIn;
    [SerializeField] private UnityEvent OnChangeLevel;

    private void Start()
    {
        StartLevel();
    }

    private void StartLevel()
    {
        OnChangeLevel?.Invoke();
        OnFadeIn?.Invoke();
    }
}
