using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreScript : MonoBehaviour
{
    private float score;
    private string highScoreString;
    private string path;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highScoreText;
    [SerializeField] private float highScore;
    [SerializeField] private StreamWriter write;
    [SerializeField] private StreamReader read;
    [SerializeField] private GameObject enemy;

    private void Awake()
    {
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
