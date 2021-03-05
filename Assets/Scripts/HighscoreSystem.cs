using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreSystem : MonoBehaviour
{
    private int currentScore;
    public Text scoreText;

    void Start()
    {
        currentScore = 0;
    }

    void Update()
    {
        GameObject[] snakeParts = GameObject.FindGameObjectsWithTag("Snake");
        currentScore = snakeParts.Length;
        scoreText.text = "Score: \n" + currentScore;
    }
}
