using UnityEngine;
using System.Collections;

public class GameControllerPlayAudio : MonoBehaviour 
{
	private AudioSource source;
	private void Start()
	{
		source = GetComponent<AudioSource> ();
	}
	public void PlayAudio(AudioClip clip,bool looping)
	{
		if (clip != source.clip)
		{
			source.clip = clip;
			source.loop = looping;
			source.Play ();
		}
	}
}
