using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScoreScript : MonoBehaviour
{
    private float score;
    private Text scoreText;
    private Text highScoreText;
    private string highScoreString;
    private string path;
    [SerializeField] private float highScore;
    [SerializeField] private StreamWriter write;
    [SerializeField] private StreamReader read;
    [SerializeField] private GameObject enemyt;

    private void Awake()
    {
        path = "Assets/Scenes/Highscore.txt";
        enemyt = GameObject.Find("Enemy");
        score = 0;
        scoreText = GetComponent<Text>();
        highScoreText = GetComponent<Text>();
        scoreText.text = "Score: " + score;
        read = new StreamReader(path, false);
        while (!read.EndOfStream)
        {
            highScoreString = read.ReadLine();
            highScore = float.Parse(highScoreString);
            highScoreText.text = "Highscore: " + highScore;
        }
        read.Close();
        write = new StreamWriter(path, false);
        UpdateHighScore(highScore);
    }


    public void AddScore(float tempScore) //Voegt specifieke score toe, wanneer hoger dan score word de highscore geüpdatet
    {
        score += tempScore;
        scoreText.text = "Score: " + score;
        if(score > highScore)
        {
            highScore = score;
            UpdateHighScore(highScore);
        }
    }

    public void UpdateHighScore(float tempScore) //Update de highscore
    {
        highScore = tempScore;
        highScoreText.text = "Highscore: " + highScore;
        write.WriteLine(tempScore.ToString());
        write.Close();
    }
}
