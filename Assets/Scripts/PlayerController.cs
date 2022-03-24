using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public int playerJumpForce;
    float inputX, inputY;
    public int playerSpeed;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer render;
    void Start()
    {
      rb=GetComponent<Rigidbody2D>();
        render=GetComponent<SpriteRenderer>();
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetTrigger("isIdle");
        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetTrigger("isJumping");
            rb.AddForce(Vector2.up * playerJumpForce);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            anim.SetTrigger("isAttacking");
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            anim.SetTrigger("isSliding");
        }
            inputX = Input.GetAxis("Horizontal");
       rb.velocity=new Vector2 (inputX*playerSpeed*Time.deltaTime,rb.velocity.y);
        if(inputX>0||inputX<0)
        {
            anim.SetTrigger("isRunning");
        }
        if(inputX>0)
        {
            render.flipX = false;
        }
        if(inputX<0)
        {
            render.flipX=true;
        }
    }
}
