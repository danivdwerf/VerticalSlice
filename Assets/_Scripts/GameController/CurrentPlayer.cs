using UnityEngine;
using System.Collections;

public class CurrentPlayer : MonoBehaviour
{  
    [SerializeField]private GameObject[] players;
    [SerializeField]private int current = 0;

    private Timer timer;

    void Start()
    {
        timer = GetComponent<Timer>();
    }

    public GameObject currentSelectedPlayer()
    {        
        return players[current];
    }

    public void nextPlayer()
    {
        if(current < players.Length && timer.timeLeft <= 1.0f)
        {
            current++;
        }
        /*else
        {
            current = 0;
        }*/
        Debug.Log(players);
    }
}
