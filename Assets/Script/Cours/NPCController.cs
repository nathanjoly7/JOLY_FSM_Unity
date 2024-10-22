using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{

    [SerializeField] private GameObject target;
    private NavMeshAgent agent;
    private Animator animator;

    private void Start()
    {
    agent = GetComponent<NavMeshAgent>();
    agent.SetDestination(target.transform.position);
    animator = GetComponent<Animator> ();
    }

    private void Update()
    {
        if (agent != null)
        {
            float speed = agent.velocity.magnitude;
            animator.SetFloat("Speed", speed);
        }
    }
}
