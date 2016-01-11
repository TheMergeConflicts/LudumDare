using UnityEngine;
using System.Collections;

public class VictoryHandler : MonoBehaviour {
    public float pauseTime = .8f;
    public float destroyTimer = 1.2f;
    public AudioSource correctSound;
    public SoundManager sManager;
    bool reachedCheckPoint;
    Rigidbody2D rigid;
    Animator anim;
    MinionStats mStats;
    MinionMovement movement;
    

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        movement = GetComponent<MinionMovement>();
        mStats = GetComponent<MinionStats>();

    }

    void Update()
    {
        if (reachedCheckPoint)
        {
            destroyTimer = Mathf.MoveTowards(destroyTimer, 0, Time.deltaTime);
            pauseTime = Mathf.MoveTowards(pauseTime, 0, Time.deltaTime);

        }

        if (pauseTime <= 0)
        {
            rigid.isKinematic = false;

            if (!correctSound.isPlaying)
            {
                correctSound.Play();

            }
            movement.speed = 1;
        }

        if (destroyTimer <= 0)
        {

            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlatformScoring pScore = collider.GetComponent<PlatformScoring>();
        if (pScore != null)
        {
            ComboMultiplier combo = GameObject.FindGameObjectWithTag("Combo").GetComponent<ComboMultiplier>();
            if (pScore.id == mStats.goal.id)
            {
                anim.SetTrigger("Victory");
                combo.increaseMultiplier();
                //rigid.isKinematic = true;
                rigid.AddForce(Vector2.up * 100);
                movement.speed = 0;
                reachedCheckPoint = true;
                sManager.setRandomClip();
                sManager.setRandomPitch();
                sManager.setRandomVolume();
                sManager.playSound();
            }
            else if (mStats.initialSpawn.id != pScore.id)
            {
                combo.resetMultiplier();
            }

        }
    }
}
