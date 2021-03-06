﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class GameControllerPlayAudio : MonoBehaviour
{
    private List<AudioSource> sources = new List<AudioSource>();

    private bool notSameSound = true;

    private void Update()
    {
        for (int i = sources.Count -1; i >= 0; i--)
        {
            if (sources[i].isPlaying == false)
            {
                Destroy(sources[i]);
                sources.Remove(sources[i]);                
                break;
            }
        }
    }

    public void PlayAudio(AudioClip clip)
    {
        for (int j = 0; j < sources.Count - 1; j++)
        {
            if (clip != sources[j].clip)
            {
                notSameSound = true;
            }
            else
            {
                notSameSound = false;
                break;
            }
        }

        if (notSameSound)
        {
            AudioSource source;
            source = gameObject.AddComponent<AudioSource>();
            source.clip = clip;
            source.Play();
            sources.Add(source);
        }
        
    }
}	

