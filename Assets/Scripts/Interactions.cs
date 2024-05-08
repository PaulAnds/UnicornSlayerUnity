using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions : MonoBehaviour
{
    public GameObject letterE;
    public PlayerHealth player;
    public EnemyStats dmg;
    public GameObject aoe;
    public Waves waves;
    public Animator anim;
    public RemovingBat interact;
    public HealthUI UI;

    public GameObject fence1;
    public GameObject fence2;

    public GameObject purchased;
    public GameObject needMoney;
    public GameObject pueblo;
    public GameObject pelea;


    private bool hitting;

    public bool health, healing, damage, tutorial, radio, start, notgaming;
    public int maxhealth = 5;


    private void Start()
    {
        UI = FindObjectOfType<HealthUI>();
        waves = FindObjectOfType<Waves>();
        player = GetComponent<PlayerHealth>();
        dmg = FindObjectOfType<EnemyStats>();
        notgaming = true;
        anim = FindObjectOfType<Animator>();
        interact = FindObjectOfType<RemovingBat>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && health)
        {
            Health();
        }
        if (Input.GetKeyDown(KeyCode.E) && healing)
        {
            Healing();
        }
        if (Input.GetKeyDown(KeyCode.E) && damage)
        {
            Damage();
        }
        if (Input.GetKeyDown(KeyCode.E) && tutorial)
        {
            Tutorial();
        }
        if (Input.GetKeyDown(KeyCode.E) && radio)
        {
            Radio();
        }
        if (Input.GetKeyDown(KeyCode.E) && start && notgaming)
        {
            Starting();
        }
        if (Input.GetMouseButtonDown(0) && hitting)
        {
            anim.SetBool("spin", true);
            Debug.Log(anim.GetBool("spin"));
            StartCoroutine(spin());
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "health" && interact.interact)
        {
            letterE.SetActive(true);
            health = true;
        }
        if (other.tag == "healing" && interact.interact)
        {
            letterE.SetActive(true);
            healing = true;
        }
        if (other.tag == "damage" && interact.interact)
        {
            letterE.SetActive(true);
            damage = true;
        }
        if (other.tag == "tutorial" && interact.interact)
        {
            letterE.SetActive(true);
            tutorial = true;
        }
        if (other.tag == "radio" && interact.interact)
        {
            letterE.SetActive(true);
            radio = true;
        }
        if (other.tag == "start")
        {
            if (waves.state == Waves.SpawnState.SPAWNING)
            {
                letterE.SetActive(true);
                start = true;
            }
        }

        if(other.tag == "Enemy")
        {
            hitting = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        letterE.SetActive(false);
        tutorial = false;
        damage = false;
        healing = false;
        health = false;
        radio = false;
        start = false;
        hitting = false;
        purchased.SetActive(false);
        needMoney.SetActive(false);
    }

    void Health()
    {
        if (player.money >= 10)
        {
            maxhealth += 1;
            player.money -= 10;
            UI.setmaxHealth(maxhealth);
            UI.sethealth(player.health);
            purchased.SetActive(true);
            Debug.Log("max health " + maxhealth);
        }
        else
        {
            needMoney.SetActive(true);
            Debug.Log("sorry not enough money");
        }
    }
    void Healing()
    {
        if (player.money >= 1)
        {
            
            player.health = maxhealth;
            UI.sethealth(maxhealth);
            player.money -= 1;
            Debug.Log("current health " + player.health);
            purchased.SetActive(true);
        }
        else
        {
            needMoney.SetActive(true);
            Debug.Log("sorry not enough money");
        }
    }
    void Damage()
    {
        if (player.money >= 5)
        {
            Debug.Log("damage up" + dmg.damage);
            dmg.damage += 1;
            player.money -= 5;
            purchased.SetActive(true);
        }
        else
        {
            needMoney.SetActive(true);
            Debug.Log("sorry not enough money");
        }
    }
    void Tutorial()
    {
        Debug.Log("tutorial");
    }
    void Radio()
    {
        if (player.money >= 30)
        {
            player.money -= 30;
            Debug.Log("aoe up" + aoe.transform.localScale.x);
            aoe.transform.localScale = aoe.transform.localScale + new Vector3(.5f, 0f, 0f);
            purchased.SetActive(true);

        }
        else
        {
            needMoney.SetActive(true);
            Debug.Log("sorry not enough money");
        }
    }
    void Starting()
    {
        interact.interact = false;
        fence1.SetActive(true);
        fence2.SetActive(true);
        notgaming = false;
        waves.state = Waves.SpawnState.COUNTING;
        waves.nextwave = 0;
        pueblo.SetActive(false);
        pelea.SetActive(true);
    }


    IEnumerator spin()
    {
        yield return new WaitForSecondsRealtime(.73f);
        anim.SetBool("spin", false);
        Debug.Log(anim.GetBool("spin"));
    }
}
