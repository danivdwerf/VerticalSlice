using UnityEngine;
using System.Collections;

public class CalculateMuzzleRotation : MonoBehaviour 
{
	private Transform parent;
	private void Start()
	{
		parent = transform.parent;
	}

	private void Update()
	{
		if(parent.parent.localScale.x>0)
		{
			this.transform.localEulerAngles = new Vector3 (0,0,0);
			//this.transform.eulerAngles = new Vector3 (0,0,this.transform.eulerAngles.x);
		}
		if(parent.parent.localScale.x<0)
		{
			this.transform.localEulerAngles = new Vector3 (0,180,0);
			//this.transform.eulerAngles = new Vector3(0,180,0);	
		}
	}
}
