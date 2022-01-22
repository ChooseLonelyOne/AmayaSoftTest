using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FindText : MonoBehaviour
{
    private Text _text;

    private void Start()
    {
        _text = GetComponent<Text>();
    }
    private void ChangeText(string text)
    {
        _text.text = "Find " + text;
    }

    private void OnEnable()
    {
        EventBus.OnFind.AddListener(ChangeText);
    }

    private void OnDisable()
    {
        EventBus.OnFind.RemoveListener(ChangeText);
    }
}
