using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomWalk : StateMachineBehaviour
{
    private NavMeshAgent agent;
    public float RandomPointRange = 5;
    public float detectionRadius = 10f; // Rayon de détection des ennemis

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 1.5f;
        Vector3 randomPoint = GetRandomPointAroundSelf(animator.transform.position, RandomPointRange);
        agent.SetDestination(randomPoint);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float speed = agent.velocity.magnitude;
        animator.SetFloat("Speed", speed);

        // Vérification de la proximité d'un objet avec le tag "Enemy"
        Collider[] hitColliders = Physics.OverlapSphere(agent.transform.position, detectionRadius);
        bool enemyDetected = false;

        foreach (var collider in hitColliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                enemyDetected = true;
                break;
            }
        }

        if (enemyDetected)
        {
            animator.SetBool("IsChasing", true); // Mettez IsChasing à true si un ennemi est détecté
        }
        else
        {
            animator.SetBool("IsChasing", false); // Remettez IsChasing à false si aucun ennemi n'est détecté
        }

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            Vector3 randomPoint = GetRandomPointAroundSelf(animator.transform.position, RandomPointRange);
            agent.SetDestination(randomPoint);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

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
            return origin;
        }
    }
}
