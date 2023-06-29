using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour

{

    [SerializeField] public int health;
    [SerializeField] public int maxHealth;
    [SerializeField] protected bool isDead;
    [SerializeField] private AudioSource hitEffect;

    public HealthBar healthBar;
    private Image redSplatterImage;
    Color splatterAlpha;
    


    private void Start()
    {
        maxHealth = 100;
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        isDead = false;
        redSplatterImage = GameObject.Find("DamageEffectCanvas").GetComponentInChildren<Image>();
        hitEffect = GetComponent<AudioSource>();

        splatterAlpha = redSplatterImage.color;
    }

    void Update()
    {
        CheckHealth();
        healthBar.SetHealth(health);
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
        hitEffect.Play();
        splatterAlpha.a = 1;
        redSplatterImage.color = splatterAlpha;
        StartCoroutine(DamageEffect());

        health = health - damage;
        healthBar.SetHealth(health);
    }

    public void Heal(int heal)
    { 
     int healthAfterHeal = health + heal;
    }

    // funzione che fa scomparire lentamente l'effetto del danno sullo schermo
    private IEnumerator DamageEffect(){

        while(splatterAlpha.a >= 0){
            yield return new WaitForSeconds(0.02f);
            splatterAlpha.a = splatterAlpha.a - 0.01f;
            redSplatterImage.color = splatterAlpha;
        }
    }
}
