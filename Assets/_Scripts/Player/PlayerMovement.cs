﻿using UnityEngine;
using System.Collections;
using UnityEditor;

public class PlayerMovement : MonoBehaviour
{
    private Animator anim;

    private GameControllerPlayAudio playAudio;

    private AudioClip jumpClip;
    private AudioClip landClip;
    private AudioClip appleClip;

    private PlayerState state = PlayerState.idle;
    private bool sliding;
    private bool falling;

    private bool jump;
    private bool jumpCharge;
    private float timeTojumpCharge;
    private float timeToStandUp;

    private float speed;
    public float SetSpeed
    {
        set
        {
            speed = value;
        }
    }

    private float jumpSpeed = 8;
    private float jumpHeight = 4;

    private Rigidbody2D rigid;

    private void Start()
    {
        playAudio = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<GameControllerPlayAudio>();

        jumpClip = (AudioClip)AssetDatabase.LoadAssetAtPath(Paths.jumpAudio, typeof(AudioClip));
        landClip = (AudioClip)AssetDatabase.LoadAssetAtPath(Paths.landAudio, typeof(AudioClip));
        appleClip = (AudioClip)AssetDatabase.LoadAssetAtPath(Paths.appleAudio, typeof(AudioClip));

        speed = 0f;
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sliding = false;
        falling = false;
        jump = false;
        jumpCharge = false;
    }

    private void FixedUpdate()
    {
        checkIfFalling();
        walk();
        checkIfJump();
        checkIfSliding();
        extraAnimations();
        checkIfStandingUp();
    }

    private void checkIfSliding()
    {
        if (distanceToGround() > 0.085f && distanceToGround() <= 0.18f && state != PlayerState.falling)
        {
            state = PlayerState.sliding;
            anim.SetBool("slide", true);
        }
        else if (anim.GetBool("slide") == true)
        {            
            anim.SetBool("slide", false);
            state = PlayerState.standingUp;
        }
    }

    private void checkIfFalling()
    {
        if (distanceToGround() <= 0.08f && anim.GetBool("Falling") == true)
        {
            playAudio.PlayAudio(landClip);
            anim.SetBool("Falling", false);
            state = PlayerState.standingUp;
        }
        else if (distanceToGround() > 0.18f && !jumpCharge)
        {
            state = PlayerState.falling;           
            anim.SetBool("Falling", true);
        }
        if(gameObject.transform.position.y < -3.5)
        {
            gameObject.transform.position = new Vector3((Random.value * 8.5f)-4 ,4f,0);
        }
       
    }

    private void checkIfStandingUp()
    {
        if(state == PlayerState.standingUp && state != PlayerState.idle && Time.time > timeToStandUp + 0.2f )
        {
            AnimatorStateInfo animationState = anim.GetCurrentAnimatorStateInfo(0);
            timeToStandUp = animationState.length + Time.time;
        }
        if(state == PlayerState.standingUp && state != PlayerState.idle && Time.time > timeToStandUp)
        {
            state = PlayerState.idle;
        }
    }

    public void Jump(float js, float jh)
    {
        if (!jumpCharge && !jump && state == PlayerState.idle)
        {          
            jumpSpeed = js * transform.localScale.x;
            jumpHeight = jh;
            jumpCharge = true;
            anim.SetBool("Jump", true);         
        }
        
    }

    private void checkIfJump()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump") && jumpCharge && Time.time > timeTojumpCharge + 0.5f)
        {
            
            AnimatorStateInfo animationState = anim.GetCurrentAnimatorStateInfo(0);
            timeTojumpCharge = (animationState.length + Time.time) - 0.1f;
        }
        if (jumpCharge && Time.time > timeTojumpCharge)
        {
            playAudio.PlayAudio(jumpClip);
            anim.SetBool("Jump", false);
            transform.position += new Vector3(0, 0.1f, 0);
            jumpCharge = false;
            jump = true;
        }

        if (jump)
        {
            if (distanceToGround() <= 0.11f)
            {
                jump = false;
            }

            rigid.velocity = new Vector2(jumpSpeed, jumpHeight);
            if (Mathf.Abs(jumpSpeed) > 0.3f)
            {
                jumpSpeed -= 0.2f * transform.localScale.x;
            }
            else
            {
                jumpSpeed = 0.3f * transform.localScale.x;
            }

            if (jumpHeight > 0)
            {
                jumpHeight -= 0.2f;
            }
            else
            {
                jumpHeight = 0;
            }

        }
    }

    private void walk()
    {
        if (!jump && !jumpCharge && state == PlayerState.idle)
        {
            rigid.velocity = new Vector2(speed, 0);
        }
        else
        {
            rigid.velocity = new Vector2(0, 0);
        }

        anim.SetFloat("Walk", Mathf.Abs(rigid.velocity.x));

        if (rigid.velocity.x > 0 && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (rigid.velocity.x < 0 && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }



    }

    private float distanceToGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 100);
        if (hit.collider)
        {
            if (hit.collider.tag == Tags.ground)
            {
                return hit.distance;
            }
        }
        return 100f;
    }

    private void extraAnimations()
    {
        if (anim.GetFloat("Walk") == 0 && state == PlayerState.idle)
        {
            if (Random.Range(1, 3000) == 9)
            {
                playAudio.PlayAudio(appleClip);
                anim.SetBool("eatApple", true);
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("IdleApple"))
            {
                anim.SetBool("eatApple", false);
            }

        }
    }

}

public enum PlayerState
{
    falling,
    sliding,
    idle,
    standingUp
}
