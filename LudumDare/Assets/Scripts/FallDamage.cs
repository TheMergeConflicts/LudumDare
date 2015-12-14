using UnityEngine;
using System.Collections;

public class FallDamage : MonoBehaviour {
    public float lethalHeight;
    public Vector3 positionBeforeFall;
    public float timeBeforeDestroy = 3;
    bool hasFallen;
    Animator anim;
    MinionMovement movement;

    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponent<MinionMovement>();
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
            //Destroy(this.gameObject);
            hasFallen = true;
            anim.SetTrigger("Fall");
            movement.speed = 0;
        }
    }

    public void setDestroyTimer()
    {
        hasFallen = true;
    }
}
