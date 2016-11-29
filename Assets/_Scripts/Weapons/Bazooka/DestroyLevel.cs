using UnityEngine;
using System.Collections;
//Take a chuck out of the level.\\
public class DestroyLevel : MonoBehaviour 
{
	//Reference to the level.\\
	public static GroundController groundController{get;set;}
	//reference to the collider.\\
	private CircleCollider2D circle{get;set;}
	private void Start()
	{
		//Set the reference.\\
		circle = GetComponent<CircleCollider2D> ();
	}
	//When the collider collides...\\
	void OnCollisionEnter2D( Collision2D coll )
	{
		//And the collider has the tag "Ground".\\
		if( coll.gameObject.CompareTag(Tags.ground))
		{
			//Destroy the ground...\\
			groundController.DestroyGround(circle);
			//and this circle.\\
			Destroy(gameObject);
		}
	}
}
