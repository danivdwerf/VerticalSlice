using UnityEngine;
using System.Collections;

public class BazookaInput : MonoBehaviour 
{
	private BazookaShoot shootScript;
	private InventoryUI inventoryUI;
	private bool shooting;
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
		shootScript = GetComponent<BazookaShoot> ();
		inventoryUI = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<InventoryUI> ();
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.Space)&&!shooting)
		{
			shooting = true;
			inventoryUI.hideInventory ();
		}
		if(shooting)
		{
			shootScript.updateShooting ();
		}
	}
}
