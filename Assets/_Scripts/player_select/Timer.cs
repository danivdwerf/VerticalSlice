using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60.0f;

    [SerializeField]
    private Text timerText;

    private void Start()
    {

    }

    public void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0f)
        {
            timeLeft = 60.0f;
        }

        timerText.text = Mathf.Round(timeLeft).ToString();
    }
}