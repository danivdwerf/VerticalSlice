using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour 
{
	private PlayerMovement movement;
	private InventoryUI inventoryUI;
	private float speed;
	private void Start()
	{
		speed = 0.3f;
		movement = GetComponent<PlayerMovement>(); 
		inventoryUI = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<InventoryUI> ();
	}
	private void Update()
	{
		if (Input.GetMouseButtonDown (1))
		{
			inventoryUI.showInventory ();
		}
		if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			movement.SetSpeed = speed;
		}
		if (Input.GetKeyUp (KeyCode.RightArrow))
		{
			movement.SetSpeed = 0f;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			movement.SetSpeed = -speed;
		}
		if (Input.GetKeyUp (KeyCode.LeftArrow))
		{
			movement.SetSpeed = 0f;
		}
		if (Input.GetKeyDown (KeyCode.Return))
		{
            movement.Jump (3,3);
		}
	}
}
