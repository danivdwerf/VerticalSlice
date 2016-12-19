using UnityEngine;
using System.Collections;
//Take a chuck out of the level.\\
public class HandleExplosion : MonoBehaviour 
{
	//Create reference to the explosion audioclip.\\
	[SerializeField]private AudioClip explosionSound;
	//Create reference to the audioHandler script.\\
	private GameControllerPlayAudio audioHandler{get;set;}
	//Reference to the level.\\
	public static GroundController groundController{get;set;}
	//reference to the collider.\\
	private CircleCollider2D circle{get;set;}

	private void Start()
	{
		//If the Loading failed...\\
		if (!explosionSound)
		{
			//Throw error.\\
			Debug.LogError ("Explosion audioclip is null!");
			return;
		}
		//Set the reference.\\
		circle = GetComponent<CircleCollider2D> ();
		audioHandler = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<GameControllerPlayAudio> ();
	}
	//When the collider collides...\\
	void OnCollisionEnter2D(Collision2D other)
	{
		//And the collider has the tag "Ground".\\
		if(other.gameObject.CompareTag(Tags.ground))
		{
			//Destroy the ground...\\
			groundController.DestroyGround(circle);
			//Play the explosion sound.\\
			audioHandler.PlayAudio (explosionSound);
			//and this circle.\\
			Destroy(gameObject);
		}
	}
}
