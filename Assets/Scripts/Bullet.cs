using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 25;
    public Rigidbody2D rb;

    public float spreadAngle = 5f;

    void Start()
    {
        float randomSpread = Random.Range(-spreadAngle, spreadAngle);
        Vector2 direction = Quaternion.Euler(0, 0, randomSpread) * transform.right;

        rb.linearVelocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if (enemy != null && hitInfo.tag == "Enemy")
        {

            enemy.TakeDamage(damage);
            GameManager.Instance.TriggerTimeFreeze(0.2f);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 2f);
        }
    }

    private Quaternion CalculateImpactRotation(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0f, 0f, angle);
    }
}
