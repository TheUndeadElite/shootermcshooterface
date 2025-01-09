using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 25;
    public Rigidbody2D rb;

    [SerializeField] GameObject BulletParticleEffect;

    public float spreadAngle = 5f;
    public float pushForce = 10f;  // Force to push the enemy back

    void Start()
    {
        float randomSpread = Random.Range(-spreadAngle, spreadAngle);
        Vector2 direction = Quaternion.Euler(0, 0, randomSpread) * transform.right;

        rb.linearVelocity = direction * speed;  // Use 'velocity' instead of 'linearVelocity'
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null && hitInfo.CompareTag("Enemy"))
        {
            // Apply damage to the enemy
            enemy.TakeDamage(damage, transform.position);

            // Apply force to push the enemy back
            Rigidbody2D enemyRb = hitInfo.GetComponent<Rigidbody2D>();
            if (enemyRb != null)
            {
                Vector2 pushDirection = hitInfo.transform.position - transform.position;
                pushDirection.Normalize();  // Make sure the push direction is unit length

                enemyRb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);  // Apply the push force
            }

            GameManager.Instance.TriggerTimeFreeze(0.2f);
            Destroy(gameObject);  // Destroy the bullet after impact
            Instantiate(BulletParticleEffect, transform.position, Quaternion.identity);
        }
        else
        {
            Destroy(gameObject, 2f);  // Destroy the bullet if it doesn't hit an enemy
        }
    }

    private Quaternion CalculateImpactRotation(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0f, 0f, angle);
    }
}
