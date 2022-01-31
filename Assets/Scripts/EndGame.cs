using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private GameObject _button;
    [SerializeField] private Animator _loadScreen;
    private Animator _animator;
    private bool _launched = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _button.SetActive(false);
    }

    public void Restart()
    {
        if (!_launched)
        {
            StartCoroutine(LoadGame());
        }
    }

    public void End()
    {
        _button.SetActive(true);
        _animator.SetTrigger("FadeIn");
    }

    private IEnumerator LoadGame()
    {
        _launched = true;
        _button.SetActive(false);
        _animator.SetTrigger("FadeOut");
        _loadScreen.SetTrigger("Close");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
