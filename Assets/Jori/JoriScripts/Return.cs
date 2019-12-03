using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Return : UIScript
{
    private void Awake()
    {
        AddListener(ReturnKnop);
        clickableButton = GetComponentInChildren<Button>();
    }

    private void ReturnKnop()
    {
        SceneManager.LoadScene("JoriScene");
    }
}
