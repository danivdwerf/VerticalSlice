using UnityEngine;
using System.Collections;

public class CreateSmoke : MonoBehaviour 
{
	[SerializeField]private GameObject smokeCloud;

	private void Start()
	{
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
