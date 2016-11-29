using UnityEngine;
using System.Collections;
using UnityEditor;

public class ProjectileCollision : MonoBehaviour 
{
	private AudioClip explosionSound;
	private GameControllerPlayAudio audioHandler;
	private CreateLevelDestroyer levelDestroyer;

	private void Start()
	{
		levelDestroyer = GetComponent<CreateLevelDestroyer> ();
		string audioPath = "Assets/Audio/Effects/Explosion3.wav";
		explosionSound = (AudioClip)AssetDatabase.LoadAssetAtPath (audioPath,typeof(AudioClip));
		if (!explosionSound)
		{
			Debug.LogError ("Explosion audioclip is null!");
			return;
		}
		audioHandler = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<GameControllerPlayAudio> ();
	}
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag (Tags.ground))
		{
			levelDestroyer.groundHit ();
			audioHandler.PlayAudio (explosionSound,false);
		}
	}
}
