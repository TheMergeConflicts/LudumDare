using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UImanager : MonoBehaviour {
	public enum UIState{mainMenu, inGame, preGame, pauseScreen};
	public UIState currentState;
	public Text ageText;
    public Slider healthBar;

	public GameObject pregamePanel;
	public GameObject inGamePanel;
	public GameObject creditsPanel;
	public GameObject mainMenuPanel;
	public GameObject pausePanel;

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
			SetPregameUI (false);
			SetPauseGameUI (false);
			ageText.text = "Age: " + playerStats.age;
			healthBar.value = playerStats.health;
		}
		else if(currentState == UIState.mainMenu){
			SetInGameUI (false);
			SetMainMenuUI (true);
			SetPregameUI (false);
			SetPauseGameUI (false);
		}
		else if(currentState == UIState.pauseScreen){
			SetInGameUI (false);
			SetMainMenuUI (false);
			SetPregameUI (false);
			SetPauseGameUI (true);
		}
		else if(currentState == UIState.preGame){
			SetInGameUI (false);
			SetMainMenuUI (false);
			SetPregameUI (true);
			SetPauseGameUI (false);
			//Mobile
			foreach(Touch touch in Input.touches){
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
				ResetGame ();
				rightSet = false;
				leftSet = false;
				Invoke ("StartGame", leftTutorialAnim.GetCurrentAnimatorClipInfo(0).Length);
			}
		}
	}

	void SetPauseGameUI(bool state){
		pausePanel.SetActive (state);
	}

	void SetPregameUI(bool state){
		pregamePanel.SetActive (state);
	}

	void SetInGameUI(bool state){
		inGamePanel.SetActive (state);
	}

	void SetMainMenuUI(bool state){
		mainMenuPanel.SetActive (state);
	}

	public void StartGame(){
		currentState = UIState.inGame;
	}

	public void StartPreGame(){
		currentState = UIState.preGame;
		ResetGame ();
	}

	public void StartPauseGame(){
		finalResult.text = "You survived to age" + "\n" + "<size=50>" + finalAge + "</size>";
		currentState = UIState.pauseScreen;
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
		
	public void ResetGame(){
		finalAge = 0;
		playerStats.age = 0;
		playerStats.health = 100;
        playerStats.reset();
		GameObject[] minions = GameObject.FindGameObjectsWithTag ("Minion");
		foreach(GameObject minion in minions){
			Destroy (minion);
		}
	}
}
