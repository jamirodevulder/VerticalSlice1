using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : UIScript
{
    [SerializeField] public bool gameWon;
    [SerializeField] public bool gameLose;//Voor als het spel gewonnen is
    [SerializeField] public GameObject[] buttonGameObjects = new GameObject[8]; //Array van GameObjects, parents van knoppen
    [SerializeField] private bool unpaused; //unpaused true is dat het spel niet gepauzeerd is, false is gepauzeerd
    [SerializeField] private RectTransform buttonTransform;
    [SerializeField] private Sprite pausedImage; //Image voor de pauzeknop als het spel op pauze staat
    [SerializeField] private Sprite unpausedImage; //Image voor de pauzeknop als het spel niet op pauze staat
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private Text winscreentext;
    [SerializeField] private ScoreScript score;

    private void Awake()
    {
        buttonGameObjects[0] = GameObject.Find("LSBGameObject"); //Zoekt het GameObject, levelselectknop
        buttonGameObjects[1] = GameObject.Find("BackgroundGameObject"); //Achtergrond
        buttonGameObjects[2] = GameObject.Find("MBGameObject"); //Menuknop
        buttonGameObjects[3] = GameObject.Find("RBGameObject"); //Restartknop
        buttonGameObjects[4] = GameObject.Find("MuteButtonGameObject"); //Muteknop
        buttonGameObjects[5] = GameObject.Find("WSGameObject"); //Winscherm
        buttonGameObjects[6] = GameObject.Find("CBGameObject"); //Continueknop
        buttonGameObjects[5].SetActive(false);
        SetObjectState(false);
        //PauzeButton gerelateerde code
        clickableButton = GetComponent<Button>();
        mainCamera = FindObjectOfType<Camera>();
        clickableButton.onClick.AddListener(OnButtonClick);
        //AddListener(OnButtonClick); //Pakt de onClick function van de button
        buttonTransform = clickableButton.GetComponent<RectTransform>();
        buttonText = GetComponentInChildren<Text>();
        buttonText.text = "";
        //PauzeButton-positie gerelateerde code
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
        }
        if(gameWon)
        {
            buttonGameObjects[5].SetActive(true);

            this.gameObject.SetActive(false);
        }
        if(gameLose)
        {
            winscreentext.text = "Try Again";
            buttonGameObjects[5].SetActive(true);
            nextButton.SetActive(false);
            
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            float randomscore = Random.Range(29583, 100000);
            score.AddScore(randomscore);
            gameWon = true;

        }
    }

    private void OnButtonClick()
    {
        if (!gameWon)
        {
            switch (unpaused)
            {
                case true:
                    PauseGame(false, 0, pausedImage);
                    ResizeButton(70, 70);
                    clickableButton.transform.position = new Vector3(panel.transform.position.x, panel.transform.position.y, 0); //Z positie wordt anders -400
                    SetObjectState(true);
                    break;

                case false:
                    PauseGame(true, 1, unpausedImage);
                    ResizeButton(144, 134);
                    clickableButton.transform.position = returnPosition;
                    SetObjectState(false);
                    break;
            }
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