﻿using UnityEngine;
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