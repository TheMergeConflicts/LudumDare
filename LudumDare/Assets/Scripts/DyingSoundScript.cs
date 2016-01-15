using UnityEngine;
using System.Collections;

public class DyingSoundScript : MonoBehaviour {
    public float timeBetweenBlips = 1.2f;
    public float lowHealthValue = 25;

    bool isActive;
    float blipTimer;
    PlayerStats playerStats;
    AudioSource aSource;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        playerStats = transform.parent.GetComponent<PlayerStats>();
        resetTimer();
    }

    void Update()
    {
        if (checkDyingSoundActive())
        {
            blipTimer = Mathf.MoveTowards(blipTimer, 0, Time.deltaTime);
            if (blipTimer <= 0)
            {
                aSource.Play();
                resetTimer();
            }
        }
        else
        {
            resetTimer();
        }
    }

    bool checkDyingSoundActive()
    {
        return playerStats.health < lowHealthValue;
    }

    void resetTimer()
    {
        blipTimer = timeBetweenBlips;
    }

}
