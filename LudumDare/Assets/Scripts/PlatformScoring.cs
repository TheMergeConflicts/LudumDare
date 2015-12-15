using UnityEngine;
using System.Collections;

public class PlatformScoring : MonoBehaviour {
    public bool isDown;
    public int id;
    public Animator increaseHealthUI;

    PlayerStats playerStats;

    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        MinionStats mStats = collider.GetComponent<MinionStats>();
        if (mStats != null)
        {
            
            if (mStats.goal.id == id)
            {
               
                playerStats.updateHealth(mStats.healthPoints);
                increaseHealthUI.SetTrigger("Increase");
                
            }
            //Destroy(mStats.gameObject);
        }
    }
}
