using UnityEngine;
using System.Collections;

public class DropDynamite : MonoBehaviour {
    private DynamiteExplodeTimer dynamiteTimer;

    private DynamiteAnimation dynaAnimation;

    [SerializeField]
    private GameObject hand;

    public void Start()
    {
        dynaAnimation = GetComponentInChildren<DynamiteAnimation>();
        dynamiteTimer = gameObject.GetComponent<DynamiteExplodeTimer>();
    }
	public void dropTheDynamite()
    {
        if (gameObject.transform.parent != null)
        {           
            gameObject.transform.parent = null;
            dynaAnimation.startVuse();
            Destroy(hand);
            dynamiteTimer.startTimer();
        }

        
	}
}
