using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionHitDistance : MonoBehaviour
{
    private GameObject[] players;
    private Vector2 distance;
    // Use this for initialization
    void Start ()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for(int i = 0; i < players.Length; i++)
        {
            distance = players[i].transform.position - this.transform.position;

            if(Mathf.Abs(distance.x) < 0.5f && Mathf.Abs(distance.y) < 0.5f)
            {
                players[i].GetComponent<explosionForce>().calculatePush(distance);
            }
            Debug.Log("explotion position: " + this.transform.position + " player position: " + players[i].transform.position + " distance between the two: " + distance);
        }
	}
	
}
