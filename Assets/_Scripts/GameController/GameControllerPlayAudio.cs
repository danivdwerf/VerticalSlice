using UnityEngine;
using System.Collections;

public class GameControllerPlayAudio : MonoBehaviour 
{
	private AudioSource source;

	private void Start()
	{
		source = GetComponent<AudioSource> ();
	}

	public void PlayAudio(AudioClip clip)
	{
		if (clip != source.clip)
		{
			source.clip = clip;
			source.Play();
		}
	}
}
