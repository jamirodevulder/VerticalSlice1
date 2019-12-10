using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreScript : UIScript
{
    private float score;
    private float highScore;
    private string highScoreString;
    private string path;
    [SerializeField] private PauseButton pauseScript;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private StreamWriter write;
    [SerializeField] private StreamReader read;
    [SerializeField] private GameObject enemy;

    private void Awake()
    {
        mainCamera = FindObjectOfType<Camera>();
        path = "Assets/Scenes/Highscore.txt"; //locatie van het highscore.txt bestand
        enemy = GameObject.Find("Enemy");
        score = 0;
        scoreText.text = "Score: " + score;
        read = new StreamReader(path, false);
        while (!read.EndOfStream) //Leest het highscore.txt bestand
        {
            highScoreString = read.ReadLine(); //leest het bestand
            highScore = float.Parse(highScoreString); //zet string om in een float
            highScoreText.text = "Highscore: " + highScore;
        }
        read.Close(); //Stopt met lezen
        write = new StreamWriter(path, false); //maakt een streamwriter aan
        UpdateHighScore(highScore);
    }


    private void Update()
    {
        if (pauseScript.gameWon)
        {
            scoreText.transform.position = new Vector3(mainCamera.transform.position.x - 0.2f, mainCamera.transform.position.y - 0.8f, 0);
            scoreText.text = "Score:" + "\n" + score;

            highScoreText.transform.position = new Vector3(mainCamera.transform.position.x + 2f, mainCamera.transform.position.y + 2f, 0);
            highScoreText.text = "Highscore:" + "\n" + highScore;
            //29583 voor 1 ster, 59166 voor 2 sterren en 88749 voor 3 sterren
            if (highScore >= 29583 && highScore < 59166)
            {

            }
            else if (highScore >= 59166 && highScore < 88749)
            {

            }
            else if (highScore >= 88749)
            {

            }

        }
    }
    public void AddScore(float tempScore) //Voegt specifieke score toe, wanneer hoger dan score word de highscore geüpdatet
    {
        score += tempScore;
        scoreText.text = "Score: " + score;
        if(score > highScore)
        {
            highScore = score;
            highScoreText.text = "Highscore: " + highScore;
        }
    }

    public void UpdateHighScore(float tempScore) //Updatet de highscore, gebruik dit wanneer het hele spel afgelopen is
    {
        highScore = tempScore;
        write.WriteLine(tempScore.ToString());
        write.Close();
    }
}
