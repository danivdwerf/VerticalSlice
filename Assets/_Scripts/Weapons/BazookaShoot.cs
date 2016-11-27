using UnityEngine;
using System.Collections;

public class BazookaShoot : MonoBehaviour 
{
	//private GameObject bullet;
	private float maxTime;
	private float curTime;
	private bool shooting;
	private void Start()
	{
		shooting = false;
		maxTime = 2f;
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			shooting = true;
		}
		if(shooting)
		{
			updateShooting ();
		}
	}

	private void updateShooting()
	{
		curTime += Time.deltaTime;
		if (Input.GetKeyUp (KeyCode.Space))
		{
			shoot ();
		}
		if (curTime >= maxTime)
		{
			shoot ();
		}
	}

	private void shoot ()
	{
		Debug.Log ("Shoot");
		shooting = false;
		curTime = 0;
		return;
	}
}
