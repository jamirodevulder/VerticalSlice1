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
    [SerializeField] private GameObject higscorePlace;
    [SerializeField] private GameObject scorePlace;

    public bool allPigsDown = true;

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
        //maakt een streamwriter aan
        UpdateHighScore(highScore);
    }


    private void Update()
    {
        if (pauseScript.gameWon || pauseScript.gameLose)
        {
            Time.timeScale = 0;
            scoreText.transform.position = scorePlace.transform.position;
            scoreText.text = "Score:" + "\n" + score;

            highScoreText.transform.position = higscorePlace.transform.position;
            highScoreText.text = "Highscore:" + "\n" + highScore;
            //29583 voor 1 ster, 59166 voor 2 sterren en 88749 voor 3 sterren
            if (highScore >= 29583 && highScore < 59166 && allPigsDown)
            {

            }
            else if (highScore >= 59166 && highScore < 88749)
            {

            }
            else if (highScore >= 88749)
            {

            }
            UpdateHighScore(highScore);
        }
    }
    public void AddScore(float tempScore) //Voegt specifieke score toe, wanneer hoger dan score word de highscore geüpdatet
    {
        score += tempScore;
        int realscore = Mathf.RoundToInt(score);
        scoreText.text = "Score: " + realscore;
        if(score > highScore)
        {
            highScore = score;
            int realhighscore = Mathf.RoundToInt(highScore);
            highScoreText.text = "Highscore: " + realhighscore;
        }
    }

    public void UpdateHighScore(float tempScore) //Updatet de highscore, gebruik dit wanneer het hele spel afgelopen is
    {
        int realhighscore = Mathf.RoundToInt(highScore);
        highScore = realhighscore;
        write = new StreamWriter(path, false);
        write.WriteLine(tempScore.ToString());
        write.Close();
    }
}
