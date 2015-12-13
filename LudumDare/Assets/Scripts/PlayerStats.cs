using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
    public int age;
    public float health;
    public float yearTime = 5;


    float maxHealth;
    float ageTimer;

    void Start()
    {
        this.maxHealth = this.health;
        ageTimer = yearTime;

    }

    void Update()
    {
        health = Mathf.MoveTowards(health, 0, Time.deltaTime);
        updateAge();
    }

    void updateAge ()
    {
        ageTimer = Mathf.MoveTowards(ageTimer, 0, Time.deltaTime);
        if (ageTimer <= 0)
        {
            ageTimer = yearTime;
            age++;
        }

    }

    public void updateHealth(float health)
    {
        this.health += health;
        if (this.health > 100)
        {
            this.health = 100;
        }
    }
}
