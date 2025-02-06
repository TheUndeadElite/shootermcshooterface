using JetBrains.Annotations;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class damage : MonoBehaviour
{
    public PlayerHealth pHealth;
    public float Damage;

    CameraShake camShake;

    private int FrameCounter;
    private const int checkFrames = 30;
    void Start()
    {
        camShake = FindAnyObjectByType<CameraShake>();

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            pHealth = player.GetComponent<PlayerHealth>();
        }
        else
        {
            Debug.LogError("Player not found! Make sure there is a player tagged with 'Player'.");
        }
    }

    void Update()
    {
        FrameCounter++;
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(FrameCounter > checkFrames)
            {
                if(pHealth != null)
                {
                    Debug.Log("applying damage");
                    pHealth.health -= Damage;
                }

                if(camShake != null)
                {
                    StartCoroutine(camShake.Shake(0.15f, 0.15f));
                }
                FrameCounter = 0;
            }
        }
    }
}
