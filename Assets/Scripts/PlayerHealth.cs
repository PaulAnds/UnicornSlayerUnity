using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public GameObject deadScreen;
    public HealthUI ui;

    public int health = 5;
    public int health2;
    public int money = 0;
   // bool touching = false;

    private void Start()
    {
        health2 = health;
        ui = FindObjectOfType<HealthUI>();
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (health <= 0)
        {
            deadScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
       // touching = false;
        health2 = 0;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            health2 = health;
            health -= 1;
            ui.sethealth(health);
            Debug.Log("ouch");
            Debug.Log(health);
        }
    }

}
