using UnityEngine;
using System.Collections;

public class EndTurn : MonoBehaviour
{
    private int[] currentTurn = { 1, 2 };
    private int arrayPos = 0;

    private Timer timer;

	void Start ()
    {
        timer = GetComponent<Timer>();
	}
	
	void Update ()
    {
        if (timer.timeLeft <= 1f)
        {
            Debug.Log(currentTurn[arrayPos]);
            if(arrayPos >= currentTurn.Length -1)
            {
                arrayPos = 0;
            }
            else
            {
                arrayPos += 1;
            }
        }

	}
}
