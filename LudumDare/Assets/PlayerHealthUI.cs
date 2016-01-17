using UnityEngine;
using System.Collections;

public class PlayerHealthUI : MonoBehaviour {

	public UImanager UImanager;

	public PlayerStats playerStats;


	public float HealthUIShakeInterval;
	public float HealthUIShakeTimer;
	Animator HealthUIAnimator;

	bool shakeReady;

	void Awake(){
		HealthUIAnimator = GetComponent<Animator> ();
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(UImanager.currentState == UImanager.UIState.inGame){
			//Handle Timer
			if (!shakeReady) {
				if (HealthUIShakeTimer < HealthUIShakeInterval) {
					HealthUIShakeTimer += Time.deltaTime;
				} 
				else {
					shakeReady = true;
					HealthUIShakeTimer = 0f;
				}
			}
			if(playerStats.health < 30f && shakeReady){
				HealthUIAnimator.SetTrigger ("Shake");
				shakeReady = false;
			}
		}
	}
}
