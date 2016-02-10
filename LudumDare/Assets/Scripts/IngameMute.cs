using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IngameMute : MonoBehaviour {

    public bool ingameMuted;

    public Image image;

    public Sprite muted;
    public Sprite soundOn;

    public AudioListener audioListener;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void HandleIngameMuted()
    {
        Debug.Log("123");
        ingameMuted = !ingameMuted;
        if (ingameMuted)
        {
            audioListener.enabled = false;
            AudioListener.volume = 0;
            image.sprite = muted;
        }
        else
        {
            audioListener.enabled = true;
            AudioListener.volume = 100;
            image.sprite = soundOn;
        }
    }
}
