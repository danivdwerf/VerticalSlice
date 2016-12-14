using UnityEngine;
using System.Collections;
using UnityEditor;
//Check the projectile Collision.\\
public class ProjectileCollision : MonoBehaviour 
{
	//Create reference to the leveldestroyer Script.\\
	private CreateLevelDestroyer levelDestroyer{get;set;}

	private ExplosionUI ui{ get; set;}

    private EndTurn endTurn;

    private void Start()
	{
		//Set references to the scripts.\\
		levelDestroyer = GetComponent<CreateLevelDestroyer> ();
		ui = GetComponent<ExplosionUI> ();
        endTurn = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<EndTurn>();
    }
	//If the projectile collides with something...\\
	private void OnTriggerEnter2D(Collider2D other)
	{
        endTurn.Ass();
        //If the object is the ground.\\
        if (other.gameObject.CompareTag (Tags.ground))
		{
			//Let the levelDestroyer do it's stuff.\\
			levelDestroyer.groundHit ();

			ui.createExplosion (transform);
		}
	}
}
