using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DynamiteExplodeTimer : MonoBehaviour
{
    private float detonateTime = 5;
    private float timeToDetonate;

    private bool timerStarted = false;
    private bool animationStarted = false;

    private DynamiteAnimation dynaAnimation;
    private DynamiteExplode dynamiteExplode;

    [SerializeField]
    private Text timeText;
    
	// Use this for initialization
	void Start ()
    {
        dynamiteExplode = gameObject.GetComponent<DynamiteExplode>();
        dynaAnimation = gameObject.GetComponent<DynamiteAnimation>();
    }
	
    public void startTimer()
    {
        timeToDetonate = Time.time + detonateTime;
        timerStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeToDetonate - 0.4f && !animationStarted && timerStarted)
        {
            dynaAnimation.startDetonateAnimatio();
            animationStarted = true;
        }

        if(timeToDetonate > 0)
        {
            timeText.text =Mathf.Round(timeToDetonate - Time.time).ToString();
        }

        if(Time.time > timeToDetonate && timerStarted)
        {
            //explode dynomite            
            dynamiteExplode.detonate();
            timerStarted = false;
        }
    }
}
