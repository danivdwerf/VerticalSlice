using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerGravity : MonoBehaviour 
{
	private Rigidbody2D rigid;
	private float gravity;
	private void Start()
	{
		rigid = GetComponent<Rigidbody2D> ();
		gravity = 300000f;
	}
	private void Update()
	{
		rigid.AddForce (-transform.up*gravity*Time.deltaTime);
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag (Tags.ground))
		{
			gravity = 5000f;
		} 
	}
	private void OnCollisionExit2D(Collision2D other)
	{
		gravity = 300000f;
	}
}
