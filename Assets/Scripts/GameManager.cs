using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton <GameManager>
{
     
    public Text scoreText;
    public int scoreIncrement = 0;
    public int score;
    public List<GameObject> health;
    public bool isCollectedAllDiamonds = false;
    public void IncrementScore()
    { 
        score += scoreIncrement;
        scoreText.text = "SCORE: " + score;
    } 
     
}
