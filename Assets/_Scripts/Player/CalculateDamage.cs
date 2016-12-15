using UnityEngine;
using System.Collections;

public class CalculateDamage : MonoBehaviour 
{
	private GameObject[] players{ get; set;}
	private void Start()
	{
		players = GameObject.FindGameObjectsWithTag(Tags.player);
		calcDamage ();
	}

	private void calcDamage()
	{
		for (int i = 0; i < players.Length; i++)
		{
			Vector2 distance = this.transform.position - players[i].transform.position;

			if (Mathf.Abs (distance.x) < 0.8f || Mathf.Abs (distance.y) < 0.5f)
			{
				PlayerHealth health = players[i].GetComponent<PlayerHealth> ();
				int damage = (int)(50 - (Mathf.Abs (distance.x+distance.y) * 98.4f));
				if (damage > 0)
				{
					Debug.Log ("Do " +damage+" damage to " + players [i].name);
					health.damage (damage);
				}
			
			}
		}
	}
}