using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60.0f;

    private Text timerText;

    private void Start()
    {
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
    }

    public void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft == 0.0f)
        {
            timeLeft = 60.0f;
        }

        timerText.text = Mathf.Round(timeLeft).ToString();
    }
}