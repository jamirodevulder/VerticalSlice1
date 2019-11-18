using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    bool unpaused = true;
    Text buttonText;
    Button pauseButton;
    Camera mainCamera;
    private void Awake()
    {
        pauseButton = GetComponent<Button>();
        GetComponent<Button>().onClick.AddListener(onButtonClick); //Pakt de onClick function van de Button
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = "Pauzeren";

    }
    void onButtonClick()
    {
        switch (unpaused)
        {
            case true:
                unpaused = false;
                Time.timeScale = 0; //Zet op pause
                buttonText.text = "Spel hervatten";
                break;

            case false:
                unpaused = true;
                Time.timeScale = 1; //Zet weer aan
                buttonText.text = "Pauzeren";
                break;
        }
    }
}
