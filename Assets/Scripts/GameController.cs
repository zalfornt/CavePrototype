using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject enemy;

    private Vector2 spawnLocation;

    public int spawnLimit;
    public int enemyNum;

    public float countdownTimer;
    private float countdownTime;
    private float enemyType;

    private bool spawnStart;
    // Start is called before the first frame update
    void Start()
    {
        spawnStart = true;
        countdownTime = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        Restart();
        if (spawnStart)
        {
            StartCoroutine("SpawnWave");
            spawnStart = false;
        }

        if (countdownTimer <= 0 && !spawnStart && enemyNum <= 0)
        {
            countdownTimer += countdownTime;
            spawnStart = true;
        }

        if (enemyNum <= 0)
        {
            countdownTimer -= 1 * Time.deltaTime;
            if (countdownTimer == 0)
            {
                return;
            }
        }
    }

    private void Restart()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < spawnLimit; i++)
        {
            SpawnEnemy();
            yield return new WaitForSecondsRealtime(1f);
        }
    }

    void SpawnEnemy()
    {
        enemyType = Random.value;
        spawnLocation = spawners[Random.Range(0, 4)].transform.position;

        if (enemyType <= 0.5)
        {
            enemy.GetComponent<Enemy>().enemyType = 1;
            enemy.GetComponent<Enemy>().attackDistance = 1.05f;
            enemy.GetComponent<SpriteRenderer>().color = Color.red;
            Instantiate(enemy, spawnLocation, Quaternion.identity);
        }
        else
        {
            enemy.GetComponent<Enemy>().enemyType = 2;
            enemy.GetComponent<Enemy>().attackDistance = 3;
            enemy.GetComponent<SpriteRenderer>().color = Color.magenta;
            Instantiate(enemy, spawnLocation, Quaternion.identity);
        }

        enemyNum++;
    }
}
