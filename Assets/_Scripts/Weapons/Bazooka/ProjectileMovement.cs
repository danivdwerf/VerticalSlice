using UnityEngine;
using System.Collections;
//Set the movement of the projectile.\\
public class ProjectileMovement : MonoBehaviour 
{
	//variable to store the speed.\\
	private float speed{get;set;}
	//variable to store the charge time.\\
	private float time{get;set;}
	//Make the time setable.\\
	public float Settime
	{
		set 
		{ 
			time = value;
		}
	}
	//Create reference to the rigidbody component.\\
	private Rigidbody2D rigid{ get; set;}
	private void Start()
	{
		//Set reference to the rigidbody component.\\
		rigid = GetComponent<Rigidbody2D> ();
		//Set the speed of the projectile.\\
		speed = 4f;
		//Add a force to the forward position by the charging time times the speed.\\
		rigid.AddForce (transform.right * speed * time, ForceMode2D.Impulse);
	}

	private void Update()
	{
		//Calculate the angle in correlation to the x and y velocity of the bullet.\\
		float angle = Mathf.Atan2(rigid.velocity.y, rigid.velocity.x) * Mathf.Rad2Deg; 
		//update the rotation so it wil rotate towards the ground while losing forward velocity.\\
		this.transform.rotation = Quaternion.AngleAxis (angle,Vector3.forward);
	}
}
