using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    public AudioSource aSource;
    public AudioClip[] aClips;
    public float minVolume = .9f;
    public float maxVolume = 1;
    public float minPitch = .95f;
    public float maxPitch = 1.05f;

    bool playDelayed;
    float playDelayTimer;

    void Start()
    {
        if (aSource == null)
        {
            aSource = GetComponent<AudioSource>();
        }

        aSource.pitch = maxPitch;
        aSource.volume = maxVolume;
        aSource.clip = aClips[0];
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

    public void setClip(int i)
    {
        if (i < 0 || i >= aClips.Length)
        {
            aSource.clip = aClips[0];
        }
        else
        {
            aSource.clip = aClips[i];
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

    public void setPitch(float pitch)
    {
        aSource.pitch = pitch;
    }

    public void setVolume(float vol)
    {
        aSource.volume = vol;
    }

    public void setRandomVolume()
    {
        aSource.volume = Random.Range(minVolume, maxVolume);
    }

    public void playSound()
    {
        stopSound();
        aSource.Play();
    }

    public void stopSound()
    {
        aSource.Stop();
    }

    public void playRandomSound()
    {
       
        setRandomClip();
        setRandomPitch();
        setRandomVolume();
        playSound();
    }

    public void playSoundDelay(float timeForDelay)
    {
        playDelayed = true;
        playDelayTimer = timeForDelay;
    }
    

}
