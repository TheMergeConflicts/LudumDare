using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UImanager : MonoBehaviour {
	public enum UIState{MainMenu, inGame, pauseScreen};

	public UIState currentState;
	public Text ageText;
    public Slider healthBar;

	public GameObject creditsPanel;
	public GameObject mainMenuPanel;

    PlayerStats playerStats;


	// Use this for initialization
	void Start () {
		currentState = UIState.MainMenu;
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
	}
	
	// Update is called once per frame
	void Update () {
		if(currentState == UIState.inGame){
			SetInGameUI (true);
			SetMainMenuUI (false);
			ageText.text = "Age: " + playerStats.age;
			healthBar.value = playerStats.health;
		}
		else if(currentState == UIState.MainMenu){
			SetInGameUI (false);
			SetMainMenuUI (true);
		}
		else if(currentState == UIState.pauseScreen){
			SetInGameUI (false);
		}
	}

	void SetInGameUI(bool state){
		ageText.gameObject.SetActive (state);
		healthBar.gameObject.SetActive (state);
	}

	void SetMainMenuUI(bool state){
		mainMenuPanel.SetActive (state);
	}

	public void StartGame(){
		currentState = UIState.inGame;
	}

	public void EndGame(){
		Application.Quit ();
	}

	public void SetCreditsUI(bool state){
		creditsPanel.SetActive (state);
	}
		
}
