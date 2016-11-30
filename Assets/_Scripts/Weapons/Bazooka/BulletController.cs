using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour 
{
	public static GroundController groundController;
	private CircleCollider2D circle;

    private PlayerHealth _playerHealth;

	private void Start()
	{
        _playerHealth = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerHealth>();

		circle = GetComponent<CircleCollider2D> ();
	}
	void OnCollisionEnter2D( Collision2D coll )
	{
		if( coll.gameObject.CompareTag(Tags.ground))
		{
			groundController.DestroyGround(circle);
			Destroy(gameObject);
		}
        if(coll.gameObject.CompareTag(Tags.player))
        {
            _playerHealth.SetHealth = 10;
        }
	}
}
