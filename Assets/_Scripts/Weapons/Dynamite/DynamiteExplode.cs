using UnityEngine;
using System.Collections;

public class DynamiteExplode : MonoBehaviour 
{
    [SerializeField]private GameObject circle; 
	private ExplosionUI ui;
	private void Start()
	{
		ui = GetComponent <ExplosionUI>();
	}

    //detonate the dynamite
    public void detonate()
    {
        GameObject destroyGround = Instantiate(circle, this.transform.position, Quaternion.identity) as GameObject;
		ui.createExplosion (this.transform);
        Destroy(gameObject);
    }
}