using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : UIScript
{
    //unpaused true is dat het spel niet gepauzeerd is, false is gepauzeerd
    private void Awake()
    {
        clickableButton = GetComponent<Button>();
        GetComponent<Button>().onClick.AddListener(OnButtonClick); //Pakt de onClick function van de button
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = "Pauzeren";
        mainCamera = FindObjectOfType<Camera>();
        returnPosition = clickableButton.transform.position; //Neemt huidige positie van de pauzeknop
    }
    private void Update()
    {
        if (unpaused)
        {
            returnPosition = clickableButton.transform.position; //Neemt huidige positie van de pauzeknop wanneer het niet gepauzeerd is, als de camera beweegt blijft de positie hetzelfde
        }
    }
    private void OnButtonClick()
    {
        switch (unpaused)
        {
            case true:
                unpaused = false;
                Time.timeScale = 0; //Zet op pause
                buttonText.text = "Spel hervatten";
                clickableButton.transform.position = new Vector3(mainCamera.transform.position.x - 9.2f,mainCamera.transform.position.y + 1,0); //Z positie wordt anders -400
                break;

            case false:
                unpaused = true;
                Time.timeScale = 1; //Zet weer aan
                buttonText.text = "Pauzeren";
                clickableButton.transform.position = returnPosition;
                break;
        }
    }
}
