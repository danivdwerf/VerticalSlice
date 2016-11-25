using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{
	private Animator anim;
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
	}

	public void Jump()
	{
		rigid.AddForce(Vector3.up*1000000*Time.deltaTime);
	}

	private void FixedUpdate()
	{
		rigid.velocity = new Vector2 (speed, 0);
		anim.SetFloat ("Walk", Mathf.Abs (rigid.velocity.x));
		if (rigid.velocity.x > 0 && transform.localScale.x < 0)
		{
			transform.localScale = new Vector3 (20,20,1);
		}
		else if(rigid.velocity.x <0&& transform.localScale.x>0)
		{
			transform.localScale = new Vector3 (-20,20,1);
		}
	}
}
