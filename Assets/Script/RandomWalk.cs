using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomWalk : StateMachineBehaviour
{
    NavMeshAgent agent;
    public float RandomPointRange = 5; // Le rayon autour de soi o� un point sera s�lectionn�

    // OnStateEnter est appel� quand une transition commence et que le state machine commence � �valuer cet �tat
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 2;

        // G�n�rer et aller vers un point al�atoire au d�but du state
        Vector3 randomPoint = GetRandomPointAroundSelf(animator.transform.position, RandomPointRange);
        agent.SetDestination(randomPoint);
    }

    // OnStateUpdate est appel� sur chaque frame Update entre OnStateEnter et OnStateExit
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Si l'agent atteint son point de destination, choisir un autre point
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 randomPoint = GetRandomPointAroundSelf(animator.transform.position, RandomPointRange);
            agent.SetDestination(randomPoint);
        }
    }

    // OnStateExit est appel� quand une transition se termine et que le state machine finit d'�valuer cet �tat
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position); // Stopper le mouvement
    }

    // Fonction pour obtenir un point al�atoire autour du transform de l'agent dans un rayon donn�
    private Vector3 GetRandomPointAroundSelf(Vector3 origin, float range)
    {
        Vector3 randomDirection = Random.insideUnitSphere * range;
        randomDirection += origin;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, range, 1))
        {
            return hit.position;
        }
        else
        {
            return origin; // Si un point valide n'est pas trouv�, rester � la position actuelle
        }
    }
}
