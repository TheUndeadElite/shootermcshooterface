using TMPro;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    private int score = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            score += 100;

            UpdateScoreText();

            Destroy(gameObject);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
