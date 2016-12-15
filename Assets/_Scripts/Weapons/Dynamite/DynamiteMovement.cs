using UnityEngine;
using System.Collections;
//laat de dynamite vallen tot hij de grond raakt.
public class DynamiteMovement : MonoBehaviour
{
    [SerializeField]
    private float _fallSpeed = 2;

    private Vector3 _fall = new Vector3();

    private bool _startFall = false;

    public void startFall ()
    {
        _fall = new Vector3(0, _fallSpeed, 0);
        _startFall = true;
	}

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 100f);

        if (hit.collider && _startFall)
        {
            if (hit.collider.tag == Tags.ground)
            {
                if (hit.distance < 0.05f)
                {
                    _startFall = false; 
                }
            }
        }

        if (_startFall)
        {
            transform.position -= _fall * Time.deltaTime;
        }
                      
            
        
    }

}
