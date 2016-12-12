using UnityEngine;
using System.Collections;

public class CurrentPlayer : MonoBehaviour
{
    private EndTurn endTurn;
    private PlayerInput playerInput;
    //private PlayerMovement playerMovement;

    [SerializeField]
    private GameObject[] players;
    [SerializeField]
    private int current;

    void Start()
    {
        endTurn = GetComponent<EndTurn>();
        playerInput = GameObject.FindObjectOfType<PlayerInput>();
        //playerMovement = GameObject.FindObjectOfType<PlayerMovement>();

        playerInput.enabled = true;
        //playerMovement.enabled = true;
    }

    void Update()
    {
        current = endTurn.arrayPos;
        if (endTurn.arrayPos == 0)
        {
            playerInput.enabled = true;
            //playerMovement.enabled = true;
        }
        else
        {
            playerInput.enabled = false;
            //playerMovement.enabled = false;
        }
    }

    public GameObject currentSelectedPlayer()
    {
        return players[current];
    }
}
