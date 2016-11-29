using UnityEngine;
using System.Collections;
using UnityEditor;

public class BazookaShoot : MonoBehaviour 
{
	[SerializeField]private GameObject projectile;
	[SerializeField]private Transform muzzle;
	private GameControllerPlayAudio playAudio;
	private BazookaInput inputScript;
	private AudioClip shootClip;
	private AudioClip chargeClip;
	private float maxTime;
	private float curTime;

	private void Start()
	{
		inputScript = GetComponent<BazookaInput> ();
		playAudio = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<GameControllerPlayAudio> ();
		string shootPath = "Assets/Audio/Effects/RocketRelease.wav";
		shootClip = (AudioClip)AssetDatabase.LoadAssetAtPath (shootPath,typeof(AudioClip));
		string chargePath = "Assets/Audio/Effects/RocketPowerup.wav";
		chargeClip = (AudioClip)AssetDatabase.LoadAssetAtPath (chargePath,typeof(AudioClip));
		inputScript.GetShooting  = false;
		maxTime = (chargeClip.length/chargeClip.length);
	}

	public void updateShooting()
	{
		curTime += Time.deltaTime;
		playAudio.PlayAudio (chargeClip, false);
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
		playAudio.PlayAudio (shootClip,false);
		curTime = 0;
		inputScript.GetShooting = false;
		Destroy (this.gameObject);
		return;
	}
}
