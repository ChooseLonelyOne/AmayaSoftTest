using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;

public static class EventBus
{
    public static UnityEvent OnStart = new UnityEvent();
    public static UnityEvent OnRestart = new UnityEvent();

    public static UnityEvent OnFadeIn = new UnityEvent();
    public static UnityEvent OnFadeOut = new UnityEvent();

    public static CreateLevelEvent OnCreateLevel = new CreateLevelEvent();
    public static OnFindTextChange OnFind = new OnFindTextChange();
    public static UnityEvent OnChangeLevel = new UnityEvent();
    public static UnityEvent OnEndGame = new UnityEvent();

    public static UnityEvent OnWrong = new UnityEvent();
    public static UnityEvent OnCorrect = new UnityEvent();
}

[Serializable]
public class CreateLevelEvent : UnityEvent<CardBundleData>
{

}

[Serializable]
public class OnFindTextChange : UnityEvent<string>
{

}
