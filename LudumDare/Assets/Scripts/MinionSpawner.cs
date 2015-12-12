using UnityEngine;
using System.Collections;

public class MinionSpawner : MonoBehaviour {
    public GameObject[] minions;
    public float respawnTimeMin;
    public float respawnTimeMax;
    public Vector2 direction;

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
        GameObject obj = (GameObject)Instantiate(minions[Random.Range(0, minions.Length)], transform.position, new Quaternion());
        obj.GetComponent<MinionStats>().direction = direction;
    }


    void restartTimer()
    {
        respawnTimer = Random.Range(respawnTimeMin, respawnTimeMax);

    }
}
