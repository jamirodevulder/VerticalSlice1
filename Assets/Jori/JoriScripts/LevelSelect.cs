using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : UIScript
{
    [SerializeField] private PauseButton pauseScript;
    private void Awake()
    {
        AddListener(LevelSelectClicked);
        clickableButton.transform.position = new Vector3(mainCamera.transform.position.x - 9.2f, mainCamera.transform.position.y, mainCamera.transform.position.z + 10);
    }

    private void Update()
    {
        if (pauseScript.gameWon == true)
        {
            clickableButton.transform.position = new Vector3(mainCamera.transform.position.x - 4f, mainCamera.transform.position.y -1 , 0);
        }
    }

    void LevelSelectClicked()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}