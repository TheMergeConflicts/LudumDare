using UnityEngine;
using System.Collections;

public class MinionMovement : MonoBehaviour {
    public float jumpForce = 50;
    public float speed;
    public Transform checkJumpOrigin;
    public AudioClip[] squishSounds = new AudioClip[4];
    public AudioClip[] boneSounds = new AudioClip[4];
    public AudioClip[] currentClips;

    Rigidbody2D rigid;
    MinionStats stats;
    bool inAir;
    AudioSource aSource;
    void Start()
    {
        stats = GetComponent<MinionStats>();
        rigid = GetComponent<Rigidbody2D>();
        aSource = GetComponent<AudioSource>();
        currentClips = squishSounds;
    }

    void Update()
    {
        rigid.velocity = stats.direction * speed + Vector2.up * rigid.velocity.y;
        Debug.DrawLine(checkJumpOrigin.position, checkJumpOrigin.position + new Vector3(stats.direction.x, stats.direction.y, 0));
       // print(Physics2D.Raycast(checkJumpOrigin.position, stats.direction, 1f, 1 << LayerMask.NameToLayer("SquishPlatform")));
        if (Physics2D.Raycast(checkJumpOrigin.position, stats.direction, 1f, 1 << LayerMask.NameToLayer("SquishPlatform")))
        {
            jump();
        }

    }

    void jump()
    {

        if (!inAir)
        {
            rigid.AddForce(Vector2.up * jumpForce);
            inAir = true;
        }
        
        //gameObject.layer = 1;
    }

    public void playStep()
    {
        aSource.clip = currentClips[Random.Range(0, currentClips.Length)];
        aSource.pitch = Random.Range(.95f, 1.05f);
        aSource.volume = Random.Range(.2f, 0.25f);
        aSource.Stop();
        aSource.Play();
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.collider.gameObject.layer == LayerMask.NameToLayer("Platform"))
        {
            currentClips = boneSounds;
        }
        else if (collider.collider.gameObject.layer == LayerMask.NameToLayer("SquishPlatform"))
        {
            currentClips = squishSounds;
        }
    }
}
