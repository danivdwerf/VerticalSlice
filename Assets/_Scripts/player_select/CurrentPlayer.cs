using UnityEngine;
using System.Collections;

public class CurrentPlayer : MonoBehaviour
{
    
    [SerializeField]
    private GameObject[] players;
    [SerializeField]
    private int Current = 0;

   
	
	
	public GameObject currentSelectedPlayer()
    {        
        return players[Current];
    }

    public void nextPlayer()
    {
        if(Current < players.Length - 1)
        {
            Current++;
        }
        else
        {
            Current = 0;
        }
    }
}
