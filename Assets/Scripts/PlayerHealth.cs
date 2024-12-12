using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxhealth = 100;
    public Image HealthBar;

    internal void TakeDamage(float v)
    {
        throw new NotImplementedException();
    }

    void Start()
    {
        health = maxhealth;
    }

    void Update()
    {
        HealthBar.fillAmount = Mathf.Clamp(health / maxhealth, 0, 1);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
