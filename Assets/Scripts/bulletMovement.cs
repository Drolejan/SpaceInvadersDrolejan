using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    Rigidbody2D Brb;
    [SerializeField] int Bspeed;
    void OnEnable()
    {
        Brb=GetComponent<Rigidbody2D>();
        Brb.velocity = new Vector2(0, 1)*Bspeed;
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bounds"))
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }

        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<enemyBehaviour>().TakeDamage();
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
