using UnityEngine;
using System.Collections;
using UnityEditor;
//Fetch input for the bazooka.\\
public class BazookaInput : MonoBehaviour 
{
	//Create reference to the audiohandler script.\\
	private GameControllerPlayAudio playAudio{get;set;}
	//Create reference to the shootingScript.\\
	private BazookaShoot shootScript{get;set;}
	//Create reference to the inventoryUI script.\\
	private InventoryUI inventoryUI{get;set;}
	//Create reference to the charging audioclip.\\
	private AudioClip chargeClip{get;set;}
	//Create reference to the aimingScript.\\
	private BazookaAiming aiming{get;set;}

	//Create variable for maximal charging time.\\
	private float maxTime{get;set;}
	//Create variable for the current charging time.\\
	private float curTime{get;set;}
	//Create boolean tho hold if you are shooting or not.\\
	private bool shooting{get;set;}
	//Make the shooting boolean accessible.\\
	public bool GetShooting
	{
		get
		{ 
			return shooting;
		}

		set
		{ 
			shooting = value;
		}
	}

	private void Start()
	{
		//Set path for the charging audioclip.\\
		string chargePath = "Assets/Audio/Effects/RocketPowerup.wav";
		//Load the audioclip.\\
		chargeClip = (AudioClip)AssetDatabase.LoadAssetAtPath (chargePath,typeof(AudioClip));
		//Check if the loading succeeded.\\
		if (!chargeClip)
		{
			Debug.LogError ("The charging audioclip is null! Did you use the correct path?");
			return;
		}
		//Set references to the scripts.\\
		playAudio = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<GameControllerPlayAudio> ();
		inventoryUI = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<InventoryUI> ();
		shootScript = GetComponent<BazookaShoot> ();
		aiming = GetComponent<BazookaAiming> ();

		//Set the maximum charging time to the length of the charging Audioclip length.\\
		maxTime = chargeClip.length;
	}

	private void Update()
	{
		//If the upArrow is kept down...\\
		if(Input.GetKey(KeyCode.UpArrow))
		{
			//Let the aiming script do it's job.\\
			aiming.updateAim (1);
		}
		//If the downArrow is kept down...\\
		if (Input.GetKey (KeyCode.DownArrow))
		{
			//Let the aiming script do it's job.\\
			aiming.updateAim (-1);
		}
		//If space is clicked while not already shooting...\\
		if (Input.GetKey(KeyCode.Space)&&!shooting)
		{
			//Shooting is true...\\
			shooting = true;
			//and the inventory should be closed.\\
			inventoryUI.hideInventory ();
		}
		//If shooting is true...\\
		if (shooting)
		{
			//Update the shooting.\\
			updateShooting ();
		}
	}

	private void updateShooting()
	{
		//While chargin, increase the current charging time.\\
		curTime += Time.deltaTime;
		//Play the charging audio clip.\\
	
		//If you charge it for the full charging clip...\\
		if (curTime >= maxTime&&shooting)
		{
			//Shoot.\\
			this.shoot ();
		}
		//If you let go of the spacebar befor the time runs out...\\
		if (Input.GetKeyUp (KeyCode.Space)&&shooting)
		{
			//Shoot.\\
			this.shoot ();
		}
	}

	private void shoot()
	{
		//Calculate the shootingPower.\\
		float shootPower = (curTime / maxTime);
		//Call the shooting script.\\
		shootScript.shoot (shootPower);
		//Set the charging time to zero.\\
		curTime = 0;
	}


}
