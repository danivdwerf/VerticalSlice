using UnityEngine;
using System.Collections;

public class CalculateDamage : MonoBehaviour 
{
	private void Start()
	{
		GameObject curPlayer = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<CurrentPlayer> ().currentSelectedPlayer();
		RaycastHit2D hit = Physics2D.Raycast(this.transform.position,curPlayer.transform.position);
		if (hit)
		{
			if (hit.distance <= 0.2f)
			{
				curPlayer.GetComponent<Rigidbody2D> ().AddForce (transform.right*10,ForceMode2D.Impulse);
			}
			if (hit.distance <= 0.8f)
			{
				int damage = (int)Mathf.Round (50-(hit.distance*60));
			}
		}
	}
}