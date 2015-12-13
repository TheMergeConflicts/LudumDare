using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
    public int age;
    public float health;
    public float yearTime;

    float ageTimer;


    void Update()
    {
        health = Mathf.MoveTowards(health, 0, Time.deltaTime);
    }

    void updateAge ()
    {
        ageTimer = Mathf.MoveTowards(ageTimer, 0, Time.deltaTime);
        if (ageTimer <= 0)
        {

        }
    }
}
