using UnityEngine;
using System.Collections;

public class ComboMultiplier : MonoBehaviour {
    public int multiplierScale = 1;
    public int maxMultiplierScale = 4;
    public int ticksToNextMultiplier = 5;
    public int totalStreak;

    public int ticks;

    ComboUIManager cUIManager;


    void Start()
    {
        resetMultiplier();
        cUIManager = GameObject.FindObjectOfType<ComboUIManager>();
    }

	public void increaseMultiplier()
    {
        cUIManager.AnimateComboUI(multiplierScale);
        totalStreak++;
        ticks++;
        if (ticks >= ticksToNextMultiplier)
        {
            increaseMultiplierScale();
        }
    }

    void increaseMultiplierScale()
    {
        
        multiplierScale++;
        if (multiplierScale > maxMultiplierScale)
        {
            multiplierScale = maxMultiplierScale;
        }
        ticks = 0;
    }

    public void resetMultiplier()
    {
        multiplierScale = 1;
        ticks = 0;
        totalStreak = 0;
    }
}
