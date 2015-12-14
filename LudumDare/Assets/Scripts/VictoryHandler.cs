using UnityEngine;
using System.Collections;

public class VictoryHandler : MonoBehaviour {
    public float pauseTime = .8f;
    public float destroyTimer = 1.2f;
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
            print(pScore.id + "     " + mStats.goal.id);
            if (pScore.id == mStats.goal.id)
            {
                anim.SetTrigger("Victory");
                //rigid.isKinematic = true;
                movement.speed = 0;
                reachedCheckPoint = true;
            }
            

        }
    }
}
