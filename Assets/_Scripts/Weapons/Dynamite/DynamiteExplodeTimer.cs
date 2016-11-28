using UnityEngine;
using System.Collections;

public class DynamiteExplodeTimer : MonoBehaviour
{
    private float detonateTime = 5;
    private float timeToDetonate;
    private DynamiteExplode dynamiteExplode;
    private bool timerStarted = false;
	// Use this for initialization
	void Start ()
    {
        dynamiteExplode = gameObject.GetComponent<DynamiteExplode>();
	}
	
    public void startTimer()
    {
        timeToDetonate = Time.time + detonateTime;
        timerStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeToDetonate && timerStarted)
        {
            //explode dynomite            
            dynamiteExplode.detonate();
            timerStarted = false;
        }
    }
}
