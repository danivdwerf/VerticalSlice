using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour 
{
	private float speed;
	private Rigidbody2D rigid;
	private void Start()
	{
		rigid = GetComponent<Rigidbody2D> ();
		speed = 20f;
	}
	private void Update()
	{
		rigid.AddForce (transform.right * speed*Time.deltaTime);
	}
}
