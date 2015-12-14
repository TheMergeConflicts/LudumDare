using UnityEngine;
using System.Collections;

public class MinionSpawner : MonoBehaviour {
    public GameObject[] minions;
    public SpawnStats[] spawners;
    public float respawnTimeMin;
    public float respawnTimeMax;
   
    float respawnTimer;
    
    void Start()
    {
        restartTimer();
    }

    void Update()
    {
        respawnTimer = Mathf.MoveTowards(respawnTimer, 0, Time.deltaTime);
        if (respawnTimer <= 0)
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
        if (respawnTimeMin < 1)
        {
            respawnTimeMin = 1;
        }
        if (respawnTimeMax < 2)
        {
            respawnTimeMax = 2;
        }
    }


    void restartTimer()
    {
        respawnTimer = Random.Range(respawnTimeMin, respawnTimeMax);

    }
}
