using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomWalk : StateMachineBehaviour
{
    NavMeshAgent agent;
    public float RandomPointRange = 5; // Le rayon autour de soi où un point sera sélectionné

    // OnStateEnter est appelé quand une transition commence et que le state machine commence à évaluer cet état
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 2;

        // Générer et aller vers un point aléatoire au début du state
        Vector3 randomPoint = GetRandomPointAroundSelf(animator.transform.position, RandomPointRange);
        agent.SetDestination(randomPoint);
    }

    // OnStateUpdate est appelé sur chaque frame Update entre OnStateEnter et OnStateExit
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Si l'agent atteint son point de destination, choisir un autre point
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 randomPoint = GetRandomPointAroundSelf(animator.transform.position, RandomPointRange);
            agent.SetDestination(randomPoint);
        }
    }

    // OnStateExit est appelé quand une transition se termine et que le state machine finit d'évaluer cet état
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position); // Stopper le mouvement
    }

    // Fonction pour obtenir un point aléatoire autour du transform de l'agent dans un rayon donné
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
            return origin; // Si un point valide n'est pas trouvé, rester à la position actuelle
        }
    }
}
