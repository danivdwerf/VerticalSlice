using UnityEngine;
using System.Collections;

public class CalculateDamage : MonoBehaviour 
{
	private GameObject curPlayer;
	private PlayerHealth health;
	private void Start()
	{
		curPlayer = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<CurrentPlayer> ().currentSelectedPlayer();
        health = curPlayer.GetComponent<PlayerHealth>();
		findDistance ();
	}

	private void findDistance()
	{
		Vector2 distance = this.transform.position-curPlayer.transform.position;
		if (Mathf.Abs (distance.x)<=0.8f||Mathf.Abs(distance.y)<=0.5f)
		{
			int damage = (int)(50 - (Mathf.Abs(distance.x) * 56.25f));
			health.damage (damage);
		}
	}
}