using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 50f;

    // Calcola danno su nemico
    public void TakeDamage(float amount){
        health -= amount;

        if(health <= 0f){
            Die();
        }
    }

    // Distrugge l'oggetto di gioco
    void Die(){

        Destroy(gameObject);
    }
}
