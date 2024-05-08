using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    public PlayerHealth money;
    public EnemyStats enemystat;

    public bool hitting = false;
    public int health;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Cube");
        agent = GetComponent<NavMeshAgent>();
        money = FindObjectOfType<PlayerHealth>();
        enemystat = FindObjectOfType<EnemyStats>();

        health = enemystat.enemyhealth;
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.transform.position;
        if (health <= 0)
        {
            money.money += 1;
            Debug.Log("$" + money.money);
            Destroy(gameObject);
        }
        if (Input.GetMouseButtonDown(0) && hitting)
        {
            health -= enemystat.damage;
            Debug.Log("hit");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bat")
        {
            Debug.Log("HITTING ENABLED");
            hitting = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        hitting = false;
    }
}