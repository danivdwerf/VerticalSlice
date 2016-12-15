using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEditor;

public class DynamiteExplodeTimer : MonoBehaviour
{
    private float detonateTime = 5;
    private float timeToDetonate;

    private bool timerStarted = false;
    private bool animationStarted = false;

    private DynamiteAnimation dynaAnimation;
    private DynamiteExplode dynamiteExplode;

    private AudioSource playAudio { get; set; }

    private AudioClip fuseClip { get; set; }

    private Text timeText;
    
	// Use this for initialization
	void Start ()
    {
        playAudio = GetComponent<AudioSource>();
        fuseClip = (AudioClip)AssetDatabase.LoadAssetAtPath(Paths.fusePath, typeof(AudioClip));

        timeText = GameObject.Find("DetonateTime").GetComponent<Text>();
        dynamiteExplode = gameObject.GetComponent<DynamiteExplode>();
        dynaAnimation = gameObject.GetComponent<DynamiteAnimation>();
    }
	
    public void startTimer()
    {
        playAudio.clip = fuseClip;
        playAudio.Play();
        timeToDetonate = Time.time + detonateTime;
        timerStarted = true;
    }

    void Update()
    {
        // start the detonate animation 0.4 seconds earlier
        if(Time.time > timeToDetonate - 0.4f && !animationStarted && timerStarted)
        {
            dynaAnimation.startDetonateAnimatio();
            animationStarted = true;
        }

        //if the detonate time is set show the text
        if(timeToDetonate > 0)
        {
            timeText.text = Mathf.Round(timeToDetonate - Time.time).ToString();
        }

        //if the timer is done
        if(Time.time > timeToDetonate && timerStarted)
        {
            // set the text to nothing
            timeText.text = "";
            //explode dynomite 
            dynamiteExplode.detonate();
            timerStarted = false;
        }
    }
}
