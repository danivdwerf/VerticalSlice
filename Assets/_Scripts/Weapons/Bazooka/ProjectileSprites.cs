using UnityEngine;
using System.Collections;
using UnityEditor;

public class ProjectileSprites : MonoBehaviour 
{
	private GameObject smokeCloud;

	private void Start()
	{
		string smokePath = "Assets/prefabs/Smoke.prefab";
		smokeCloud = (GameObject)AssetDatabase.LoadAssetAtPath (smokePath,typeof(GameObject));
		if (!smokeCloud)
		{
			Debug.LogError ("SmokeCloud is NULL!!");
			return;
		}
		StartCoroutine ("spawnCloud");
	}

	IEnumerator spawnCloud()
	{
		while (true)
		{
			yield return new WaitForSeconds (0.1f);
			Instantiate (smokeCloud, this.transform.position, Quaternion.identity);	
		}
	}
}
