using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;    // 남은 수명

    // damage 수치만큼 hitPoints 감소
    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        // hitPoints가 0이 되면 사망
        if (hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
