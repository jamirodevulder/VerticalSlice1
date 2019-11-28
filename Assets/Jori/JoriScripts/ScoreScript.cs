using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    private float score;
    private Text scoreText;
    [SerializeField] private GameObject enemyt;

    private void Awake()
    {
        enemyt = GameObject.Find("Enemy");
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = "Score: " + score;
    }


    public void AddScore(float tempScore)
    {
        score += tempScore;
        scoreText.text = "Score: " + score;
    }
}
