using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserMovement : MonoBehaviour
{
    Rigidbody2D Lrb;
    [SerializeField] int Lspeed;
    void OnEnable()
    {
        Lrb = GetComponent<Rigidbody2D>();
        Lrb.velocity = new Vector2(0, -1) * Lspeed;
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

        if (collision.CompareTag("Player"))
        {
            GameManager.instance.takeDamage();
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }
}
