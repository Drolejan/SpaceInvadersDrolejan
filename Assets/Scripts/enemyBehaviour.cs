using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBehaviour : MonoBehaviour
{
    [SerializeField] int maxHealth;
    [SerializeField] int value;
    int health;
    GameObject swarm;

    void OnEnable()
    {
        health = maxHealth;
        swarm = GameObject.FindGameObjectWithTag("Swarm");
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    

    public void TakeDamage()
    {
        health--;
        if (health < 1)
        {
            GameManager.instance.UpdateScore(value);
            if (swarm.GetComponentsInChildren<enemyBehaviour>().GetLength(0) < 2)
            {
                GameManager.instance.ChangeScreens(2);
                swarm.gameObject.SetActive(false);
            }
            gameObject.SetActive(false);
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.instance.gameOver();
        }
    }

}
