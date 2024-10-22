using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    // Appelé lorsque l'état d'animation commence à s'exécuter
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Déclenchement d'attaque au début de l'état
        Debug.Log("Attaque commencée !");
    }

    // Appelé à chaque frame pendant l'exécution de l'état d'animation
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Lorsque la touche E est pressée, on met IsAttacking à true
            animator.SetBool("IsAttacking", true);
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            // Lorsque la touche E est relâchée, on remet IsAttacking à false
            animator.SetBool("IsAttacking", false);
        }
    }

    // Appelé lorsque l'état d'animation termine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Fin de l'attaque
        Debug.Log("Attaque terminée !");
        animator.SetBool("IsAttacking", false); // Assure que l'attaque est finie
    }
}
