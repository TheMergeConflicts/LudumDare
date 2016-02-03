using UnityEngine;
using System.Collections;

public class FallDamage : MonoBehaviour {
    public float lethalHeight;
    public Vector3 positionBeforeFall;
    public float timeBeforeDestroy = 3;
    public SoundManager sManager;
    Rigidbody2D rigid;
    bool hasFallen;
    Animator anim;
    MinionMovement movement;
    public GameObject thoughtBubble;

    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<MinionMovement>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (hasFallen)
        {
            timeBeforeDestroy = Mathf.MoveTowards(timeBeforeDestroy, 0, Time.deltaTime);

        }
        if (timeBeforeDestroy <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        positionBeforeFall = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        float checkFallDamage = Mathf.Abs(transform.position.y - positionBeforeFall.y);
        if (checkFallDamage > lethalHeight)
        {
            GameObject.FindGameObjectWithTag("Combo").GetComponent<ComboMultiplier>().resetMultiplier();

            Destroy(thoughtBubble);
            hasFallen = true;
            anim.SetTrigger("Fall");
            movement.speed = 0;
            rigid.isKinematic = true;
            sManager.setRandomClip();
            sManager.setRandomPitch();
            sManager.setRandomVolume();
            sManager.playSound();
            Physics2D.IgnoreCollision(collider.collider, GetComponent<Collider2D>());

        }
    }

    public void setDestroyTimer()
    {
        hasFallen = true;
    }
}
