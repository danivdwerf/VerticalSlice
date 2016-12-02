using UnityEngine;
using System.Collections;

public class DropDynamite : MonoBehaviour {
    private DynamiteExplodeTimer dynamiteTimer;

    private DynamiteAnimation dynaAnimation;

    private DynamiteMovement dynamitteMove;
    [SerializeField]
    private GameObject hand;

    public void Start()
    {
        dynamitteMove = GetComponent<DynamiteMovement>();
        dynaAnimation = GetComponentInChildren<DynamiteAnimation>();
        dynamiteTimer = gameObject.GetComponent<DynamiteExplodeTimer>();
    }
	public void dropTheDynamite()
    {
        if (gameObject.transform.parent != null)
        {           
            gameObject.transform.parent = null;
            dynamitteMove.startFall();
            dynaAnimation.startVuse();
            Destroy(hand);
            dynamiteTimer.startTimer();
        }

        
	}
}
