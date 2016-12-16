using UnityEngine;
using System.Collections;

public class GameControllerPlayAudio : MonoBehaviour
{
    private AudioSource[] source;

    private bool notSameSound = false;

    private void Start()
    {
        source = GetComponents<AudioSource>();
    }

    public void PlayAudio(AudioClip clip)
    {
        for (int j = 0; j < source.Length - 1; j++)
        {
            if (clip != source[j].clip)
            {
                notSameSound = true;
            }
            else
            {
                notSameSound = false;
                j = source.Length;
            }
        }

        if (notSameSound)
        {
            for (int i = 0; i < source.Length - 1; i++)
            {
                if (source[i].isPlaying == false)
                {
                    source[i].clip = clip;
                    source[i].PlayOneShot(clip);
                    i = source.Length;
                }
            }
        }       
    }
}	

