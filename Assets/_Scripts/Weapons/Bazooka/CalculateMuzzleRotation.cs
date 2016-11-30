using UnityEngine;
using System.Collections;
//Rotate the muzzle according to the players rotation\\
public class CalculateMuzzleRotation : MonoBehaviour 
{
	//reference to the bazooka
	private Transform parent{get;set;}
	private void Start()
	{
		//set the reference\\
		parent = transform.parent;
	}

	private void Update()
	{
		//if the bazooka points to the right..\\
		if(parent.parent.localScale.x>0)
		{
			//Make the muzzle also point to the right\\
			this.transform.localEulerAngles = new Vector3 (0,0,0);
		}
		//If the bazooka points to the left...\\
		if(parent.parent.localScale.x<0)
		{
			//Make the muzzle also point to the left, to the left, everything you own in the box to the left.	\\
			this.transform.localEulerAngles = new Vector3 (0,180,0);
		}
	}
}
