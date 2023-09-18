using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] float maxHealth = 5f;
    [HideInInspector] public float currentHealth;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        MaintainHealth();
    }

    private void MaintainHealth()
    {
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Damage(float damage)
    {
        currentHealth -= damage;
    }

    public void Heal(float healing)
    {
        currentHealth += healing;
    }
}
