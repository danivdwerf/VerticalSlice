using UnityEngine;
using System.Collections;
using UnityEditor;

public class Inventory : MonoBehaviour 
{
	[SerializeField]
    private GameObject[] weapons;

	private EquipWeapon equipWeapon;

	private void Start()
	{
		equipWeapon = GetComponent<EquipWeapon> ();
	}

	public void SelectWeapon(int weaponIndex)
	{
		equipWeapon.equipWeapon (weapons [weaponIndex]);
	}
}
