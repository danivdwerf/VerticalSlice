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
		Debug.DrawLine (this.transform.position, curPlayer.transform.position,Color.red);
	}

	private void findDistance()
	{
		RaycastHit2D hit = Physics2D.Raycast(this.transform.position,curPlayer.transform.position);
		Debug.Log (hit.collider);
		if (hit)
		{
			if (hit.distance <= 0.8f)
			{
				//PLaceholder forumula till we get a better one:\\
				//integer damgage = (int)Mathf.Round(MaxDamgae-(hit.distance*60))\\
				int damage = (int)Mathf.Round (50-(hit.distance*60));
                health.damage(damage);
			}
		}

		Debug.Log (this.transform.position - curPlayer.transform.position);
	}
}