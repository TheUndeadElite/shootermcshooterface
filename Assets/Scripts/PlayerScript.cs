using TMPro;
using UnityEngine;
using UnityEngine.UI; 

public class PlayerScript : MonoBehaviour
{
    public Text scoreText;  
    private int score = 0;  

    void Start()
    {
        UpdateScoreText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin")) 
        {
            score += 100;

            UpdateScoreText();

            Destroy(other.gameObject);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
