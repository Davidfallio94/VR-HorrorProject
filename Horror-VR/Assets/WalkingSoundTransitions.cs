using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSoundTransitions : StateMachineBehaviour {

    public AudioSource almasound;
    public AudioClip Walk;


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        almasound.clip = Walk;
        almasound.loop = true;
        almasound.Play();
        
	}
}