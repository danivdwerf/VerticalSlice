using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthCheck : MonoBehaviour
{
    private Animator anim;
    private PlayerHealth playerHealth;

	void Start ()
    {
        playerHealth = GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
		if(playerHealth.GetPlayerHealth > 0 && playerHealth.GetPlayerHealth < 20)
        {
            anim.SetBool("hurt", true);
        }

        if(playerHealth.GetPlayerHealth < 1)
        {
            //anim.SetBool("dead", true);
            Destroy(this.gameObject);
        }
	}
}
