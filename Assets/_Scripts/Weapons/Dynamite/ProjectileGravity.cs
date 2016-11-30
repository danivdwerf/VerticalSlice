using UnityEngine;
using System.Collections;

public class ProjectileGravity : MonoBehaviour 
{
	private float gravity;
	private Rigidbody2D rigid;
	private void Start()
	{
		rigid = GetComponent<Rigidbody2D> ();
		gravity = 800f;
	}

	private void Update()
	{
		rigid.AddForce (-transform.up*gravity*Time.deltaTime);
		if (gravity < 900)
		{
			gravity++;
		}
	}
}
