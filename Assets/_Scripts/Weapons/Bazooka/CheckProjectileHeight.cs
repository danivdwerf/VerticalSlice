using UnityEngine;
using System.Collections;

public class CheckProjectileHeight : MonoBehaviour 
{
	private void Update()
	{
		if (this.transform.position.y < -5f)
		{
			Destroy (gameObject);
		}
	}
}
