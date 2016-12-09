	using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	private Animator anim;

    private bool sliding;
    private bool falling;

	private bool jump;
    private bool jumpCharge;
    private float jumpChargeDone;

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

    private Vector3 lastPosition;

	private void Start()
	{
		speed = 0f;
		rigid = GetComponent<Rigidbody2D> ();
		anim = GetComponent <Animator>();
        sliding = false;
        falling = false;
		jump = false;
        jumpCharge = false;
        lastPosition = transform.position;
    }

    private void FixedUpdate()
    {
        checkIfFalling();
        walk();
        checkIfJump();
        checkIfSliding();
        extraAnimations();

    }

    private void checkIfSliding()
    {
        if(distanceToGround() > 0.13f && distanceToGround() <= 0.16f && anim.GetBool("Falling") == false)
        {
            sliding = true;
            anim.SetBool("slide", true);
        }
        else if(anim.GetBool("slide") == true)
        {
            sliding = false;
            anim.SetBool("slide", false);
        }
    }

    private void checkIfFalling()
    {
        if (distanceToGround() <= 0.16f )//|| !moving())
        {
            falling = false;
            anim.SetBool("Falling", false);
        }
        else if (distanceToGround() > 0.2f && !jumpCharge )//&& moving())
        {
            falling = true;
            anim.SetBool("Falling", true);
        }
    }

    public void Jump(float js,float jh)
    {
        if (!jump && !falling)
        {
<<<<<<< HEAD
            jumpSpeed = js * transform.localScale.x;
            jumpHeight = jh;
            jumpCharge = true;
            anim.SetBool("Jump", true);
            AnimatorStateInfo state = anim.GetCurrentAnimatorStateInfo(0);
            jumpChargeDone = state.length + Time.time;          
=======
            jump = true;
            anim.SetBool("Jump", true);         
>>>>>>> a3e9cec6207fc7b684185d42ec5f7b60edb5cd2f
        }
    }

    private void checkIfJump()
    {
        if(jumpCharge && Time.time > jumpChargeDone)
        {
            anim.SetBool("Jump", false);
            transform.position += new Vector3(0, 0.1f,0);
            jumpCharge = false;
            jump = true;
        }

        if (jump)
        {
                if (distanceToGround() <= 0.14f )
                {
                    jump = false;
                }            

            rigid.velocity = new Vector2(jumpSpeed,jumpHeight );
            if(jumpSpeed < -0.3f || jumpSpeed > 0.3f)
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
        if(!jump && !jumpCharge)
        {
            rigid.velocity = new Vector2(speed, 0);

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
        if(anim.GetFloat("Walk") == 0 && !jump && !falling)
        {
            if(Random.Range(1,3000) == 9)
            {
                Debug.Log("eating apple");
                anim.SetBool("eatApple", true);                
            }
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("IdleApple"))
            {
                anim.SetBool("eatApple", false);
            }

        }
    }

    private bool moving()
    {
        if(lastPosition.x > transform.position.x -0.5f && lastPosition.y > transform.position.y - 0.5f && lastPosition.x < transform.position.x + 0.5f && lastPosition.y < transform.position.y + 0.5f)
        {
            lastPosition = transform.position;
            return false;
        }
        else
        {
            lastPosition = transform.position;
            return true;
        }        
    }
}
