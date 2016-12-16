using UnityEngine;
using System.Collections;

public class GameControllerPlayAudio : MonoBehaviour 
{
	private AudioSource[] source;

	private void Start()
	{
		source = GetComponents<AudioSource>();
	}

	public void PlayAudio(AudioClip clip,bool looping)
	{
        for(int i = 0; i < source.Length-1; i++)
        {
            if(source[i].isPlaying == false)
            {
                source[i].clip = clip;
                source[i].loop = looping;
                source[i].PlayOneShot(clip);
                i = source.Length;
            }           
        }		
	}
}
