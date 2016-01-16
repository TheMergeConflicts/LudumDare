using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class BalanceScript : MonoBehaviour {
    public const int RED = 0;
    public const int GREEN = 1;
    public const int BLUE = 2;
    public const int YELLOW = 3;

    public int rollStack = 10;

    public float balanceScale;

    int[] previousRolls;
    int currentRollPosition;

    float[] spawnWeights = new float[8];
    


    void Start()
    {
        initializePreviousRollStack();
        resetSpawnWeights();
        currentRollPosition = previousRolls.Length - 1;
    }

    void Update()
    {
    }

    public void rollChance()
    {
        float randChance = Random.Range(0f, 1f);
        float min = 0;
        float max = 0;
        for (int i = 0; i < spawnWeights.Length; i++)
        {
            max += spawnWeights[i];
            if (randChance >= min && randChance <= max)
            {
                addNewRoll(i);
                break;
            }
            min = max;
        }
        balanceWeights();
    }

    public float[] normalizeWeights(float[] arr)
    {
        float[] normalWeight = new float[arr.Length];
        float total = 0;
        foreach (float f in arr)
        {
            total += f;
        }

        for (int i = 0; i < normalWeight.Length; i++)
        {
            normalWeight[i] = arr[i] / total;
        }


        return normalWeight;
    }

    public int getAdjacentColor (int color)
    {
        return (color + 2) % 4;
    }

    public bool getMinionDown()
    {
        return previousRolls[currentRollPosition] % 2 != 0;
    }

    void scaleMinionColorWeight(int color, float scale)
    {
        int slot = convertMinionColorToRoll(color);
        spawnWeights[slot] *= scale;
        spawnWeights[slot + 4] *= scale;
    }

    void balanceWeights()
    {
        float[] colorFreq = getColorFrequency();
        resetSpawnWeights();
        for (int i = 0; i < colorFreq.Length; i++)
        {
            scaleMinionColorWeight(getAdjacentColor(i), (1 - colorFreq[i]) * balanceScale);
        }
        spawnWeights = normalizeWeights(spawnWeights);
        
    }

    public int getLastSpawnPosition()
    {
        return previousRolls[currentRollPosition] / 2;
    }

    int convertRollToMinionColor(int i)
    {
        int checkVal = i % 4;
        if (checkVal == 0)
        {
            return 1;
        }
        else if (checkVal == 1)
        {
            return 3;
        }
        else if (checkVal == 2)
        {
            return 0;
        }
        return 2;
    }

    int convertMinionColorToRoll(int color)
    {
        if (color == 0)
        {
            return 2;
        }
        if (color == 1)
        {
            return 0;
        }
        if (color == 2)
        {
            return 3;
        }
        return 1;
    }

    //======================================================================================================

    void addNewRoll(int i)
    {
        currentRollPosition = (currentRollPosition + 1) % previousRolls.Length;
        previousRolls[currentRollPosition] = i;
    }

    void resetSpawnWeights()
    {
        for (int i = 0; i < spawnWeights.Length; i++)
        {
            spawnWeights[i] = Mathf.Pow(spawnWeights.Length, -1);
        }
    }

    void initializePreviousRollStack()
    {
        if (rollStack <= 0)
        {
            previousRolls = new int[10];
        }
        else
        {
            previousRolls = new int[rollStack];
        }


        for (int i = 0; i < previousRolls.Length; i++)
        {
            previousRolls[i] = -1;
        }
    }

    float[] getColorFrequency()
    {
        float[] colorFreq = new float[4];
        int length = 0;
        for (int i = 0; i < previousRolls.Length; i++)
        {
            if (previousRolls[i] > -1)
            {
                colorFreq[convertRollToMinionColor(previousRolls[i])]++;
            }
            else
            {
                break;
            }
            length++;
        }

        if (length == 0)
        {
            return colorFreq;
        }
        for (int i = 0; i < colorFreq.Length; i++)
        {
            colorFreq[i] /= length;   
        }
        return colorFreq;
    }

}
