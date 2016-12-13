using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionHitDistance : MonoBehaviour
{
	
    private GameObject[] players;
    private Vector2 distance;

    void Start ()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < players.Length; i++)
        {
            distance = players[i].transform.position - this.transform.position;

            if(Mathf.Abs(distance.y) == 0)
            {
                distance.y += 0.1f;
            }

            if (Mathf.Abs(distance.x) < 0.5f && Mathf.Abs(distance.y) < 0.5f)
            {
                players[i].GetComponent<explosionForce>().calculatePush(distance);
            }
        }
	}
	
}
