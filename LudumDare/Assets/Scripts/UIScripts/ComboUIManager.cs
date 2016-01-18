using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ComboUIManager : MonoBehaviour {

    public ComboMultiplier comboMultiplier;
    public Text comboText;
    public UImanager UIManager;

    public Animator animator;

    // Use this for initialization
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        if (comboMultiplier.totalStreak > 0)
        {
            comboText.enabled = true;
            comboText.text = comboMultiplier.totalStreak.ToString();
            if (comboMultiplier.multiplierScale == 1)
            {
                comboText.color = Color.green;
            }
            else if (comboMultiplier.multiplierScale == 2)
            {
                comboText.color = Color.yellow;
            }
            else if (comboMultiplier.multiplierScale == 3)
            {
                comboText.color = Color.red;
            }
            else
            {
                Debug.Log("Error in combo Multiplier: multiplier scale = " + comboMultiplier.multiplierScale);
            }
        }
        else
        {
            comboText.enabled = false;
        }
    }


    public void AnimateComboUI(int multiplier)
    {
        if (UIManager.currentState == UImanager.UIState.inGame)
        {
            switch (multiplier)
            {
                case 1:
                    animator.SetTrigger("SmallTick");
                    break;
                case 2:
                    animator.SetTrigger("MediumTick");
                    break;
                case 3:
                    animator.SetTrigger("BigTick");
                    break;

            }
        }
    }
}
