using UnityEngine;
using System.Collections;

public class DynamiteKeyInput : MonoBehaviour
{
    private DropDynamite dropDynamite;
    private InventoryUI inventoryUI;
    private bool drop = false;
   
	// Use this for initialization
	void Start ()
    {
        dropDynamite = gameObject.GetComponent<DropDynamite>();
        inventoryUI = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<InventoryUI>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Space) && !drop)
        {
            inventoryUI.hideInventory();
            dropDynamite.dropTheDynamite();
            drop = true;
        }
	}
}
