using UnityEngine;
using System.Collections;
//Take a chuck out of the level.\\
public class HandleExplosion : MonoBehaviour 
{
	//Reference to the level.\\
	public static GroundController groundController{get;set;}
	//reference to the collider.\\
	private CircleCollider2D circle{get;set;}

	private void Start()
	{
		//Set the reference.\\
		circle = GetComponent<CircleCollider2D> ();
		GameObject curPlayer = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<CurrentPlayer> ().currentSelectedPlayer();
		RaycastHit2D hit = Physics2D.Raycast(this.transform.position,curPlayer.transform.position);
		if (hit)
		{
			if (hit.distance <= 0.2f)
			{
				curPlayer.GetComponent<Rigidbody2D> ().AddForce (transform.right*10,ForceMode2D.Impulse);
			}
			if (hit.distance <= 0.5f)
			{
				int damage = (int)Mathf.Round (hit.distance * 250);
				Debug.Log (damage);
				//damage
			}
		}
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
