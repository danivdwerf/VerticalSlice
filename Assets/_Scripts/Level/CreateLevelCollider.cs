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
		colliderPoints[162]=new Vector2(-0.37f,0.11f);
		col.points = colliderPoints;	
	}
}
