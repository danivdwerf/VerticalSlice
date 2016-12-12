using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour 
{
	private int speed{ get; set; }
	private Rigidbody2D rigid{ get; set; }
	private void Start()
	{
		speed = 2;
		rigid = GetComponent<Rigidbody2D>();
	}
	private void Update()
	{
		if (Input.GetKey (KeyCode.RightArrow))
		{
			this.rigid.velocity = new Vector2 (0.8f,this.rigid.velocity.y);
		}
		if (Input.GetKey (KeyCode.LeftArrow))
		{
			this.rigid.velocity = new Vector2 (-0.8f,this.rigid.velocity.y);
		}
		if (Input.GetKeyDown (KeyCode.UpArrow))
		{
			this.rigid.velocity = new Vector2 (1,3f);
		}
	}
	private void move()
	{
		
	}
}
