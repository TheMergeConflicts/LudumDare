using UnityEngine;
using System.Collections;

public class ComboMultiplier : MonoBehaviour {
    public const int comboIncreaseLow = 0;
    public const int comboIncreaseHigh = 1;
    public const int comboBreakLow = 2;
    public const int comboBreakHigh = 3;

    public int multiplierScale = 1;
    public int maxMultiplierScale = 4;
    public int ticksToNextMultiplier = 5;
    public int totalStreak;

    public int ticks;

    public ComboUIManager cUIManager;

    public SoundManager comboSounds;

    public int lowComboValue = 5;
    public int highComboValue = 10;

    void Start()
    {
        resetMultiplier();
        //cUIManager = GameObject.FindObjectOfType<ComboUIManager>();
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

    void playComboIncreaseSound()
    {
        if (multiplierScale >= highComboValue)
        {
            comboSounds.setClip(comboIncreaseHigh);
            comboSounds.playSound();
        }
        else if (multiplierScale >= lowComboValue)
        {
            comboSounds.setClip(comboIncreaseLow);
            comboSounds.playSound();
        }
    }

    void playComboBreakSound()
    {
        if (multiplierScale >= highComboValue)
        {
            comboSounds.setClip(comboBreakHigh);
            comboSounds.playSound();
        }
        else if (multiplierScale >= lowComboValue)
        {
            comboSounds.setClip(comboBreakLow);
            comboSounds.playSound();
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
