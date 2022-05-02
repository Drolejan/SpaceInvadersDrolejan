using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int score;
    int playerHealth;
    public Text scoreText;
    public Text healthText;
    public Text finalScoreText;
    public GameObject[] gameScreens;
    int levelLayout;
    public GameObject swarm1;
    public GameObject swarm2;
    public bool playerActive;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        ResetScore();
        playerActive = false;
    }

    void Update()
    {
        if (gameScreens[1].activeSelf)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    public void UpdateScore(int enemyValue)
    {
        score += enemyValue;
        scoreText.text = "SCORE:" + score;
    }

    public void takeDamage()
    {
        playerHealth--;
        healthText.text = "HEALTH:" + playerHealth;
        if (playerHealth < 1)
        {
            gameOver();
        }
    }

    public void gameOver()
    {
        ChangeScreens(2);
    }

    public void ResetScore()
    {
        score = 0;
        playerHealth = 3;
        scoreText.text = "SCORE:" + score;
        healthText.text = "HEALTH:" + playerHealth;
    }

    public void selectLayout(int level)
    {
        levelLayout = level;
    }

    public void ChangeScreens(int screen)
    {
        foreach (GameObject item in gameScreens)
        {
            item.SetActive(false);
        }
        gameScreens[screen].SetActive(true);
        if (screen == 1)
        {
            playerActive = true;
            switch (levelLayout)
            {
                case 1:
                    swarm1.SetActive(true);
                    break;
                case 2:
                    swarm2.SetActive(true);
                    break;
                default:
                    print("That level does not exist... yet");
                    break;
            }
        }
        else if (screen == 2)
        {
            finalScoreText.text = "Final Score:" + score;
            swarm1.SetActive(false);
            swarm2.SetActive(false);
            playerActive = false;
            ObjectPooler.SharedInstance.ResetPool();
        }
    }
}
