using UnityEngine;
using System.Collections;
//Aim your bazooka.\\
public class BazookaAiming : MonoBehaviour 
{
	//Variable to store the current shooting angle.\\
	private float angle{get;set;}
	//variable to store the max shooting angle.\\
	private float maxAngle{get;set;}

	private void Start()
	{
		//Set the variable values.\\
		angle = 0f;
		maxAngle = 50f;
	}

	//Update the aiming rotation.\\
	public void updateAim(int angleNum)
	{
		//Add a the value to the angle to aim it up or down.\\
		angle+=angleNum;
		//Check if the angle is over/under the maxAngle.\\
		checkAngle ();
		//Set the roatation to the current angle value.\\
		this.transform.localEulerAngles = new Vector3 (0,0,angle);
	}

	private void checkAngle()
	{
		//If the angle is greater than the max angle...\\
		if (angle > maxAngle)
		{
			//Set the angle back to the maxAngle.\\
			angle = maxAngle;
		}
		//If the angle is less than the maxAngle...\\
		if (angle < -maxAngle)
		{
			//Set the angle back to the maxAngle.\\
			angle = -maxAngle;
		}
	}
}
