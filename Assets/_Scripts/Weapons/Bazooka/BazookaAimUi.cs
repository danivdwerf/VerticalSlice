using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

public class BazookaAimUi : MonoBehaviour 
{
	private Transform chargingBar;
	private void Start()
	{
		chargingBar = transform.GetChild(0).GetChild(0);
		chargingBar.gameObject.SetActive (false);
	}

	public void startCharging()
	{
		chargingBar.gameObject.SetActive (true);
	}

	private void Update()
	{
		if(this.transform.parent.localScale.x<0)
		{
			chargingBar.localEulerAngles = new Vector3 (0, 0, 90);
		}
		if (this.transform.parent.localScale.x > 0)
		{
			chargingBar.localEulerAngles = new Vector3 (0, 0, -90);
		}
	}
}
