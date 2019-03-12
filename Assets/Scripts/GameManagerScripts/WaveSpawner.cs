using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{


    // instance variables
    private float timeBetweenWaves = 5f; // time in seconds
    private float waveCountdown;
    private float searchCountdown = 1f;
    public int waveNum;
    public Transform enemy;
    private int enemyCount;
    private float delay = 2f;
    private enum SpawnState { SPAWINING, WAITING, COUNTING };
    private SpawnState state = SpawnState.COUNTING;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced.");
        }

        waveNum = 1;

        waveCountdown = timeBetweenWaves;

    }

    // Update is called once per frame
    void Update()
    {

        if (state == SpawnState.WAITING)
        {
            // check if enemies are still alive
            if (!EnemeyIsAlive())
            {
                // Begin next wave
                Debug.Log("Wave Completed");
                waveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWINING)
            {
                // start spawing wave
                StartCoroutine( SpawnWave() );
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    private void waveCompleted()
    {
        Debug.Log("Wave Completed!");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        waveNum++;
    }

    private bool EnemeyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Spawining Wave: " + waveNum);
        enemyCount = 5*waveNum;
        state = SpawnState.SPAWINING;

        // spawn
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy(enemy);
            Debug.Log("SPAWN");
            yield return new WaitForSeconds(delay);
        }

        state = SpawnState.WAITING;

        // must have a call to yield break
        yield break;
    }

    private void SpawnEnemy(Transform _enemy)
    {
        // spawn an enemy
        Debug.Log("Spawning Enemy: " + _enemy.name);
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
        
    }

}
