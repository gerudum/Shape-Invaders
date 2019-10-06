using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public Transform player;

    [HideInInspector]
    public Wave current;

    [HideInInspector]
    public List<Wave> currentPool;

    public List<Wave> wavePool;

    public Wave.Difficulty difficulty = Wave.Difficulty.Easy;

    public float spawnRadius = 20f;

    public int wave = 0;
    public int bonusThreshold = 2;

    public int totalEnemiesKilled;

    private int enemiesKilled = 0;
    private int enemyThreshold = 0;
    public void Awake()
    {
        instance = this;
    }

    public void Start()
    {
        NextWave();
    }

    public void EnemyKilled()
    {
        totalEnemiesKilled += 1;
        enemiesKilled += 1;

        if(totalEnemiesKilled >= 30)
        {
            difficulty = Wave.Difficulty.Normal;
        }
        if(totalEnemiesKilled >= 80)
        {
            difficulty = Wave.Difficulty.Hard;
        }
        if(totalEnemiesKilled >= 150)
        {
            difficulty = Wave.Difficulty.Insane;
        }

        if(enemiesKilled >= enemyThreshold)
        {
            NextWave();
        }
        
    }

    public void NextWave()
    {
        GetPool();
        current = GetWave();
        enemyThreshold = current.enemies;
        enemiesKilled = 0;

        wave += 1;
        if(wave > bonusThreshold)
        {
            EffectManager.instance.EnableCards();
            bonusThreshold = wave + 3;
        }

        StartCoroutine("SpawnWave");
    }

    public void GetPool()
    {
        currentPool.Clear();
        foreach(Wave wave in wavePool)
        {
            if(wave.difficulty == difficulty)
            {
                currentPool.Add(wave);
            }
        }
    }

    public Wave GetWave()
    {
        float top = 0;
        float total = 0;

        for(int i = 0; i < currentPool.Count; i++)
        {
            total += currentPool[i].weight;
        }

        float rand = Random.Range(0, total);
        for(int i = 0; i < currentPool.Count; i++)
        {
            top += currentPool[i].weight;

            if (rand <= top)
            {
                return currentPool[i];
            }
        }

        Debug.LogError("Return a null wave, something went wrong");
        return null;
    }
    public Wave.Spawn GetEnemy()
    {
        float top = 0;
        float total = 0;

        for (int i = 0; i < current.spawns.Length; i++)
        {
            total += current.spawns[i].weight;
        }

        float rand = Random.Range(0, total);
        for (int i = 0; i < current.spawns.Length; i++)
        {
            top += current.spawns[i].weight;

            if (rand <= top)
            {
                return current.spawns[i];
            }
        }

        Debug.LogError("Return a null Spawn, something went wrong");
        return null;
    }

    public IEnumerator SpawnWave()
    {
        int totalSpawned = 0;
 

        while (totalSpawned < enemyThreshold)
        {
            Wave.Spawn spawn = GetEnemy();

            GameObject newEnemy = Instantiate(spawn.enemy, RandomPoint(), spawn.enemy.transform.rotation);
            newEnemy.AddComponent<Spawn>();

            totalSpawned += 1;
            yield return new WaitForSeconds(current.delay);
        }  
    }

    public Vector3 RandomPoint()
    {
        Vector2 point = Random.insideUnitCircle * spawnRadius;
        Vector2 minDistance = new Vector2(10f, 10f);

        if (player == null) return point;
        
        Vector3 newPoint = new Vector3(player.position.x + point.x + minDistance.x, player.position.y + point.y + minDistance.y, 0);
        return newPoint;
    }

    public GameObject gameOver;
    public Text score;
    public void GameOver()
    {
        gameOver.SetActive(true);
        score.text = "Score: " + totalEnemiesKilled.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
