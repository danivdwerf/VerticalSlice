using UnityEngine;
using System.Collections;

public class EndTurn : MonoBehaviour
{
    private int[] currentTurn = { 0, 1 };
    public int arrayPos = 0;

    private Timer timer;

	void Start ()
    {
        timer = GetComponent<Timer>();
	}
	
	void Update ()
    {
        if (timer.timeLeft <= 0.02f)
        {
            Ass();
        }
	}
    public void Ass()
    {
        timer.timeLeft = 0;
        if (arrayPos >= currentTurn.Length - 1)
        {
            arrayPos = 0;
        }
        else
        {
            arrayPos += 1;
        }
    }
}
