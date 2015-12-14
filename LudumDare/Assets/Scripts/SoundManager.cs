using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    public AudioSource aSource;
    public AudioClip[] aClips;
    public float minVolume;
    public float maxVolume;
    public float minPitch;
    public float maxPitch;

    bool playDelayed;
    float playDelayTimer;

    void Start()
    {
        if (aSource == null)
        {
            aSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (playDelayed)
        {
            playDelayTimer = Mathf.MoveTowards(playDelayTimer, 0, Time.deltaTime);
            if (playDelayTimer <= 0)
            {
                playSound();
                playDelayed = false;
            }
        }
    }

    public void setRandomClip()
    {
        aSource.clip = aClips[Random.Range(0, aClips.Length)];
    }

    public void setRandomPitch()
    {
        aSource.pitch = Random.Range(minPitch, maxPitch);
    }

    public void setRandomVolume()
    {
        aSource.volume = Random.Range(minVolume, maxVolume);
    }

    public void playSound()
    {
        aSource.Stop();
        aSource.Play();
    }

    public void playSoundDelay(float timeForDelay)
    {
        playDelayed = true;
        playDelayTimer = timeForDelay;
    }
    

}
