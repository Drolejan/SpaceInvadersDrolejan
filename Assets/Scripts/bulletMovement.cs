using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    Rigidbody2D Brb;
    [SerializeField] int Bspeed;
    void Start()
    {
        Brb=GetComponent<Rigidbody2D>();
        Brb.velocity = new Vector2(0, 1)*Bspeed;
    }

    void Update()
    {
        
    }
}
