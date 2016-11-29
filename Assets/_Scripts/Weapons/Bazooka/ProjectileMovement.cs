using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour 
{
	private float speed;
	private float gravity;
	private float time;
	public float Settime
	{
		set 
		{ 
			time = value;
		}
	}
	private Rigidbody2D rigid;
	private void Start()
	{
		rigid = GetComponent<Rigidbody2D> ();
		speed = 100f;
	}
	private void Update()
	{
		rigid.velocity = transform.right * speed * time *Time.deltaTime;
	}
}
