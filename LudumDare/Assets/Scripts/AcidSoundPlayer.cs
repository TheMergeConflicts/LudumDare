using UnityEngine;
using System.Collections;

public class AcidSoundPlayer : MonoBehaviour {
    AudioSource aSource;

    void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        aSource.pitch = Random.Range(.95f, 1.05f);
        aSource.volume = Random.Range(.5f, .6f);
        aSource.Stop();
        aSource.Play();
    }
}
