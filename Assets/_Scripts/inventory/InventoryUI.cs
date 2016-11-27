using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class InventoryUI : MonoBehaviour 
{
	private Inventory inventory;
	[SerializeField]private Button[] buttons;

	private void Start()
	{
		inventory = GetComponent<Inventory> ();
		for (int i = 0; i < buttons.Length; i++)
		{
			int temp = i;
			buttons[i].onClick.AddListener (delegate(){inventory.SelectWeapon(temp);});
		}
	}
}
