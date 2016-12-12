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
        for(int i = 0; i < players.Length -1; i++)
        {
            distance = this.transform.position - players[i].transform.position;
            Debug.Log(distance.x);
            Debug.Log(Mathf.Abs(distance.x));
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
