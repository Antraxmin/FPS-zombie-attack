using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnermyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 5f;     // 추적 범위 설정 

    NavMeshAgent navMeshAgent;       //  네비메쉬 에이전트 호출
    float distanceToTarget = Mathf.Infinity;    

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        // 타겟과의 거리 - 추적 범위 값 비교 
        if (distanceToTarget <= chaseRange)
        {
            navMeshAgent.SetDestination(target.position);
        }
    }
}
