using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ContinueButton : UIScript
{
    [SerializeField] private PauseButton pauseScript;
    private void Awake()
    {
        AddListener(OnClick);
    }

    private void Update()
    {
    }

    private void OnClick()
    {
        SceneManager.LoadScene("JoriScene");
    }
}