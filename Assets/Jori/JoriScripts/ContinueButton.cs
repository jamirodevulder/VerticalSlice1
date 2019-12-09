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
        if (pauseScript.gameWon == true)
        {
            clickableButton.transform.position = new Vector3(mainCamera.transform.position.x + 2f, mainCamera.transform.position.y - 2.5f, 0);
        }
    }

    private void OnClick()
    {
        SceneManager.LoadScene("JoriScene");
    }
}