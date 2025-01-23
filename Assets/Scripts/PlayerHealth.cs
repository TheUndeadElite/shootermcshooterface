using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxhealth = 100;
    public Image HealthBar;

    damage damagescript;
    void Start()
    {
        health = maxhealth;
    }

    void Update()
    {
        HealthBar.fillAmount = Mathf.Clamp(health / maxhealth, 0, 1);

        if (health <= 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
