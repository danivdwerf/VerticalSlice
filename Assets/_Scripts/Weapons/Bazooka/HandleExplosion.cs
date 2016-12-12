using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif
//Take a chuck out of the level.\\
public class HandleExplosion : MonoBehaviour 
{
	//Create reference to the explosion audioclip.\\
	private AudioClip explosionSound{get;set;}
	//Create reference to the audioHandler script.\\
	private GameControllerPlayAudio audioHandler{get;set;}
	//Reference to the level.\\
	public static GroundController groundController{get;set;}
	//reference to the collider.\\
	private CircleCollider2D circle{get;set;}

	private void Start()
	{
		//Load the audioClip.\\
		explosionSound = (AudioClip)AssetDatabase.LoadAssetAtPath (Paths.explosion2Path,typeof(AudioClip));
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
			audioHandler.PlayAudio (explosionSound,false);
			//and this circle.\\
			Destroy(gameObject);
		}
	}
}
