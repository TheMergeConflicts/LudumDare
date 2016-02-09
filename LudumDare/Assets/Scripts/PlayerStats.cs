using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
    public int age;
    public float health;
    public float yearTime = 5;

    public int historyHighAge;
    public int historyHighCombo;

    public ComboMultiplier comboManager;
	public UImanager UImanager;
    

    float maxHealth;
    float ageTimer;
    float deteriationRate = 1.3f;
    float initDeteriationRate = 1.3f;
    MinionSpawner spawner;

    void Start()
    {
        historyHighAge = PlayerPrefs.GetInt("HighestAge");
        historyHighCombo = PlayerPrefs.GetInt("HighestCombo");
        this.maxHealth = this.health;
        ageTimer = yearTime;
        spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<MinionSpawner>();
    }

    public void reset()
    {
        spawner.resetRespawnTime();
        deteriationRate = initDeteriationRate;
    }

    void Update()
    {
        //print(health);
		if(UImanager.currentState == UImanager.UIState.inGame){
			health = Mathf.MoveTowards(health, 0, Time.deltaTime * deteriationRate);
			updateAge();
		}

		//Health Alarm


		if(health <= 0f && UImanager.currentState == UImanager.UIState.inGame){

            if (age > historyHighAge)
            {
                historyHighAge = age;
                PlayerPrefs.SetInt("HighestAge", historyHighAge);
            }
            if (comboManager.highestCombo > historyHighCombo)
            {
                historyHighCombo = comboManager.highestCombo;
                PlayerPrefs.SetInt("HighestCombo", historyHighCombo);
            }

			UImanager.finalAge = age;
			UImanager.StartEndAnimation ();

		}
    }

    void updateAge ()
    {
        ageTimer = Mathf.MoveTowards(ageTimer, 0, Time.deltaTime);
        if (ageTimer <= 0)
        {
            ageTimer = yearTime;
            age++;
            spawner.increaseSpawnRate();
			if(deteriationRate < 8.5f){
				deteriationRate *= 1.03f;
			}
            
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
