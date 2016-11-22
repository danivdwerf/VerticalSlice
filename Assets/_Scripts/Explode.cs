using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour 
{
	private DestroySprite doIt;
	private void Start()
	{
		doIt = GetComponent<DestroySprite> ();
	}
	private void Update()
	{
		if (Input.GetMouseButtonUp (0))
		{
			Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			point.z = 0; 
			doIt.cutHole (Input.mousePosition.x,Input.mousePosition.y);
		}
	}
}
