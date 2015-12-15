using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AgeUI : MonoBehaviour {
    Image currentImage;
    PlayerStats stats;
    public Sprite[] ageImages;

    void Start()
    {
        currentImage = GetComponent<Image>();
        stats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    void Update()
    {
        int agePicker = (int)(stats.age / 10);
        if (agePicker >= ageImages.Length)
        {
            agePicker = ageImages.Length - 1;
        }
        currentImage.sprite = ageImages[agePicker];
    }


	
}
