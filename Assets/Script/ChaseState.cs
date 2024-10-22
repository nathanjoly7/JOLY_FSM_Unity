using UnityEngine;
using UnityEngine.AI;

public class ChaseState : StateMachineBehaviour
{
    private float chaseSpeed = 6.0f;

   
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Entering Chase State");

       
        NavMeshAgent agent = animator.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = chaseSpeed;
            agent.isStopped = false; 
        }
    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject target = GameObject.FindGameObjectWithTag("Enemy");
        NavMeshAgent agent = animator.GetComponent<NavMeshAgent>();

        if (target != null && agent != null)
        {
            
            agent.SetDestination(target.transform.position);

            
            if (Vector3.Distance(animator.transform.position, target.transform.position) <= 2.0f) 
            {
                animator.SetBool("IsAttacking", true);
                agent.isStopped = true; 
            }
        }
        else
        {
            animator.SetBool("IsChasing", false); 
            if (agent != null)
            {
                agent.isStopped = true; 
                //Destroy(target.gameObject);
            }
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Exiting Chase State");

        
        NavMeshAgent agent = animator.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.isStopped = true; 
        }
    }
}
