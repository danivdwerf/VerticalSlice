using UnityEngine;
using System.Collections;

public class explosionForce : MonoBehaviour 
{
	private Vector2 distance;
	private GameObject currentPlayer;
	private Rigidbody2D rigid;
	// Use this for initialization
	void Start () 
	{
		currentPlayer = GameObject.FindGameObjectWithTag (Tags.gameController).GetComponent<CurrentPlayer>().currentSelectedPlayer();
		distance = this.transform.position - currentPlayer.transform.position;
		rigid = currentPlayer.GetComponent<Rigidbody2D> ();
		if (Mathf.Abs(distance.x) < 1.2f&&Mathf.Abs(distance.y)<1.2f)
		{
			pushPlayer ();
		}
	}

	private void pushPlayer()
	{
		float forceMultiplier = -900000;
		Vector2 forceVector = distance*forceMultiplier;
		rigid.AddRelativeForce(forceVector*Time.deltaTime);
	}
}
