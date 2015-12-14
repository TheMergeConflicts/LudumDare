using UnityEngine;
using System.Collections;

public class BubbleSpawner : MonoBehaviour {
    public GameObject bubble;
    public float bubbleFreqMin = 2;
    public float bubbleFreqMax = 6;
    public Transform minPos;
    public Transform maxPos;

    float freqTimer;

    void Start()
    {
        
    }

    void Update()
    {
        freqTimer = Mathf.MoveTowards(freqTimer, 0, Time.deltaTime);
        if (freqTimer <= 0)
        {
            resetTimer();
            spawnBubble();
        }
    }

    void spawnBubble()
    {
        float x = Random.Range(minPos.position.x, maxPos.position.x);
        Vector3 newPos = new Vector3(x, this.transform.position.y, -.1f);
        Instantiate(bubble, newPos, new Quaternion());
    }

    void resetTimer()
    {
        freqTimer = Random.Range(bubbleFreqMin, bubbleFreqMax);
    }
}
