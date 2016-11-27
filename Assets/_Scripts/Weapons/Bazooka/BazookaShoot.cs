using UnityEngine;
using System.Collections;

public class BazookaShoot : MonoBehaviour 
{
	[SerializeField]private GameObject projectile;
	[SerializeField]private Transform muzzle;
	private float maxTime;
	private float curTime;
	private bool shooting;
	private void Start()
	{
		shooting = false;
		maxTime = 1f;
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.Space)&&!shooting)
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
		if (curTime >= maxTime&&shooting)
		{
			shoot ();
		}
		if (Input.GetKeyUp (KeyCode.Space)&&shooting)
		{
			shoot ();
		}
	}

	private void shoot ()
	{
		GameObject bullet = Instantiate(projectile,muzzle.position,muzzle.rotation)as GameObject;
		bullet.GetComponent<ProjectileMovement> ().Settime = (curTime/maxTime);
		curTime = 0;
		shooting = false;
		return;
	}
}
