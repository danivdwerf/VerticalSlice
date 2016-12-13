using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplosion : MonoBehaviour 
{
	private ParticleSystem ps;
	private void Start()
	{
		ps = GetComponent<ParticleSystem> ();
	}

	private void Update()
	{
		if (!ps.IsAlive(true))
		{
			Destroy (gameObject);
		}
	}
}
