using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IdleState : StateMachineBehaviour
{
    float timer;
    public float IdleTime = 5;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        Debug.Log(timer);
        if (timer > IdleTime)
        {
            Debug.Log("patrol start");
            animator.SetFloat("Speed", 0.4f);
            animator.SetBool("IsWalking", true);
        }
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // agent.SetDestination(agent.transform.position);
    }

  
}
