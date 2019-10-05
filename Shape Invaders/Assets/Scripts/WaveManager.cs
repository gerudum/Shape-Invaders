using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public void Awake()
    {
        instance = this;
    }


    public Transform player;

    [HideInInspector]
    public Wave current;

    public List<Wave> wavePool;

    public float spawnRadius = 20f;

    public int enemiesKilled = 0;
    public int enemyThreshold = 10;
 
    public void EnemyKilled()
    {
        enemiesKilled += 1;
        if(enemiesKilled >= enemyThreshold)
        {
            NextWave();
        }
    }

    public void NextWave()
    {
        current = GetWave();
        SpawnWave();
    }

    public Wave GetWave()
    {
        float top = 0;
        float total = 0;

        for(int i = 0; i < wavePool.Count; i++)
        {
            total += wavePool[i].weight;
        }

        float rand = Random.Range(0, total);
        for(int i = 0; i < wavePool.Count; i++)
        {
            top += wavePool[i].weight;
            if(rand >= top)
            {
                return wavePool[i];
            }
        }

        Debug.LogError("Return a null wave, something went wrong");
        return null;
    }

    public void SpawnWave()
    {
        GameObject newEnemy = Instantiate(current.enemy, RandomPoint(), current.enemy.transform.rotation);
        newEnemy.AddComponent<Spawn>();
    }

    public Vector3 RandomPoint()
    {
        Vector2 point = Random.insideUnitCircle * spawnRadius;
        Vector3 newPoint = new Vector3(player.position.x + point.x, player.position.y + point.y, 0);
        return newPoint;
    }
}
