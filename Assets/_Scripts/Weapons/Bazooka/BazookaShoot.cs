using UnityEngine;
using System.Collections;

public class BazookaShoot : MonoBehaviour 
{
	[SerializeField]private GameObject projectile;
	[SerializeField]private Transform muzzle;
	private BazookaInput inputScript;
	private float maxTime;
	private float curTime;
	private void Start()
	{
		inputScript = GetComponent<BazookaInput> ();
		inputScript.GetShooting  = false;
		maxTime = 1f;
	}

	public void updateShooting()
	{
		curTime += Time.deltaTime;
		if (curTime >= maxTime&&inputScript.GetShooting)
		{
			shoot ();
		}
		if (Input.GetKeyUp (KeyCode.Space)&&inputScript.GetShooting)
		{
			shoot ();
		}
	}

	private void shoot ()
	{
		GameObject bullet = Instantiate(projectile,muzzle.position,muzzle.rotation)as GameObject;
		bullet.GetComponent<ProjectileMovement> ().Settime = (curTime/maxTime);
		curTime = 0;
		inputScript.GetShooting = false;
		Destroy (this.gameObject);
		return;
	}
}
