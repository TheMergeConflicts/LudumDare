using UnityEngine;
using System.Collections;

public class BalanceScript : MonoBehaviour {
    public const int RED = 0;
    public const int GREEN = 1;
    public const int YELLOW = 2;
    public const int BLUE = 3;


    public float[] weightChance = new float[8];
    int lastRoll;

    /// <summary>
    /// This method will adjust the likelyhood that a spawner of a certain color will spawn a minion.
    /// </summary>
    /// <param name="scale"></param>
    /// <param name="color"></param>
    public void adjustSpawnerWeight(float scale, int color)
    {
        weightChance[color * 2] *= scale;
        weightChance[color * 2 + 1] *= scale;
        normalizeChance();
    }

    /// <summary>
    /// This method is used for to adjust the likelyhood that a minion of a certain color will respawn
    /// </summary>
    /// <param name="scale"></param>
    /// <param name="color"></param>
    public void adjustMinionSpawnWeight(float scale, int color)
    {
        int changeSlot = color / 2;
        if (color % 2 == 0)
        {
            changeSlot += 2;
        }
        weightChance[changeSlot] *= scale;
        weightChance[changeSlot + 4] *= scale;
        normalizeChance();
    }

    public int rollChance()
    {
        float randVal = Random.Range(0f, 1f);
        float min = 0;
        float max = weightChance[0];
        int i = 0;
        foreach(float f in weightChance)
        {
            if (randVal >= min && randVal <= max)
            {
                lastRoll = i;
                return i;
            }
            i++;
            min = max;
            max = weightChance[i];
        }
        lastRoll = -1;
        return -1;
    }

    public int getColorSpawn()
    {
        return lastRoll / 2;
    }

    public bool getMinionUp()
    {
        return lastRoll % 2 == 0;
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
