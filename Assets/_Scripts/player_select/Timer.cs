using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60.0f;

    public void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0f)
        {
            timeLeft = 60.0f;
        }
    }
}