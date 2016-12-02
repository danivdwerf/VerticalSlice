using UnityEngine;
using System.Collections;

public class CloudController : MonoBehaviour 
{
	private Animator anim;
	private AnimationClip clip;
	private AnimationEvent animEvent; 

	private void Start()
	{
		anim = GetComponent<Animator> ();
		animEvent = new AnimationEvent ();
		clip = this.anim.runtimeAnimatorController.animationClips [0];
		addEvent ();
	}

	public void deleteObject()
	{
		Destroy (gameObject);
	}

	private void addEvent()
	{
		animEvent.functionName = "deleteObject";
		animEvent.time = clip.length;
		clip.AddEvent (animEvent);
	}
}
