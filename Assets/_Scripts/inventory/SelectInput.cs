using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectInput : MonoBehaviour
{
    private Inventory inventory;

    private void Start()
    {
        inventory = GetComponent<Inventory>();
    }
    
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            inventory.SelectWeapon(0);
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            inventory.SelectWeapon(1);
        }
    }
}
