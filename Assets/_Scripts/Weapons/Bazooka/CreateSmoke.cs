using UnityEngine;
using System.Collections;
using UnityEditor;

public class CreateSmoke : MonoBehaviour 
{
	private GameObject smokeCloud;

	private void Start()
	{
		smokeCloud = (GameObject)AssetDatabase.LoadAssetAtPath (Paths.smokePath,typeof(GameObject));
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
			yield return new WaitForSeconds (0.2f);
			Instantiate (smokeCloud, this.transform.position, Quaternion.identity);	
		}
	}
}
