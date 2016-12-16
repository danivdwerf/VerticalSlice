using UnityEngine;
using System.Collections;

public class explosionForce : MonoBehaviour
{
    private Animator anim;
    private Vector2 distance;
    private bool playerHit = false;

    private Vector2 desiredVelocity;
    private Vector2 position = new Vector2();
    private Vector2 velocity = new Vector2(0, 0);
    private float mass = 20;
    private float maxSpeed = 80;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
        if (playerHit)
        {
            pushPlayer();
        }
        else
        {
            this.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        }
    }

    private void pushPlayer()
    {        
        if (Mathf.Abs(velocity.x) > 0)
        {
            velocity.x = velocity.x - (0.5f * Time.deltaTime);
        }

        if (Mathf.Abs(velocity.y) > 0)
        {
            velocity.y = velocity.y - (10f * Time.deltaTime);
        }

        if (transform.position.y < -3.5)
        {
            position = new Vector3((Random.value * 8.5f) - 4, 4f, 0);
        }

        float angle = Mathf.Atan2(velocity.y, velocity.x) * Mathf.Rad2Deg;

        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        position += velocity * Time.deltaTime;

        transform.position = position;
    }

    public void calculatePush(Vector2 hitDistance)
    {
        position = this.transform.position;
        distance = hitDistance;
        distance.Normalize();
        desiredVelocity = distance * maxSpeed;
        velocity = desiredVelocity / mass;

        //fly higher
        if(velocity.y >= 0)
        {
            velocity.y += 2;
        }

        anim.SetBool("ExplotionHit", true);
        playerHit = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && playerHit == true)
        {
            anim.SetBool("ExplotionHit", false);
            playerHit = false;
        }
    }

}