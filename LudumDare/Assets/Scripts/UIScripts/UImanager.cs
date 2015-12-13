using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UImanager : MonoBehaviour {
    public Text ageText;
    public Slider healthBar;

    PlayerStats playerStats;


	// Use this for initialization
	void Start () {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
        ageText.text = "Age: " + playerStats.age;
        healthBar.value = playerStats.health;
	}
}
