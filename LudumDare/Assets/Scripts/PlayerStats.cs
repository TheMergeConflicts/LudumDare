using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
    public int age;
    public float health;
    public float yearTime = 5;


    float maxHealth;
    float ageTimer;
    float deteriationRate = .5f;
    MinionSpawner spawner;

    void Start()
    {
        this.maxHealth = this.health;
        ageTimer = yearTime;
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<MinionSpawner>();
    }

    void Update()
    {
        print(health);
        health = Mathf.MoveTowards(health, 0, Time.deltaTime * deteriationRate);
        updateAge();
    }

    void updateAge ()
    {
        ageTimer = Mathf.MoveTowards(ageTimer, 0, Time.deltaTime);
        if (ageTimer <= 0)
        {
            ageTimer = yearTime;
            age++;
            spawner.increaseSpawnRate();
            deteriationRate *= 1.03f;
        }

    }

    public void updateHealth(float health)
    {
        this.health += health;
        if (this.health > maxHealth)
        {
            this.health = maxHealth;
        }
    }
}
