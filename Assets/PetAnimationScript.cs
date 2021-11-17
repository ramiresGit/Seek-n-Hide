using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PetAnimationScript : StateMachineBehaviour 
{
/*    [SerializeField]
    private AnimationClip sphereAttackingAnimation;*/

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(stateInfo.IsName("Rolling"))
            animator.GetComponentInParent<PetScript>().IsNeedToMove = true;
       
        if (stateInfo.IsName("Attacking"))
        {
            animator.GetComponentInParent<PetScript>().BeginAttackingAnim();
        }

    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Rolling"))
            animator.GetComponentInParent<PetScript>().IsNeedToMove = false;

        if (stateInfo.IsName("Attacking"))
        {
            Debug.Log("Current state attacking");
            Destroy(animator.gameObject);
        }
            
    }

}
