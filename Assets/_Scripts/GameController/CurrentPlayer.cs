using UnityEngine;
using System.Collections;

public class CurrentPlayer : MonoBehaviour
{
    private EndTurn endTurn;

    [SerializeField]
    private GameObject[] players;
    [SerializeField]
    private int current;

    void Start()
    {
        endTurn = GetComponent<EndTurn>();
    }

    void Update()
    {
        current = endTurn.arrayPos;

        if (endTurn.arrayPos == 0)
        {

        }
        Debug.Log(current);
    }

    public GameObject currentSelectedPlayer()
    {
        return players[current];
    }
}
