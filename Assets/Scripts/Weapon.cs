using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    //muzzleflash
    public GameObject gunpowder;

    public AudioClip m_GunShotSounds;
    public AudioSource m_AudioSource;

    public CameraShake camerashake;

    Rigidbody2D rb;

    Playermovement playermovement;

    private void Start()
    {
        playermovement = GetComponent<Playermovement>();
        rb = GetComponent<Rigidbody2D>();
        m_AudioSource = GetComponent<AudioSource>();



        if (m_AudioSource == null)
        {
            Debug.LogError("No AudioSource found");
        }


    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !playermovement.isShoting)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        if (gunpowder != null)
        {
            GameObject gunpowderInstance = Instantiate(gunpowder, firePoint.position, firePoint.rotation);
            Destroy(gunpowderInstance, 0.1f);
        }

        PlayShootingSound();
        StartCoroutine(ShootCor());
        rb.AddForce(-transform.right * 7, ForceMode2D.Impulse);
        StartCoroutine(camerashake.Shake(.15f, .15f));
    }

    void PlayShootingSound()
    {
        if (m_GunShotSounds != null)
        {
            m_AudioSource.volume = 0.07f;
            m_AudioSource.pitch = Random.Range(0.9f, 1.1f);
            m_AudioSource.PlayOneShot(m_GunShotSounds);
        }
        else
        {
            Debug.LogWarning("No gunshot sound assigned.");
        }
    }

    IEnumerator ShootCor()
    {
        playermovement.isShoting = true;
        yield return new WaitForSeconds(0.1f);
        playermovement.isShoting = false;
    }

    
}
