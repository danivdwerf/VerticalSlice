using UnityEngine;
using System.Collections;
using UnityEditor;

public class ExplosionUI : MonoBehaviour 
{
	private GameObject explosion;
	private void Start()
	{
		explosion = AssetDatabase.LoadAssetAtPath (Paths.explosionParticlePath, typeof(GameObject)) as GameObject;
		if (!explosion)
		{
			Debug.LogError ("Could not find the explosion at: "+Paths.explosionParticlePath);
		}
	}
	public void createExplosion(Transform pos)
	{
		GameObject sploose = Instantiate (explosion, pos.position, Quaternion.identity) as GameObject;
		//Destroy (sploose);
	}
}
