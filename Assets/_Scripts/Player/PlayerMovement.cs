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
	private Rigidbody2D rigid;

	private void Start()
	{
		speed = 0f;
		rigid = GetComponent<Rigidbody2D> ();
		anim = GetComponent <Animator>();
		jump = false;
	}

	private void Update()
	{
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down,0.5f); 
		if (hit.collider)
		{
			if (hit.collider.tag == Tags.ground)
			{
				if (hit.distance < 0.4f)
				{
					jump = false;
					anim.SetBool ("Falling", false);
				} 
			}
		}
		else
		{
			if (!jump)
			{
				anim.SetBool ("Falling", true);
			}
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

	private void FixedUpdate()
	{
		rigid.velocity = new Vector2 (speed, 0);
		anim.SetFloat ("Walk", Mathf.Abs (rigid.velocity.x));
		if (rigid.velocity.x > 0 && transform.localScale.x < 0)
		{
			transform.localScale = new Vector3 (1,1,1);
		}
		else if(rigid.velocity.x <0&& transform.localScale.x>0)
		{
			transform.localScale = new Vector3 (-1,1,1);
		}
	}
}
