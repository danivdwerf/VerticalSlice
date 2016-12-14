using UnityEngine;
using System.Collections;

public class DynamiteAnimation : MonoBehaviour
{

    private Animator animator;

    // Use this for initialization
    void Start ()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
	}
    public void startVuse()
    {
        animator.SetBool("drop", true);
    }

    //start animation
    public void startDetonateAnimatio()
    {
        animator.SetBool("explode", true);
    }
}
