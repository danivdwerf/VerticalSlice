using UnityEngine;
using System.Collections;
#if UNITY_EDITOR
using UnityEditor;
#endif

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
