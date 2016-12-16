using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    private InventoryUI inventoryUI;

    void Start ()
    {
        inventoryUI = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<InventoryUI>();
    }
	
	void Update ()
    {
        if (Input.GetMouseButtonDown(1))
        {
            inventoryUI.showInventory();
        }
    }
}
