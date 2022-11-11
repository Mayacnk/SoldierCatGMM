using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AgentScript : MonoBehaviour
{
    [SerializeField] public Transform target;

    private NavMeshAgent agent;

    private void Start()
    {
        //target takip edilecek obje;
        //target = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updatePosition = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
      if(target!=null)  agent.SetDestination(target.position);
    }
}
