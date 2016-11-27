using UnityEngine;
using System.Collections;

public class CurrentPlayer : MonoBehaviour
{  
    [SerializeField]private GameObject[] players;
    [SerializeField]private int current = 0;

	public GameObject currentSelectedPlayer()
    {        
        return players[current];
    }

    public void nextPlayer()
    {
        if(current < players.Length - 1)
        {
            current++;
        }
        else
        {
            current = 0;
        }
    }
}
