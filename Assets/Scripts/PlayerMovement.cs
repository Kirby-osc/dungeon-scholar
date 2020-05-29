using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    public bool isMoving=false;
    [Header("Set in Inspector")]
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        anim = this.gameObject.GetComponent<Animator>();
        sr = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        LogicMovement();
    }

    void LogicMovement()
    {
        
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");
        if (movementHorizontal!=0||movementVertical!=0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        if (movementHorizontal<=0)
        {
            this.transform.eulerAngles=new Vector3(0,180);
        }
        else
        {
            if (movementHorizontal>=0)
            {
                this.transform.eulerAngles=new Vector3(0,0); 
            }
        }
        anim.SetBool("playerIsMoving",isMoving);
        Vector2 movement=new Vector2(movementHorizontal,movementVertical);
        rb.MovePosition(rb.position+movement * (speed * Time.fixedDeltaTime));    
       
    }
}
