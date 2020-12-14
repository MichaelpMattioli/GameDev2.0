using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController2D controller2D;
    // Start is called before the first frame update
    float ParaOLado = 0f;
    float velo = 20f;
    bool pular = false;
    bool crouch = false;
    float fSpeed = 1f, fMaxSpeed = 10.0f;
    bool moveW = false, moveA = false, moveS = false, moveD = false;
    Vector2 movement, movementOrder;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ParaOLado = Input.GetAxisRaw("Horizontal") * velo ;
        if (Input.GetKeyDown(KeyCode.W))
        {
            pular = true;
        }
        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        viewKeysMoviments();
        
    }

    private void viewKeysMoviments()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveA = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            moveD = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            moveS = true;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveW = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            moveA = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            moveD = false;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            moveS = false;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            moveW = false;
        }
    }

    private void FixedUpdate()
    {

        controller2D.Move(ParaOLado * Time.fixedDeltaTime, crouch, pular);
        pular = false;
    }

    public void gelo()
    {
        if (moveD && !moveA)
        {
            movementOrder.x = fMaxSpeed;
        }

        else if (moveA && !moveD)
        {
            movementOrder.x = -fMaxSpeed;
        }

        else if (moveA && moveD)
        {
            movementOrder.x = 0;
        }
        //ORder
        if (moveA && movement.x > movementOrder.x)
        {
            movement.x -= fSpeed  * Time.fixedDeltaTime;
        }
        if (moveD && movement.x < movementOrder.x)
        {
            movement.x += fSpeed  * Time.fixedDeltaTime;
        }

        //att a posic
        gameObject.transform.position = gameObject.transform.position + (Vector3)movement * fSpeed  * Time.fixedDeltaTime;

    }
}
