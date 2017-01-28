using UnityEngine;
using System.Collections;

public class AudioSlap : StateMachineBehaviour
{
	public AudioClip NormalKick;
	override public void OnStateEnter( Animator animator, AnimatorStateInfo stateInfo, int layerIndex )
	{
		AudioSource.PlayClipAtPoint(NormalKick, animator.gameObject.transform.position);
	}
}