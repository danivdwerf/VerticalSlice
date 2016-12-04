	using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	private Animator anim;

	private bool jump;

	private float speed;
	public float SetSpeed
	{
		set
		{
			speed = value;
		}
	}
	private float jumpSpeed;
    public float SetJumpSpeed
    {
        set
        {
            jumpSpeed = value;
        }
    }

	private Rigidbody2D rigid;

	private void Start()
	{
		speed = 0f;
		rigid = GetComponent<Rigidbody2D> ();
		anim = GetComponent <Animator>();
		jump = false;
	}

    private void FixedUpdate()
    {
        checkIfFalling();
        walk();
        checkIfJump();
    }

    private void checkIfFalling()
    {
        if (distanceToGround() <= 0.12f)
        {
            anim.SetBool("Falling", false);
        }
        else if (distanceToGround() > 1)
        {
            anim.SetBool("Falling", true);
        }
    }

    private void checkIfJump()
    {
        if (distanceToGround() <= 0.12f && jump)
        {
            jump = false;
        }       

    }

    private void walk()
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

	public void Jump()
	{
		if (!jump)
		{
            rigid.AddForce (Vector3.up * 3000000 * Time.deltaTime);
            jump = true;
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
	
}
