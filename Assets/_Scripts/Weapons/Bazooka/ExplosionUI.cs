using UnityEngine;
using System.Collections;

public class ExplosionUI : MonoBehaviour 
{
	[SerializeField]private GameObject explosion;
	private void Start()
	{
		if (!explosion)
		{
			Debug.LogError ("Could not find the explosion at: "+Paths.explosionParticlePath);
		}
	}
	public void createExplosion(Transform pos)
	{
		Instantiate (explosion, pos.position, Quaternion.identity);
	}
}
