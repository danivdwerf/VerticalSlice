using UnityEngine;
using System.Collections;

public class CurrentPlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject[] players;
    [SerializeField]
    private int current;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
 
    }

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
