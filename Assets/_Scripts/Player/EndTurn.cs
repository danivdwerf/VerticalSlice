using UnityEngine;
using System.Collections;

public class EndTurn : MonoBehaviour
{
    private int[] currentTurn = { 0, 1 };
    public int arrayPos = 0;

    private Timer timer;
    private CurrentPlayer currentPlayer;
    private FollowPlayer followPlayer;
    private SelectInput selectInput;
    private InventoryInput inventoryInput;

    private bool go;

    void Start()
    {
        timer = GetComponent<Timer>();
        currentPlayer = GetComponent<CurrentPlayer>();
        followPlayer = GameObject.Find("Main Camera").GetComponent<FollowPlayer>();
        selectInput = GetComponent<SelectInput>();
        inventoryInput = GetComponent<InventoryInput>();
        go = true;
    }

    void Update()
    {
        if (timer.timeLeft <= 0.02 && go == true)
        {
            Ass();
        }
    }

    public void Ass()
    {
        go = false;
        timer.timeLeft = 5.0f;
        selectInput.GetComponent<SelectInput>().enabled = false;
        inventoryInput.enabled = false;
        StartCoroutine(Delay());
    }

    IEnumerator WaitAndPrint()
    {
        yield return new WaitForSeconds(5);
    }

    IEnumerator Delay()
    {
        yield return StartCoroutine("WaitAndPrint");
        TurnEnd();
        timer.timeLeft = 60;
    }

    public void TurnEnd()
    {
        currentPlayer.currentSelectedPlayer().GetComponent<PlayerInput>().enabled = false;
        currentPlayer.nextPlayer();
        followPlayer.otherPlayer(currentPlayer.currentSelectedPlayer());
        currentPlayer.currentSelectedPlayer().GetComponent<PlayerInput>().enabled = true;
        selectInput.enabled = true;
        inventoryInput.enabled = true;

        go = true;
    }    
}
