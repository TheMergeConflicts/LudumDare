using UnityEngine;
using System.Collections;

public class MinionAcidLogic : MonoBehaviour {
    public float destroyTime = 4;
    public SoundManager sManager;
    MinionMovement movement;
    Animator anim;
    Rigidbody2D rigid;
    bool inAcid;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        movement = GetComponent<MinionMovement>();
    }

    void Update()
    {
        if (inAcid)
        {
            destroyTime = Mathf.MoveTowards(destroyTime, 0, Time.deltaTime);
            rigid.velocity = Vector2.up * -.6f;
        }

        if (destroyTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Acid")
        {
            GameObject.FindGameObjectWithTag("Combo").GetComponent<ComboMultiplier>().resetMultiplier();\

            anim.SetTrigger("Acid");
            inAcid = true;
            movement.enabled = false;
            sManager.setRandomClip();
            sManager.setRandomPitch();
            sManager.setRandomVolume();
            sManager.playSound();
        }
    }
}
