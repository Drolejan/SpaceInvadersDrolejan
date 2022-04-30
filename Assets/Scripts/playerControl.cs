using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    Rigidbody2D rb;
    float inputH;
    [SerializeField] int speed;
    public GameObject bullet;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        inputH = Input.GetAxis("Horizontal");
        Shoot();
    }

    void FixedUpdate()
    {
        Movement();
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }

    void Movement()
    {
        rb.velocity = new Vector2(inputH*speed, rb.velocity.y);
    }
}
