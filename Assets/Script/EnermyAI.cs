using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnermyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;       //  네비메쉬 에이전트 호출

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        navMeshAgent.SetDestination(target.position);
    }
}
