using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : UIScript
{
    private void Awake()
    {
        AddListener(RestartKnopClicked);
        clickableButton.transform.position = new Vector3(mainCamera.transform.position.x - 9.2f, mainCamera.transform.position.y + 1.5f, mainCamera.transform.position.z + 10);
    }

    private void RestartKnopClicked()
    {
        SceneManager.LoadScene("JoriScene");
    }
}
