using UnityEngine;
using System.Collections;
using UnityEditor;

public class ProjectileCollision : MonoBehaviour 
{
	[SerializeField]private GameObject circle;
	private AudioClip explosionSound;
	private GameControllerAudioHandle audioHandler;

	private void Start()
	{
		string audioPath = "Assets/Audio/Effects/Explosion3.wav";
		explosionSound = (AudioClip)AssetDatabase.LoadAssetAtPath (audioPath,typeof(AudioClip));
		if (!explosionSound)
		{
			Debug.LogError ("Explosion audioclip is null");
		}
		audioHandler = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<GameControllerAudioHandle> ();
	}
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
		audioHandler.PlayAudio (explosionSound,false);
		Destroy(gameObject);
	}
}
