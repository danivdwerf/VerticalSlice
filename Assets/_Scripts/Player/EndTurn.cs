using UnityEngine;
using System.Collections;

public class EndTurn : MonoBehaviour
{
    private int[] currentTurn = { 0, 1 };
    public int arrayPos = 0;

    private Timer timer;
    private CurrentPlayer currentPlayer;
    private FollowPlayer followPlayer;

	void Start ()
    {
        timer = GetComponent<Timer>();
        currentPlayer = GetComponent<CurrentPlayer>();
        followPlayer = GameObject.Find("Main Camera").GetComponent<FollowPlayer>();

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
        followPlayer.otherPlayer(currentPlayer.currentSelectedPlayer());
    }
}
