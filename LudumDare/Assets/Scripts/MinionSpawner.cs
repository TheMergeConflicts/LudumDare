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
        obj.GetComponent<MinionStats>().direction = sStats.direction;
    }


    void restartTimer()
    {
        respawnTimer = Random.Range(respawnTimeMin, respawnTimeMax);

    }
}
