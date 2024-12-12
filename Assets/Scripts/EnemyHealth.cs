using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;

    public GameObject deathEffect;

    public void TakeDamage (int damage)
    {
        health -= damage;


        if (health <= 0)
        {
            Die();
        }
    }

    void Die ()
    {
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
