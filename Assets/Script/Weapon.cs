using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();        // 버튼을 누를 때마다 사격
        }
    }

    private void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    // 사용자 지정 파티클 시스템 적용 
    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            // 특정 물체 명중 시 시각적 피드백 
            Debug.Log(hit.transform.name + "공");

            // 적의 수명 감소
            EnermyHealth target = hit.transform.GetComponent<EnermyHealth>();
            if (target == null) return;     // 적이 아닌 다른 물체를 타격했을 경우의 예외 처리
            target.TakeDamage(damage);      // 무기 사용 시 30만큼의 damage
        }

        // Null Reference Exception 오류 방지
        else
        {
            return;
        }
        
    }

}
