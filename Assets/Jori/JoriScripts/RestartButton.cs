using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : UIScript
{
    [SerializeField] private PauseButton pauseScript;
    [SerializeField] private GameObject Panel;
    private void Awake()
    {
        AddListener(RestartKnopClicked);
    }

    private void Update()
    {
        if (pauseScript.gameWon == true)
        {
           // clickableButton.transform.position = new Vector3(Panel.transform.position.x, Panel.transform.position.y, Panel.transform.position.z);
        }
    }

    private void RestartKnopClicked()
    {
        SceneManager.LoadScene("Main");
    }
}