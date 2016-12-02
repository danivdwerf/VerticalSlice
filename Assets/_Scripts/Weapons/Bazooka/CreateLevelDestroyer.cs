using UnityEngine;
using System.Collections;
using UnityEditor;
//Create the circle that destroys the level.\\
public class CreateLevelDestroyer : MonoBehaviour 
{
	//Create reference to the cirlce.\\
	private GameObject circle{get;set;}
	//Create reference to the explosion GameObject.\\
	private GameObject explosion{ get; set;}

	private void Start()
	{
		//The path to the circle GameObject.\\
		string circlePath="Assets/prefabs/BazookaExplosionRange.prefab";
		//Load in the GameObject.\\
		circle = (GameObject)AssetDatabase.LoadAssetAtPath (circlePath,typeof(GameObject));
		//Check if the loading succeeded.\\
		if (!circle)
		{
			Debug.LogError ("Explosion circle is null!");
		}
		//The path to the explosion GameObject.\\
		string explosionPath="Assets/prefabs/Explosion.prefab";
		//Load in the GameObject.\\
		explosion = (GameObject)AssetDatabase.LoadAssetAtPath (explosionPath,typeof(GameObject));
		//Check if the loading succeeded.\\
		if (!explosion)
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
