using UnityEngine;
using System.Collections;

public class GameControllerAudioHandle : MonoBehaviour 
{
	private AudioSource source;
	private void Start()
	{
		source = GetComponent<AudioSource> ();
	}
	public void PlayAudio(AudioClip clip,bool looping)
	{
		source.clip = clip;
		source.loop = looping;
		source.Play ();
	}
}
