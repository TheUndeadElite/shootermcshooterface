using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Playermovement playerMovement;
    public bool flip;
    public float speed;

    private void Start()
    {
        playerMovement = FindFirstObjectByType<Playermovement>();

        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement script not found in the scene!");
        }
    }

    private void Update()
    {
        if (playerMovement == null)
        {
            Debug.LogWarning("PlayerMovement script is missing, can't follow the player.");
            return;
        }

        Vector3 scale = transform.localScale;
        Vector3 playerPosition = playerMovement.transform.position;

        // Move the enemy towards the player's position
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, step);

        // Flip the enemy based on the player's position
        if (playerPosition.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
        }

        transform.localScale = scale;
    }
}
