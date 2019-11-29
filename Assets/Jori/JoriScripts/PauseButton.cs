using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : UIScript
{
    public bool unpaused; //unpaused true is dat het spel niet gepauzeerd is, false is gepauzeerd
    private GameObject levelSelectGO; //levelSelectGameObject
    private GameObject menuKnopGO; //menuKnopGameObject
    private GameObject restartKnopGO; //restartKnopGameObject
    private GameObject muteKnopGO; //muteKnopGameObject
    private GameObject achtergrondGO; //achtergrondGameObject
    [SerializeField] private Sprite pausedImage; //Image voor de pauzeknop als het spel op pauze staat
    [SerializeField] private Sprite unpausedImage; //Image voor de pauzeknop als het spel niet op pauze staat

    private void Awake()
    {   //LevelSelectButton gerelateerde code
        levelSelectGO = GameObject.Find("LSBGameObject"); //Zoekt het GameObject
        //achtergrond gerelateerde code
        achtergrondGO = GameObject.Find("BackgroundGameObject");
        //Menuknop gerelateerde code
        menuKnopGO = GameObject.Find("MKGameObject");
        //RestartKnop gerelateerde code
        restartKnopGO = GameObject.Find("RKGameObject");
        //MuteKnop gerelateerde code
        muteKnopGO = GameObject.Find("MuteKnopGameObject");
        //PauzeButton gerelateerde code
        clickableButton = GetComponent<Button>();
        GetComponent<Button>().onClick.AddListener(OnButtonClick); //Pakt de onClick function van de button
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = "";
        //PauzeButton-positie gerelateerde code
        mainCamera = FindObjectOfType<Camera>();
        transform.position = new Vector3(mainCamera.transform.position.x - 9.95f, mainCamera.transform.position.y + 4.29f,0); //Zet in de hoek
        returnPosition = clickableButton.transform.position; //Neemt huidige positie van de pauzeknop
        //Voor als het spel herstart wordt
        unpaused = true;
        Time.timeScale = 1;
    }
    private void Start()
    {
        levelSelectGO.SetActive(false);
        menuKnopGO.SetActive(false);
        restartKnopGO.SetActive(false);
        muteKnopGO.SetActive(false);
        achtergrondGO.SetActive(false);
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
                clickableButton.transform.position = new Vector3(mainCamera.transform.position.x - 7.7f,mainCamera.transform.position.y,0); //Z positie wordt anders -400
                levelSelectGO.SetActive(true);
                menuKnopGO.SetActive(true);
                restartKnopGO.SetActive(true);
                muteKnopGO.SetActive(true);
                achtergrondGO.SetActive(true);
                break;

            case false:
                unpaused = true;
                Time.timeScale = 1; //Hervat spel
                buttonText.text = "";
                clickableButton.transform.position = returnPosition;
                ResizeButton(82, 77);
                clickableButton.image.sprite = unpausedImage;
                levelSelectGO.SetActive(false);
                menuKnopGO.SetActive(false);
                restartKnopGO.SetActive(false);
                muteKnopGO.SetActive(false);
                achtergrondGO.SetActive(false);
                break;
        }
    }

    void ResizeButton(float x, float y)
    {
        clickableButton.GetComponent<RectTransform>().sizeDelta = new Vector2(x,y);
    }
}