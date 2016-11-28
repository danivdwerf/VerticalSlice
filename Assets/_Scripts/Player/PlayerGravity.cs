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
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down,0.5f); 
		if (hit.collider)
		{
			if (hit.collider.tag == Tags.ground)
			{
				if (hit.distance < 0.1f)
				{
					gravity = 5000f;
				} 
				else
				{
					gravity = 200000f;
				}
			}
		}
		rigid.AddForce (-transform.up*gravity*Time.deltaTime);
	}
}
