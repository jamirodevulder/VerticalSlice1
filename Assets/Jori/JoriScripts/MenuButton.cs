using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : UIScript
{
    [SerializeField] private PauseButton pauseScript;
    private void Awake()
    {
        AddListener(MenuKnopClicked);
        clickableButton.transform.position = new Vector3(mainCamera.transform.position.x - 9.2f, mainCamera.transform.position.y - 1.5f, mainCamera.transform.position.z + 10);
    }

    private void Update()
    {
        if (pauseScript.buttonGameObjects[5] == true)
        {
            Debug.Log("test");
        }
    }

    void MenuKnopClicked()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
