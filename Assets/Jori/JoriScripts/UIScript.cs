using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    private bool unpaused = true; //unpaused true is dat het spel niet gepauzeerd is, unpaused false is gepauzeerd
    private Text buttonText;
    private Button pauseButton;
    private Camera mainCamera;
    private Vector3 returnPosition;

    private void Awake()
    {
        pauseButton = GetComponent<Button>();
        GetComponent<Button>().onClick.AddListener(OnButtonClick); //Pakt de onClick function van de button
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = "Pauzeren";
        mainCamera = FindObjectOfType<Camera>();
        returnPosition = pauseButton.transform.position; //Neemt huidige positie van de pauzeknop
    }
    private void Update()
    {
        if (unpaused)
        {
            returnPosition = pauseButton.transform.position; //Neemt huidige positie van de pauzeknop wanneer het niet gepauzeerd is, als de camera beweegt blijft de positie hetzelfde
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
                pauseButton.transform.position = new Vector3(mainCamera.transform.position.x,mainCamera.transform.position.y,0); //Z positie wordt anders -400
                break;

            case false:
                unpaused = true;
                Time.timeScale = 1; //Zet weer aan
                buttonText.text = "Pauzeren";
                pauseButton.transform.position = returnPosition;
                break;
        }
    }
}
