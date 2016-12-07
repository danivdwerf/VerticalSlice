using UnityEngine;
using System.Collections;

public class CalculateDamage : MonoBehaviour 
{
	private GameObject curPlayer{ get;set;}
	private void Start()
	{
		curPlayer = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<CurrentPlayer> ().currentSelectedPlayer();
		findDistance ();
		Debug.DrawLine (this.transform.position, curPlayer.transform.position,Color.red);
	}

	private void findDistance()
	{
		RaycastHit2D hit = Physics2D.Raycast(this.transform.position,curPlayer.transform.position);
		Debug.Log (hit.collider);
		if (hit)
		{
			if (hit.distance <= 0.2f)
			{
				curPlayer.GetComponent<Rigidbody2D> ().AddForce (transform.right*10,ForceMode2D.Impulse);
			}
			if (hit.distance <= 0.8f)
			{
				//PLaceholder forumula till we get a better one:\\
				//integer damgage = (int)Mathf.Round(MaxDamgae-(hit.distance*60))\\
				int damage = (int)Mathf.Round (50-(hit.distance*60));
			}
		}

		Debug.Log (this.transform.position - curPlayer.transform.position);
	}
}