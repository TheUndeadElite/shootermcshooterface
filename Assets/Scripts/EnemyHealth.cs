using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float health;

    public void TakeDamage(int damage, Vector2 damageSource)
    {
        health -= damage;


        Vector2 knockbackDirection = (transform.position - (Vector3)damageSource).normalized;
        GetComponent<Rigidbody2D>().AddForce(knockbackDirection * 2f, ForceMode2D.Impulse);  // Apply force for knockback

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
