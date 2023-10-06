using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Movement : MonoBehaviour
{
    private Vector2 target = Vector2.zero;
    private NavMeshAgent agent;

    public float movespeed = 1;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (target != Vector2.zero)
            agent.SetDestination(target);
    }

    public void setTarget(Vector2 t_target)
    {
        target = t_target;
    }
}
