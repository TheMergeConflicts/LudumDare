using UnityEngine;
using System.Collections;

public class BalanceScript : MonoBehaviour {
    public float[] weightChance;

    public int rollChance()
    {
        return -1;
    }

    public void resetChance()
    {
        for(int i = 0; i < weightChance.Length; i++)
        {
            weightChance[i] = 1;
        }

        normalizeChance();
    }

    void normalizeChance()
    {
        float total = 0;
        foreach (float f in weightChance)
        {
            total += Mathf.Pow(f, 2);
        }

        int i = 0;

        foreach (float f in weightChance)
        {
            weightChance[i] = f / total;
            i++;
        }
    }
}
