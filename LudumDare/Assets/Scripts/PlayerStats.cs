using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
    public int age;
    public float health;
    


    void Update()
    {
        health = Mathf.MoveTowards(health, 0, Time.deltaTime);
    }
}
