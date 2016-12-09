using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerGravity : MonoBehaviour 
{
	private Rigidbody2D rigid;

	private float gravity;

	private void Start()
	{
		rigid = GetComponent<Rigidbody2D> ();
		gravity = 300000f;
	}

	private void Update()
	{
        Vector3 forward = transform.TransformDirection(-Vector3.up) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down,100f); 
		if (hit.collider)
		{
			if (hit.collider.tag == Tags.ground)
			{                
                if (hit.distance < 0.14f)
				{
					gravity = 5000f;
				} 
				else
				{
					gravity = 120000f;//200000f
                }
			}
		}
        
		rigid.AddForce (-transform.up*gravity*Time.deltaTime);
	}
}
