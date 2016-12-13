using UnityEngine;
using System.Collections;

public class DynamiteExplode : MonoBehaviour 
{
    [SerializeField]private GameObject circle; 
	private ExplosionUI ui;
    private EndTurn endTurn;

	private void Start()
	{
		ui = GetComponent <ExplosionUI>();
        endTurn = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<EndTurn>();
	}

    //detonate the dynamite
    public void detonate()
    {
        endTurn.Ass();
        Instantiate(circle, this.transform.position, Quaternion.identity);
		ui.createExplosion (this.transform);
        Destroy(gameObject);
    }
}