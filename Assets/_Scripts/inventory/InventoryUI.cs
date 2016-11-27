using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour 
{
	private Inventory inventory;
	[SerializeField]private Button[] buttons;
	[SerializeField]private GameObject inventoryPanel; 

	private void Start()
	{
		inventory = GetComponent<Inventory> ();
		inventoryPanel.SetActive (false);
		for (int i = 0; i < buttons.Length; i++)
		{
			int temp = i;
			buttons[i].onClick.AddListener (delegate(){inventory.SelectWeapon(temp);});
		}
	}

	public void showInventory()
	{
		if (inventoryPanel.activeInHierarchy)
		{
			hideInventory ();
			return;
		}
		inventoryPanel.SetActive (true);
	}

	public void hideInventory()
	{
		inventoryPanel.SetActive (false);
	}
}
