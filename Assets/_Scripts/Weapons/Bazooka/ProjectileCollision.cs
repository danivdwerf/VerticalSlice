using UnityEngine;
using System.Collections;

public class ProjectileCollision : MonoBehaviour 
{
	[SerializeField]private GameObject circle;
	private static GroundController groundController; 
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag (Tags.ground))
		{
			groundHit ();
		}
	}

	private void groundHit()
	{
		GameObject destroyGround = Instantiate (circle,this.transform.position,Quaternion.identity)as GameObject;
		Destroy(gameObject);
	}
}
