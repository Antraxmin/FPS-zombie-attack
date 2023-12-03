using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public Text healthText;

    private int maxHealth = 100; // 최대 체력
    private int currentHealth = 100; // 현재 체력

    void Start()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        float healthPercentage = (float)currentHealth / maxHealth;
        healthBar.fillAmount = healthPercentage;

        healthText.text = $"Health: {currentHealth}/{maxHealth}";
    }

    // 플레이어의 체력 감소 
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 최소값 0, 최대값 maxHealth로 제한
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Debug.Log("사망");
        }
    }

    // 플레이어 체력 회복
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // 최대값 maxHealth로 제한
        UpdateHealthBar();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            TakeDamage(10);    // 플레이어 체력 테스트 코드         
        }
        UpdateHealthTextRealtime();
        UpdateHealthBar();
    }

    public void UpdateHealthTextRealtime()
    {
        // 현재 체력 값을 실시간으로 업데이트
        healthText.text = $"Health: {currentHealth}/{maxHealth}";
    }



}
