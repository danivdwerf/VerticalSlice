using UnityEngine;
using System.Collections;

public class BazookaAiming : MonoBehaviour 
{
	private Transform thisTransform;
	private float angle;
	private float maxAngle;
	private void Start()
	{
		angle = 0f;
		maxAngle = 50f;
	}
	private void Update()
	{
		if(Input.GetKey(KeyCode.UpArrow))
		{
			updateAim (1);
			checkAngle ();
		}
		if (Input.GetKey (KeyCode.DownArrow))
		{
			updateAim (-1);
			checkAngle ();
		}
	}

	private void updateAim(int angleNum)
	{
		thisTransform = this.transform;
		this.transform.localEulerAngles = new Vector3 (0,0,angle);
		angle+=angleNum;
	}

	private void checkAngle()
	{
		if (angle > maxAngle)
		{
			angle = maxAngle;
		}
		if (angle < -maxAngle)
		{
			angle = -maxAngle;
		}
	}
}
