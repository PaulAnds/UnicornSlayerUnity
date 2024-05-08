using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    [System.Serializable]
    public class wave
    {
        public GameObject prefab;
        public int count;
        public float rate;
    }
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    public wave[] waves;
    public int nextwave = 0;

    public Transform[] spawnpoint;

    public float timeBetweenWaves = 5f;
    public float waveCountdown = 0f;

    public SpawnState state = SpawnState.SPAWNING;

    private float searchCountdown = 1.0f;

    public Interactions interactions;
    public RemovingBat interact;
    public EnemyStats enemy;
    public int waveNumber = 1;

    private void Start()
    {
        if (spawnpoint.Length == 0)
        {
            Debug.LogError("No spawnpoint referenced");
        }

        enemy = FindObjectOfType<EnemyStats>();
        waveCountdown = timeBetweenWaves;
        interactions = FindObjectOfType<Interactions>();
        interact = FindObjectOfType<RemovingBat>();
    }

    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (EnemyisAlive() == false)
            {
                WaveCompleated();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[nextwave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleated()
    {
        //begin a new round
        Debug.Log("wave compleated");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextwave + 1 > waves.Length - 1)
        {
            state = SpawnState.SPAWNING;
            for (int i = 0; i < 3; i++)
            {
                this.waves[i].count += 5;
                this.waves[i].rate += 5;
                enemy.enemyhealth += 2;
                interactions.notgaming = true;
                interact.interact = true;
                interactions.fence1.SetActive(false);
                interactions.fence2.SetActive(false);
                interactions.pueblo.SetActive(true);
                interactions.pelea.SetActive(false);
            }
            waveNumber++;
            Debug.Log("Compleated all waves!!");
        }
        else
        {
            nextwave++;
            waveNumber++;
        }

    }

    bool EnemyisAlive()
    {
        //every second it will check if there are enemies in the map
        searchCountdown -= Time.deltaTime;

        if (searchCountdown <= 0)
        {
            searchCountdown = 1.0f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                Debug.Log("Found no enemies");
                return false;
            }
        }
        Debug.Log("found enemies");
        return true;
    }

    IEnumerator SpawnWave(wave _wave)
    {
        //Debug.Log("Spawning wave: " + _wave.name);
        state = SpawnState.SPAWNING;
        //spawn


        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.prefab);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;
        yield break;
    }

    void SpawnEnemy(GameObject _enemy)
    {
        Transform sp = spawnpoint[Random.Range(0, spawnpoint.Length)];


        Instantiate(_enemy, sp.position, sp.rotation);
        //spawn enemy
        Debug.Log("Spawning enemy: " + _enemy.name);
    }

}
