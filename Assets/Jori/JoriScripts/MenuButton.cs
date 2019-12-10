using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuButton : UIScript
{
    private void Awake()
    {
        AddListener(MenuKnopClicked);
    }

    void MenuKnopClicked()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
