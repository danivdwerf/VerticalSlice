using UnityEngine;
using System.Collections;

// Classe responsável pelo código que controla a nossa bala
public class BulletController : MonoBehaviour 
{
	public CircleCollider2D destructionCircle;
	public static GroundController groundController;

	void OnCollisionEnter2D( Collision2D coll )
	{
		if( coll.collider.tag == "Ground" )
		{
			groundController.DestroyGround( destructionCircle );
			//Destroy(gameObject);
		}
	}
}
