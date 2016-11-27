using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour 
{
	public static GroundController groundController;
	private CircleCollider2D circle;
	private void Start()
	{
		circle = GetComponent<CircleCollider2D> ();
	}
	void OnCollisionEnter2D( Collision2D coll )
	{
		if( coll.collider.tag == "Ground" )
		{
			groundController.DestroyGround(circle);
			Destroy(gameObject);
		}
	}
}
