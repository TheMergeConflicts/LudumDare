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

    public int lowComboValue = 1;
    public int highComboValue = 4;

    void Start()
    {
        resetMultiplier();
        comboSounds = GetComponentInChildren<SoundManager>();
        //cUIManager = GameObject.FindObjectOfType<ComboUIManager>();
    }

	public void increaseMultiplier()
    {
        playComboIncreaseSound();
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
        comboSounds.setPitch(1.0f + totalStreak / 30.0f);
        if (totalStreak >= highComboValue)
        {
            comboSounds.setClip(comboIncreaseHigh);
            comboSounds.setVolume(0.7f);
            comboSounds.playSound();
        }
        else if (multiplierScale >= lowComboValue)
        {
            comboSounds.setClip(comboIncreaseLow);
            comboSounds.setVolume(0.85f);
            comboSounds.playSound();
        }
    }

    void playComboBreakSound()
    {
        comboSounds.setPitch(1);
        if (totalStreak >= lowComboValue)
        {
            comboSounds.setClip(comboBreakLow);
            comboSounds.setVolume(0.9f);
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
        playComboBreakSound();
        multiplierScale = 1;
        ticks = 0;
        totalStreak = 0;
    }
}
