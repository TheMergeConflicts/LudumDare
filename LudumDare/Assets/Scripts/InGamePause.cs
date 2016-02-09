using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGamePause : MonoBehaviour {

    public bool ingamePaused;
    public Image image;

    public Sprite pause;
    public Sprite resume;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void HandleIngamePause()
    {
        ingamePaused = !ingamePaused;
        if (ingamePaused)
        {
            Time.timeScale = 0;
            image.sprite = resume;
        }
        else
        {
            Time.timeScale = 1;
            image.sprite = pause;
        }
    }
}
