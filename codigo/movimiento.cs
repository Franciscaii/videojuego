using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
   
    public float runSpeed=1;
    public float jumSpeed= 0.01f;
    Rigidbody2D rb2D;

    public bool betterJump = false;

    public float fallMultiplier = 0.5f;

    public float lowJumpMultiplier = 1f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if( Input.GetKey("d")|| Input.GetKey("right")){
            rb2D.velocity= new Vector2(runSpeed,rb2D.velocity.y);
        }
        else if( Input.GetKey("a")|| Input.GetKey("left")){
            rb2D.velocity= new Vector2(-runSpeed,rb2D.velocity.y);
        }
        else{
            rb2D.velocity= new Vector2(0,rb2D.velocity.y);
        }
        if(Input.GetKey("space") && check.isGrounded){
            rb2D.velocity=new Vector2(rb2D.velocity.x,jumSpeed);
        }

        if(betterJump){
            if(rb2D.velocity.y<0){
                rb2D.velocity += Vector2.up*Physics2D.gravity.y*(fallMultiplier)* Time.deltaTime;
            }
            if(rb2D.velocity.y>0 && !Input.GetKey("space")){
                rb2D.velocity += Vector2.up*Physics2D.gravity.y*(lowJumpMultiplier)* Time.deltaTime;

            }
        }
    }
}
