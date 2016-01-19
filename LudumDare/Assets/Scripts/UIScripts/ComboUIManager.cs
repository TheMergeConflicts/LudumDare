using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ComboUIManager : MonoBehaviour {

    public ComboMultiplier comboMultiplier;
    public Text comboText;
    public UImanager UIManager;

    public float text_alpha;

    public Animator animator;

    // Use this for initialization
    void Awake()
    {
        animator = GetComponent<Animator>();
        text_alpha = 1f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        
        AssignAlpha();
        if (comboMultiplier.totalStreak > 0)
        {
            text_alpha = 1f;
            comboText.text = comboMultiplier.totalStreak.ToString();
            comboText.enabled = true;
            
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


        //if (text_alpha <= 0)
        //{
        //    comboText.enabled = false;
        //}
        //else
        //{
        //    comboText.enabled = true;
        //}

    }


    public void AnimateComboUI(int multiplier)
    {
        if (UIManager.currentState == UImanager.UIState.inGame && !animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.ComboUI_break"))
        {
            Reset();
            switch (multiplier)
            {
                case 1:
                    animator.SetTrigger("SmallTick");
                    Invoke("Reset", 0.5f);
                    break;
                case 2:
                    animator.SetTrigger("MediumTick");
                    Invoke("Reset", 0.5f);
                    break;
                case 3:
                    animator.SetTrigger("BigTick");
                    Invoke("Reset", 0.5f);
                    break;

            }
        }
    }

    public void AssignAlpha()
    {
        Color color = comboText.color;
        color.a = text_alpha;
        comboText.color = color;
    }

    public void AnimateComboUIBreak()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.ComboUI_break"))
        {
            Reset();
            animator.SetTrigger("Break");
            Invoke("DisableText", 1f);
            Invoke("Reset", 1f);
        }

        
    }

    public void DisableText()
    {
        comboText.enabled = false;
    }

    public void Reset()
    {
        Vector3 scale = GetComponent<RectTransform>().localScale;
        scale.x = 2f;
        scale.y = 2f;

        text_alpha = 1f;

        GetComponent<RectTransform>().localScale = scale;
    }
}

