using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour 
{
	private float speed;
	private float gravity;
	private float time;
	public float Settime
	{
		set 
		{ 
			time = value;
		}
	}
	private Rigidbody2D rigid;
	private void Start()
	{
		rigid = GetComponent<Rigidbody2D> ();
		speed = 4f;

		rigid.AddForce (transform.right * speed * time, ForceMode2D.Impulse);
	}

	private void Update()
	{
		float angle = Mathf.Atan2(rigid.velocity.y, rigid.velocity.x) * Mathf.Rad2Deg; 
		this.transform.rotation = Quaternion.AngleAxis (angle,Vector3.forward);
	}
}
