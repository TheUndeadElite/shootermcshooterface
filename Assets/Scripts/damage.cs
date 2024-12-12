using UnityEngine;

public class damage : MonoBehaviour
{
    public PlayerHealth pHealth;
    public float Damage;
    public Animator camAnim;
    void Start()
    {
        camAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            pHealth.health -= Damage;
            camAnim.SetTrigger("Shake");
        }
    }
}
