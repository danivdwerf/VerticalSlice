using UnityEngine;
using System.Collections;

public class DropDynamite : MonoBehaviour {
    private DynamiteExplodeTimer dynamiteTimer;

    public void Start()
    {
        dynamiteTimer = gameObject.GetComponent<DynamiteExplodeTimer>();
    }
	public void dropTheDynamite()
    {
        if (gameObject.transform.parent != null)
        {
            dynamiteTimer.startTimer();
            gameObject.transform.parent = null;
        }

        
	}
}
