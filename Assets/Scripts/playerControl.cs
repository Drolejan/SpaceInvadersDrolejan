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
        if (Input.GetButtonDown("Fire1")&&GameManager.instance.playerActive)
        {
            //Instantiate(bullet, transform.position, transform.rotation);
            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("Player Bullet");
            if (bullet != null)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation;
                bullet.SetActive(true);
            }
        }
    }

    void Movement()
    {
        rb.velocity = new Vector2(inputH*speed, rb.velocity.y);
        var pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp(pos.x, 0.05f, 0.95f);
        transform.position = Camera.main.ViewportToWorldPoint(pos);
    }
}
