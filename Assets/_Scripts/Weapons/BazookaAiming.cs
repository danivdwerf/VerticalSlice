using UnityEngine;
using System.Collections;

public class BazookaAiming : MonoBehaviour 
{
	private bool targetting;
	[SerializeField]private Transform bodyTransform;
	private void Start()
	{
		targetting = true;
	}
	public void Update()
	{
		if( targetting )
		{
			updateTargetting();
		}
	}

	private void updateTargetting()
	{
		Vector3 mousePosScreen = Input.mousePosition;
		Vector3 mousePosWorld = Camera.main.ScreenToWorldPoint(mousePosScreen);
		Vector2 playerToMouse = new Vector2( mousePosWorld.x - transform.position.x,mousePosWorld.y - transform.position.y);
		playerToMouse.Normalize();

		float angle = Mathf.Asin(playerToMouse.y)*Mathf.Rad2Deg;
		if (playerToMouse.x < 0f)
		{
			angle = 180 - angle;
		}
		if(playerToMouse.x > 0f && bodyTransform.localScale.x > 0f )
		{
			bodyTransform.localScale = new Vector3(-bodyTransform.localScale.x, bodyTransform.localScale.y, 0f);
		}
		else if(playerToMouse.x < 0f && bodyTransform.localScale.x < 0f )
		{
			bodyTransform.localScale = new Vector3(-bodyTransform.localScale.x, bodyTransform.localScale.y, 0f);
		}
		transform.localEulerAngles = new Vector3(0f, 0f, angle);
	}
}
