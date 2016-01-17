using UnityEngine;
using System.Collections;

public class PlatformScoring : MonoBehaviour {
    public bool isDown;
    public int id;
    public Animator increaseHealthUI;


	UImanager UImanager;
    PlayerStats playerStats;

	void Awake(){
		UImanager = GameObject.FindGameObjectWithTag ("UIManager").GetComponent<UImanager> ();
	}

    void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        MinionStats mStats = collider.GetComponent<MinionStats>();
		if (mStats != null && UImanager.currentState == UImanager.UIState.inGame)
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
