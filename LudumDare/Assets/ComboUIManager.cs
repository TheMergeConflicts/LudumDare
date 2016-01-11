using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ComboUIManager : MonoBehaviour {

    public ComboMultiplier comboMultiplier;
    public Text comboText;
    public UImanager UIManager;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnGUI()
    {
        if (comboMultiplier.ticks > 0)
        {
            comboText.enabled = true;
            comboText.text = comboMultiplier.ticks.ToString();
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
}
