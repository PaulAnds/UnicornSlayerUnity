using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    public PlayerHealth money;
    private Text scoreText;

    private void Start()
    {
        money = FindObjectOfType<PlayerHealth>();
        scoreText = GetComponent<Text>();
    }

    private void Update()
    {
        if (money.money < 0)
        {
            money.money = 0;
        }
        scoreText.text = "" + money.money;
    }
}
