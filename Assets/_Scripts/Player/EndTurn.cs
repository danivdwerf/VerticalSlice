using UnityEngine;
using System.Collections;

public class EndTurn : MonoBehaviour
{
    private int[] currentTurn = { 0, 1 };
    public int arrayPos = 0;

    private Timer timer;
    private CurrentPlayer currentPlayer;

	void Start ()
    {
        timer = GetComponent<Timer>();
        currentPlayer = GetComponent<CurrentPlayer>();
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
        currentPlayer.currentSelectedPlayer().GetComponent<PlayerInput>().enabled = false;
        currentPlayer.nextPlayer();
        currentPlayer.currentSelectedPlayer().GetComponent<PlayerInput>().enabled = true;
        Debug.Log(currentPlayer.currentSelectedPlayer());
        timer.timeLeft = 0;
    }
}
