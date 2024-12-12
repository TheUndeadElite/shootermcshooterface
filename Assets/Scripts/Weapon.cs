using UnityEngine;
using UnityEngine.Rendering;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;

    public AudioClip m_GunShotSounds; //So the shots don't sound the same every time
    public AudioSource m_AudioSource; //The thing to play the audio

    private void Start()
    {
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

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        PlayShootingSound();
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
