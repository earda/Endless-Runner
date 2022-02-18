using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public Rigidbody player;
    public GameObject StartPanel;
    public GameObject InGame;
    public GameObject LevelFail;
    public GameObject FinishPanel;
    public Text menuLevelText;
    public static int levelCount = 0;
    public Text levelText;
    public Text score;
    private void Start()
    {
        GameLevel(1);
        PlayerMovement.Instance.speed = 0;
        PlayerMovement.Instance.animator.SetFloat("run",0);
    }
    public void StartGame()
    {
        PlayerMovement.Instance.animator.SetFloat("run", 1f);
        PlayerMovement.Instance.speed =5;
        StartPanel.SetActive(false);
        InGame.SetActive(true); 
    }
    public void FinishLevel()
    {
        StartPanel.SetActive(false);
        InGame.SetActive(true);
        LevelFail.SetActive(false);
        FinishPanel.SetActive(true);
        score.text ="SCORE : " + GameManager.Instance.score;
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Levelfail()
    {
        InGame.SetActive(false);
        LevelFail.SetActive(true); 
         
    }
    public void RestartGame()
    {
        levelCount--;
        menuLevelText.text = (levelText.text);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void GameLevel(int level)
    {
        levelCount += level;
        levelText.text = ("LEVEL " + (levelCount).ToString());
        menuLevelText.text = (levelText.text);
    }
    private void OnApplicationQuit()
    {
        levelCount = 0;
    }
}
