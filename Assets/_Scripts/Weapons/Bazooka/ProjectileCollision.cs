﻿using UnityEngine;
using System.Collections;
using UnityEditor;
//Check the projectile Collision.\\
public class ProjectileCollision : MonoBehaviour 
{
	//Create reference to the explosion audioclip.\\
	private AudioClip explosionSound{get;set;}
	//Create reference to the leveldestroyer Script.\\
	private CreateLevelDestroyer levelDestroyer{get;set;}
	//Create reference to the audioHandler script.\\
	private GameControllerPlayAudio audioHandler{get;set;}

	private void Start()
	{
		//The path to the AudioClip.\\
		string audioPath = "Assets/Audio/Effects/Explosion3.wav";
		//Load the audioClip.\\
		explosionSound = (AudioClip)AssetDatabase.LoadAssetAtPath (audioPath,typeof(AudioClip));
		//If the Loading failed...\\
		if (!explosionSound)
		{
			//Throw error.\\
			Debug.LogError ("Explosion audioclip is null!");
			return;
		}
		//Set references to the scripts.\\
		levelDestroyer = GetComponent<CreateLevelDestroyer> ();
		audioHandler = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<GameControllerPlayAudio> ();
	}
	//If the projectile collides with something...\\
	private void OnTriggerEnter2D(Collider2D other)
	{
		//If the object is the ground.\\
		if (other.gameObject.CompareTag (Tags.ground))
		{
			//Let the levelDestroyer do it's stuff.\\
			levelDestroyer.groundHit ();
			//Play the explosion sound.\\
			audioHandler.PlayAudio (explosionSound,false);
		}
	}
}
