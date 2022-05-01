using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    int score;
    public Text scoreText;
    public GameObject[] gameScreens;
    int levelLayout;
    public GameObject swarm1;
    public GameObject swarm2;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        score = 0;
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

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "SCORE:" + score;
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
    }
}
