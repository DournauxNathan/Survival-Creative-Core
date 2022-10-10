using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Base class for all 'Unit', Object that will be control by the player. It will handle movement order given through the UserControl script.
// It require a NavMeshAgent to navigate the scene
[RequireComponent(typeof(NavMeshAgent))]
public class Unit : MonoBehaviour
{
    public float speed;

    protected NavMeshAgent m_Agent;

    
    void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.speed = speed;
        m_Agent.acceleration = 999;
        m_Agent.angularSpeed = 999;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void GoTo(Vector3 position)
    {
        //we don't have a target anymore if we order to go to a random point.
        m_Agent.SetDestination(position);
        m_Agent.isStopped = false;
    }
}
