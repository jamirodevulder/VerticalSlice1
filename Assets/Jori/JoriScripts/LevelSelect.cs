using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : UIScript
{
    private void Awake()
    {
        GetComponentInChildren<Button>().onClick.AddListener(LevelSelectClicked);
        clickableButton = GetComponentInChildren<Button>();
        mainCamera = FindObjectOfType<Camera>();
        clickableButton.transform.position = new Vector3(mainCamera.transform.position.x - 9.2f, mainCamera.transform.position.y, mainCamera.transform.position.z + 10);
    }

    void LevelSelectClicked()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}