using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudmove : MonoBehaviour
{
    private float speed;

    private void Start()
    {
        speed = Random.Range(1, 3);
        speed = Random.value + 0.1f;
    }

	void Update ()
    {
        gameObject.transform.position += new Vector3(speed * Time.deltaTime,0,0);

        if(gameObject.transform.position.x > 8)
        {
            gameObject.transform.position = new Vector3(-7, ((Random.value + 0.1f) * 4) - 1, 3);
        }
	}
}
