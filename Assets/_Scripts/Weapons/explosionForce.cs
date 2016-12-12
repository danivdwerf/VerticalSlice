using UnityEngine;
using System.Collections;

public class explosionForce : MonoBehaviour 
{
    private Vector2 distance;
    private bool playerHit = false;

    private Vector2 position = new Vector2();
    private Vector2 velocity = new Vector2(0, 0);
    private float mass = 50;
    private float maxSpeed = 10;

    private void Update()
    {       
        if (playerHit)
        {
            pushPlayer();
        }
    }

	private void pushPlayer()
	{
        Debug.Log(distance);
        distance.Normalize();
        Debug.Log(distance);

        if (maxSpeed > 0)
        {
            maxSpeed -= 0.2f;
        }
        else
        {
            maxSpeed = 4;
            playerHit = false;
        }

        Vector2 desiredVelocity = distance * maxSpeed ;

        velocity += desiredVelocity / mass;
        
        position += velocity * Time.deltaTime;

        transform.position = position;
    }
    public void calculatePush(Vector2 hitDistance)
    {
        position = this.transform.position;
        distance = hitDistance;
        playerHit = true;
    }
}
