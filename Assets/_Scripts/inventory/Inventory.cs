using UnityEngine;
using System.Collections;
using UnityEditor;

public class Inventory : MonoBehaviour 
{
	[SerializeField]private GameObject[] weapons;
	private Equip equipWeapon;
	private void Start()
	{
		equipWeapon = GetComponent<Equip> ();
	}
	public void SelectWeapon(int weaponIndex)
	{
		equipWeapon.equipWeapon (weapons [weaponIndex]);
	}
}
