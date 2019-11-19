using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : UIScript
{

    private void Awake()
    {
        clickableButton = FindObjectOfType<Button>();
        buttonText = GetComponentInChildren<Text>();
        returnPosition = clickableButton.transform.position;
        clickableButton.transform.position = new Vector3(1000, 1000);
    }
}
