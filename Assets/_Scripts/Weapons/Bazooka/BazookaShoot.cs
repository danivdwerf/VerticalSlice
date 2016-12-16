using UnityEngine;
using System.Collections;
using UnityEditor;
//Shoot a projectie\\
public class BazookaShoot : MonoBehaviour 
{
	//Create reference to the projectile.\\
	private GameObject projectile{get;set;}
	//Create reference to the muzzle.\\
	private Transform muzzle{get;set;}
	//Create reference to the audioHandler.\\
	private GameControllerPlayAudio playAudio{get;set;}
	//Create reference to the inputScript.\\
	private BazookaInput inputScript{get;set;}
	//Create reference to the shooting audioclip.\\
	private AudioClip shootClip{get;set;}

    private void Start()
	{
        //Load in the projectile.\\
        projectile = (GameObject)AssetDatabase.LoadAssetAtPath (Paths.projectilePath,typeof(GameObject));
		//Check if loading succeeded.\\
		if(!projectile)
		{
			//Throw error.\\
			Debug.LogError ("The GameObject Projectile is null! Did you use the correct path?");
			return;
		}
		//Load in the audioclip.\\
		shootClip = (AudioClip)AssetDatabase.LoadAssetAtPath (Paths.bazookaShootAudio,typeof(AudioClip));
		//Check if loading succeeded.\\
		if (!shootClip)
		{
			//Throw error.\\
			Debug.LogError ("The shooting audioclip is null! Did you use the correct path?");
			return;
		}
		//create refferences to the scripts.\\
		inputScript = GetComponent<BazookaInput> ();
		playAudio = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<GameControllerPlayAudio> ();
		//Create reference to the muzzle transform.\\
		muzzle = this.transform.GetChild(0).GetComponent<Transform>();
		//Set shooting to false.\\
		inputScript.GetShooting  = false;
	}
	//Shoot a projectile.\\
	public void shoot (float shootPower)
	{
        //Instantiate a projectile.\\
        GameObject bullet = Instantiate(projectile) as GameObject;
		//Set the instantiating position.\\
		bullet.transform.position = muzzle.position;
		//Set instantiating rotation.\\
		bullet.transform.rotation = muzzle.rotation;
		//Set the shooting power of the projectile.\\
		bullet.GetComponent<ProjectileMovement> ().Settime = shootPower;
		//Play the shooting audio.\\
		playAudio.PlayAudio (shootClip);
		//Set shooting to false.\\
		inputScript.GetShooting = false;
		//Unequip weapon.\\
		Destroy (this.gameObject);
	}
}
