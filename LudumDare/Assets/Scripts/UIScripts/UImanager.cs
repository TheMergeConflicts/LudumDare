﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UImanager : MonoBehaviour {
	public enum UIState{mainMenu, inGame, preGame, endAnimation,endScreen};
	public UIState currentState;
	public Text ageText;
    public Slider healthBar;

	public GameObject pregamePanel;
	public GameObject inGamePanel;
	public GameObject creditsPanel;
	public GameObject mainMenuPanel;
    public GameObject blackCoverPanel;
    public GameObject endPanel;
    public GameObject ComboUI;

    public MinionSpawner minionSpawner;
    public PlatformManagement platformManagement;

	public Text finalResult;

    public Animator healthBarAnim;

	public int finalAge;

	PlayerStats playerStats;
	Animator leftTutorialAnim;
	Animator rightTutorialAnim;
	bool leftSet;
	bool rightSet;

	// Use this for initialization
	void Start () {
		finalAge = 0;
		leftSet = false;
		rightSet = false;
		currentState = UIState.mainMenu;
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
		leftTutorialAnim = pregamePanel.transform.Find ("Left").GetComponent<Animator>();
		rightTutorialAnim = pregamePanel.transform.Find ("Right").GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentState == UIState.inGame){
			SetInGameUI (true);
			SetMainMenuUI (false);
			SetPreGameUI (false);
			SetEndGameUI (false);
            SetEndAnimationUI(false);
			ageText.text = "Age: " + playerStats.age;
			healthBar.value = playerStats.health;
            minionSpawner.StartSpawningMinions();
		}
		else if(currentState == UIState.mainMenu){
			SetInGameUI (false);
			SetMainMenuUI (true);
			SetPreGameUI (false);
			SetEndGameUI (false);
            SetEndAnimationUI(false);
            minionSpawner.StartSpawningMinions();
        }
		else if(currentState == UIState.endScreen){
			SetInGameUI (false);
			SetMainMenuUI (false);
			SetPreGameUI (false);
			SetEndGameUI (true);
            SetEndAnimationUI(true);
            minionSpawner.EndSpawningMinions();
        }
        else if (currentState == UIState.endAnimation)
        {
            SetInGameUI(false);
            SetMainMenuUI(false);
            SetPreGameUI(false);
            SetEndGameUI(false);
            SetEndAnimationUI(true);
            blackCoverPanel.GetComponent<Animator>().SetTrigger("fadeIn");
            platformManagement.DetachRope();
            minionSpawner.EndSpawningMinions();
        }
        else if(currentState == UIState.preGame){
			SetInGameUI (false);
            SetEndAnimationUI(false);
            SetMainMenuUI (false);
			SetPreGameUI (true);
			SetEndGameUI (false);
            minionSpawner.EndSpawningMinions();
            //Mobile
            foreach (Touch touch in Input.touches){
				if(touch.phase == TouchPhase.Ended){
					//Left Touch
					if (touch.position.x < Screen.width / 2f) {
						leftSet = true;
						leftTutorialAnim.SetTrigger ("fadeOut");
					}
					//Right Touch
					else {
						rightSet = true;
						rightTutorialAnim.SetTrigger ("fadeOut");
					}
				}
			}
			//Arrow keys	
			if (Input.GetButtonDown("LeftButton"))
			{
				leftTutorialAnim.SetTrigger ("fadeOut");
				leftSet = true;
			}
			if (Input.GetButtonDown("RightButton"))
			{
				rightTutorialAnim.SetTrigger ("fadeOut");
				rightSet = true;
			}

			if(rightSet && leftSet){
				rightSet = false;
				leftSet = false;
				Invoke ("StartGame", leftTutorialAnim.GetCurrentAnimatorClipInfo(0).Length);
			}
		}
	}

	void SetEndGameUI(bool state){
		endPanel.SetActive (state);
	}

	void SetPreGameUI(bool state){
		pregamePanel.SetActive (state);
	}

	void SetInGameUI(bool state){
		inGamePanel.SetActive (state);
        ComboUI.SetActive(state);
	}

	void SetMainMenuUI(bool state){
		mainMenuPanel.SetActive (state);
	}

    void SetEndAnimationUI(bool state)
    {
        blackCoverPanel.SetActive(state);
    }

    //void SetEnd

	public void StartGame(){
		currentState = UIState.inGame;
        
	}

	public void StartPreGame(){
		currentState = UIState.preGame;
		ResetGame (false);
	}

	public void StartEndGame(){
		finalResult.text = "You survived to age" + "\n" + "<size=50>" + finalAge + "</size>";
		currentState = UIState.endScreen;
    }

    public void StartEndAnimation()
    {

        currentState = UIState.endAnimation;
        Invoke("StartEndGame", 2f);
    }

	public void StartMainMenu(){
		currentState = UIState.mainMenu;
		Debug.Log ("Main Menu");
	}

	public void EndGame(){
		Application.Quit ();
	}

	public void SetCreditsUI(bool state){
		creditsPanel.SetActive (state);
	}
	
    // soft only resets the variables, but hard resets the platform
	public void ResetGame(bool soft){
		finalAge = 0;
		playerStats.age = 0;
		playerStats.health = 100;
        playerStats.reset();
        if (!soft)
        {
            platformManagement.ResetPlatform();
        }
        GameObject[] minions = GameObject.FindGameObjectsWithTag ("Minion");
		foreach(GameObject minion in minions){
			Destroy (minion);
		}
	}
}
