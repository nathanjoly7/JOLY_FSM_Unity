using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    // Appel� lorsque l'�tat d'animation commence � s'ex�cuter
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // D�clenchement d'attaque au d�but de l'�tat
        Debug.Log("Attaque commenc�e !");
    }

    // Appel� � chaque frame pendant l'ex�cution de l'�tat d'animation
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Lorsque la touche E est press�e, on met IsAttacking � true
            animator.SetBool("IsAttacking", true);
        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            // Lorsque la touche E est rel�ch�e, on remet IsAttacking � false
            animator.SetBool("IsAttacking", false);
        }
    }

    // Appel� lorsque l'�tat d'animation termine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Fin de l'attaque
        Debug.Log("Attaque termin�e !");
        animator.SetBool("IsAttacking", false); // Assure que l'attaque est finie
    }
}
