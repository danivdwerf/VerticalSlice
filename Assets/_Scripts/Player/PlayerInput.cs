﻿using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour 
{
	private PlayerMovement movement;
	private ChangeScene changeScene;
	private float speed;
	private void Start()
	{
		speed = 0.3f;
		movement = GetComponent<PlayerMovement>(); 
		changeScene = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponentInParent<ChangeScene> ();
	}
	private void Update()
	{
		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			movement.SetSpeed = speed;
		}
		if (Input.GetKeyUp (KeyCode.RightArrow))
		{
			movement.SetSpeed = 0f;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			movement.SetSpeed = -speed;
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow))
		{
			movement.SetSpeed = 0f;
		}
		if (Input.GetKeyDown (KeyCode.Return))
		{
            movement.Jump (3,2.5f);
		}
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			changeScene.change (0);
		}
	}
}
