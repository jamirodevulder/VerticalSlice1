using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : UIScript
{
    public bool gameWon; //Voor als het spel gewonnen is
    public GameObject[] buttonGameObjects = new GameObject[6]; //Array van GameObjects, parents van knoppen
    private bool unpaused; //unpaused true is dat het spel niet gepauzeerd is, false is gepauzeerd
    private RectTransform buttonTransform;
    [SerializeField] private Sprite pausedImage; //Image voor de pauzeknop als het spel op pauze staat
    [SerializeField] private Sprite unpausedImage; //Image voor de pauzeknop als het spel niet op pauze staat

    private void Awake()
    {
        buttonGameObjects[0] = GameObject.Find("LSBGameObject"); //Zoekt het GameObject, levelselectknop
        buttonGameObjects[1] = GameObject.Find("BackgroundGameObject"); //Achtergrond
        buttonGameObjects[2] = GameObject.Find("MBGameObject"); //Menuknop
        buttonGameObjects[3] = GameObject.Find("RBGameObject"); //RestartKnop
        buttonGameObjects[4] = GameObject.Find("MuteButtonGameObject"); //MuteKnop
        buttonGameObjects[5] = GameObject.Find("WSGameObject"); //Winscherm
        buttonGameObjects[5].SetActive(false);
        SetObjectState(false);
        //PauzeButton gerelateerde code
        AddListener(OnButtonClick); //Pakt de onClick function van de button
        buttonTransform = clickableButton.GetComponent<RectTransform>();
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = "";
        //PauzeButton-positie gerelateerde code
        mainCamera = FindObjectOfType<Camera>();
        transform.position = new Vector3(mainCamera.transform.position.x - 9.95f, mainCamera.transform.position.y + 4.29f, 0); //Zet in de hoek
        returnPosition = clickableButton.transform.position; //Neemt huidige positie van de pauzeknop
        //Voor als het spel herstart wordt
        unpaused = true;
        Time.timeScale = 1;
        gameWon = false;
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
                PauseGame(false, 0, pausedImage);
                ResizeButton(45, 46);
                clickableButton.transform.position = new Vector3(mainCamera.transform.position.x - 7.7f, mainCamera.transform.position.y, 0); //Z positie wordt anders -400
                SetObjectState(true);
                break;

            case false:
                PauseGame(true, 1, unpausedImage);
                ResizeButton(82, 77);
                clickableButton.transform.position = returnPosition;
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
        for (int i = 0; i < 5; i++)
        {
            buttonGameObjects[i].SetActive(tempBool);
        }
    }

    void PauseGame(bool paused, int timeScale, Sprite tempSprite)
    {
        unpaused = paused;
        Time.timeScale = timeScale; //Hervat spel
        buttonText.text = "";
        clickableButton.image.sprite = tempSprite;
    }
}