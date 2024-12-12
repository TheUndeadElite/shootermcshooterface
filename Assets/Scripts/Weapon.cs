using UnityEngine;
using UnityEngine.Rendering;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float knockbackForce = 5f;
    public Rigidbody2D rb;

    public Animator camAnim;
   

    public AudioClip m_GunShotSounds; //So the shots don't sound the same every time
    public AudioSource m_AudioSource; //The thing to play the audio

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        m_AudioSource = GetComponent<AudioSource>();

        if (m_AudioSource == null)
        {
            Debug.LogError("No AudioSource found");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Shoot();
        }
    }
    void KnockBack ()
    {
        Vector2 knockbackDirection = -transform.right;

        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        PlayShootingSound();

        camAnim.SetTrigger("Shake");

        KnockBack();

    }

    void PlayShootingSound()
    {
        if (m_GunShotSounds != null) // Check if the audio clip is assigned
        {
            m_AudioSource.pitch = Random.Range(0.9f, 1.1f);
            m_AudioSource.PlayOneShot(m_GunShotSounds); // Play the assigned sound
        }
        else
        {
            Debug.LogWarning("No gunshot sound assigned.");
        }
    }

}
