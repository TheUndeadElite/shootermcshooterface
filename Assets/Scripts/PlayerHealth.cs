using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxhealth;
    public Image HealthBar;

    internal void TakeDamage(float v)
    {
        throw new NotImplementedException();
    }

    void Start()
    {
        maxhealth = health;
    }

    void Update()
    {
        HealthBar.fillAmount = Mathf.Clamp(health / maxhealth, 0, 1);
    }
}
