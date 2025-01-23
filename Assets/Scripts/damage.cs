using UnityEngine;

public class damage : MonoBehaviour
{
    public PlayerHealth pHealth;
    public float Damage;
    void Start()
    {

    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pHealth.health -= Damage;
        }
    }
}
