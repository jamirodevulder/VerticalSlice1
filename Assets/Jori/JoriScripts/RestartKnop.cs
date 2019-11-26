using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartKnop : UIScript
{
    private void Awake()
    {
        GetComponentInChildren<Button>().onClick.AddListener(RestartKnopClicked);
        clickableButton = GetComponentInChildren<Button>();
        mainCamera = FindObjectOfType<Camera>();
        clickableButton.transform.position = new Vector3(mainCamera.transform.position.x - 9.2f, mainCamera.transform.position.y + 1.5f, mainCamera.transform.position.z + 10);
    }

    private void RestartKnopClicked()
    {
        SceneManager.LoadScene("JoriScene");
    }
}
