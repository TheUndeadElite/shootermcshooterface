using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxhealth = 100;
    public Image HealthBar;

    public Animator camAnim;

    void Start()
    {
        //camAnim = GameObject.Find("Main Camera").GetComponent<Animator>();

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
