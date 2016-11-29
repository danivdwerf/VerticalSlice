using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateLevelDestroyer : MonoBehaviour 
{
	private GameObject circle;
	private void Start()
	{
		string circlePath="Assets/prefabs/BazookaExplosionRange.prefab";
		circle = (GameObject)AssetDatabase.LoadAssetAtPath (circlePath,typeof(GameObject));
		if (!circle)
		{
			Debug.LogError ("Explosion circle is null!");
		}
	}
	public void groundHit()
	{
		GameObject destroyGround = Instantiate (circle)as GameObject;
		destroyGround.transform.position = this.transform.position;
		destroyGround.transform.rotation = Quaternion.identity;
		Destroy(gameObject);
	}
}
