using UnityEngine;
using System.Collections;

public class BazookaAiming : MonoBehaviour 
{
	private void Update()
	{
		if(Input.GetKey(KeyCode.UpArrow))
		{
			updateAim ();
		}
	}

	private void updateAim()
	{
		
	}
}
