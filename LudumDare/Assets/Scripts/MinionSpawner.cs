using UnityEngine;
using System.Collections;

public class MinionSpawner : MonoBehaviour {
    public GameObject[] minions;
    public SpawnStats[] spawners;
    public float respawnTimeMin;

    bool spawning;
    float initMin;
    public float respawnTimeMax;
    float initMax;
   
    float respawnTimer;
    
    void Start()
    {
        spawning = false;
        restartTimer();
        initMin = respawnTimeMin;
        initMax = respawnTimeMax;
    }

    public void resetRespawnTime()
    {
        respawnTimeMin = initMin;
        respawnTimeMax = initMax;
    }

    void Update()
    {
        respawnTimer = Mathf.MoveTowards(respawnTimer, 0, Time.deltaTime);
        if (respawnTimer <= 0 && spawning)
        {
            restartTimer();
            createMinion();
        }

    }

    void createMinion()
    {
        SpawnStats sStats = spawners[Random.Range(0, spawners.Length)];
        GameObject obj = (GameObject)Instantiate(minions[Random.Range(0, minions.Length)], sStats.transform.position, new Quaternion());
        MinionStats mStats = obj.GetComponent<MinionStats>();
        mStats.direction = sStats.direction;
        mStats.setGoalDown();
        mStats.initialSpawn = sStats.spawnPlatform;
    
        if (mStats.goalDown)
        {
            mStats.goal = sStats.downGoal;
        }
        else
        {
            mStats.goal = sStats.upGoal;
        }

    }

    public void increaseSpawnRate()
    {
        respawnTimeMax -= .05f;
        respawnTimeMin -= .05f;
        if (respawnTimeMin < 0.8f)
        {
            respawnTimeMin = 0.8f;
        }
		if (respawnTimeMax < 1.7f)
        {
            respawnTimeMax = 1.7f;
        }
    }


    void restartTimer()
    {
        respawnTimer = Random.Range(respawnTimeMin, respawnTimeMax);
    }

    public void StartSpawningMinions()
    {
        if (!spawning)
        {
            spawning = true;
        }
        
    }

    public void EndSpawningMinions()
    {
        if (spawning)
        {
            spawning = false;
        }
    }
}
