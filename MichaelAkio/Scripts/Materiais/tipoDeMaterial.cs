using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tipoDeMaterial : MonoBehaviour
{
    private const double V = 0.8;
    public float upSpeed;
    Rigidbody2D rb;
    public Transform groundcheck;
    bool isGrounded;
    public bool radius;
    public LayerMask groundlayer;
    public float jumpforce;
    public float speedH = 1.0;

    void Start()
    {

    }

    // Update is called once per frame

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, radius, groundlayer);
    }
    void OnCollisionEnter2D(Collision2D Collision)
    {
        if (Collision.gameObject.tag == "marsh" && isGrounded == false)
        {
            upSpeed += 300f;

            if (upspeed >= 1400f)
            {
                upSpeed = 1400f;
            }
            rb.AddForce(new Vector2(0, upSpeed));
        }

        if (Collision.gameObject.tag == "slime")
        {
            speedH = speedH*0.8;
        }
        else
        {
            speedH = 1.0;
        }

        if (Collision.gameObject.tag == "gelo")
        {
            
        }
        else
        {
           
        }

        if (Collision.gameObject.tag == "agua") 
        {
            
        }


    }

    
}
