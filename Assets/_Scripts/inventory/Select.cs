using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Select : MonoBehaviour 
{
	private Inventory inventory;
	[SerializeField]private Button button;

    private void Start()
    {
		inventory = GetComponent<Inventory> ();
		button.onClick.AddListener (delegate(){requestInventory(0);});
    }

    //to select wapon using a number witch represent the posision in a array
    public void requestInventory(int weaponIndex)
    {
		inventory.SelectWeapon (weaponIndex);
    }
}
