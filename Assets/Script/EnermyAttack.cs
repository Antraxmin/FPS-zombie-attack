using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyAttack : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float damage = 40f;
    
    void Start()
    {
        
    }

    // 플레이어 공격 코드
    public void AttackHitEvent()
    {
        // 타겟이 존재하지 않을 경우 미확인 값 방지
        if (target == null) return;
        Debug.Log("bang bang");
    }
}
