using JetBrains.Annotations;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class damage : MonoBehaviour
{
    public PlayerHealth pHealth;
    public float Damage;

    CameraShake camShake;
    void Start()
    {
        camShake = FindAnyObjectByType<CameraShake>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collide with player");
            pHealth.health -= Damage;
            StartCoroutine(camShake.Shake(.15f, .15f));

        }
    }
}
