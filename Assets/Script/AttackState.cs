using UnityEngine;

public class AttackState : StateMachineBehaviour
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
     
        Debug.Log("Attaque commencée !");
    }

 
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            animator.SetBool("IsAttacking", true);
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            
            animator.SetBool("IsAttacking", false);
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Debug.Log("Attaque terminée !");
        animator.SetBool("IsAttacking", false);
    }

    void Update()
    {
        
    }
    }
