using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : UIScript
{
    public bool unpaused; //unpaused true is dat het spel niet gepauzeerd is, false is gepauzeerd
    private GameObject[] buttonGameObjects = new GameObject[5];
    private RectTransform buttonTransform;
    [SerializeField] private Sprite pausedImage; //Image voor de pauzeknop als het spel op pauze staat
    [SerializeField] private Sprite unpausedImage; //Image voor de pauzeknop als het spel niet op pauze staat

    private void Awake()
    {
        buttonGameObjects[0] = GameObject.Find("LSBGameObject"); //Zoekt het GameObject, LevelSelectButton
        buttonGameObjects[1] = GameObject.Find("BackgroundGameObject"); //achtergrond
        buttonGameObjects[2] = GameObject.Find("MKGameObject"); //Menuknop
        buttonGameObjects[3] = GameObject.Find("RKGameObject"); //RestartKnop
        buttonGameObjects[4] = GameObject.Find("MuteKnopGameObject"); //MuteKnop
        SetObjectState(false);
        //PauzeButton gerelateerde code
        clickableButton = GetComponent<Button>();
        buttonTransform = clickableButton.GetComponent<RectTransform>();
        clickableButton.onClick.AddListener(OnButtonClick); //Pakt de onClick function van de button
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = "";
        //PauzeButton-positie gerelateerde code
        mainCamera = FindObjectOfType<Camera>();
        transform.position = new Vector3(mainCamera.transform.position.x - 9.95f, mainCamera.transform.position.y + 4.29f, 0); //Zet in de hoek
        returnPosition = clickableButton.transform.position; //Neemt huidige positie van de pauzeknop
        //Voor als het spel herstart wordt
        unpaused = true;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (unpaused)
        {
            returnPosition = clickableButton.transform.position; //Neemt huidige positie van de pauzeknop wanneer het niet gepauzeerd is, als de camera beweegt blijft de positie hetzelfde
            ResizeButton(82, 77);
        }
    }

    private void OnButtonClick()
    {
        switch (unpaused)
        {
            case true:
                unpaused = false;
                Time.timeScale = 0; //Zet op pause
                buttonText.text = "";
                ResizeButton(45, 46);
                clickableButton.image.sprite = pausedImage;
                clickableButton.transform.position = new Vector3(mainCamera.transform.position.x - 7.7f, mainCamera.transform.position.y, 0); //Z positie wordt anders -400
                SetObjectState(true);
                break;

            case false:
                unpaused = true;
                Time.timeScale = 1; //Hervat spel
                buttonText.text = "";
                clickableButton.transform.position = returnPosition;
                ResizeButton(82, 77);
                clickableButton.image.sprite = unpausedImage;
                SetObjectState(false);
                break;
        }
    }

    void ResizeButton(float x, float y)
    {
        buttonTransform.sizeDelta = new Vector2(x, y);
    }

    void SetObjectState(bool tempBool)
    {
        buttonGameObjects[0].SetActive(tempBool);
        buttonGameObjects[1].SetActive(tempBool);
        buttonGameObjects[2].SetActive(tempBool);
        buttonGameObjects[3].SetActive(tempBool);
        buttonGameObjects[4].SetActive(tempBool);
    }
}