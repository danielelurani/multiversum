using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterStats : MonoBehaviour

{

    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected bool isDead;

    public HealthBar healthBar;


    private void Start()
    {
        maxHealth = 100;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        isDead = false;
    }

    void Update()
    {
        CheckHealth();
    }

    public void CheckHealth()
    {
        if(health <= 0)
        {
            health = 0;
            isDead = true;
            SceneManager.LoadScene("GameOverScene");

        }

        if(health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public void Die()
    {
        isDead = true;
    }

    public void SetHealthTo (int healthToSetTo)
    {
        health = healthToSetTo;

    }

    public void TakeDamage (int damage)
    {
        health = health - damage;
        healthBar.SetHealth(health);
    }

    public void Heal(int heal)
    { 
     int healthAfterHeal = health + heal;
    }
}
