using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : UIScript
{
    [SerializeField] private PauseButton pauseScript;
    private void Awake()
    {
        AddListener(RestartKnopClicked);
    }

    private void Update()
    {
        if (pauseScript.gameWon == true)
        {
            clickableButton.transform.position = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y - 2.5f, 0);
        }
    }

    private void RestartKnopClicked()
    {
        SceneManager.LoadScene("JoriScene");
    }
}