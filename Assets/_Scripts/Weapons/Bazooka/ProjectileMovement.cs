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
		speed = 4f;

		rigid.AddForce (transform.right * speed * time, ForceMode2D.Impulse);
	}
}
