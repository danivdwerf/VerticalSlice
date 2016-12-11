using UnityEngine;
using System.Collections;

public class CreateLevelCollider : MonoBehaviour 
{
	private PolygonCollider2D col;
	public void SetCollider()
	{
		this.gameObject.AddComponent<PolygonCollider2D> ();
		col=GetComponent<PolygonCollider2D>();
		Vector2[] colliderPoints = col.points;
		col.points = colliderPoints;	
	}
}
