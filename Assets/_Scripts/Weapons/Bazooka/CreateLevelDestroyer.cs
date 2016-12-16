using UnityEngine;
using System.Collections;
//Create the circle that destroys the level.\\
public class CreateLevelDestroyer : MonoBehaviour 
{
	//Create reference to the cirlce.\\
	[SerializeField]private GameObject circle;
	//Create reference to the explosion GameObject.\\
	private GameObject explosion{ get; set;}

	private void Start()
	{
		//Check if the loading succeeded.\\
		if (!circle)
		{
			Debug.LogError ("Explosion circle is null!");
		}
	}
	public void groundHit()
	{
		//Instantiate the circle.\\
		GameObject destroyGround = Instantiate (circle)as GameObject;
		//Set the position to the impact point.\\
		destroyGround.transform.position = this.transform.position;
		//Set the rotation.\\
		destroyGround.transform.rotation = Quaternion.identity;
		//Destroy the projectile.\\
		Destroy(gameObject);
	}
}
