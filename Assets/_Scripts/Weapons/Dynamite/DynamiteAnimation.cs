﻿using UnityEngine;
using System.Collections;

public class DynamiteAnimation : MonoBehaviour {
    private Animator animator;

    // Use this for initialization
    void Start ()
    {
        animator = GetComponent<Animator>();
	}

    //start animation
    public void startDetonateAnimatio()
    {
        animator.SetBool("explode", true);
    }
}
