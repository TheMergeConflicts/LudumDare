using UnityEngine;
using System.Collections;

public class MinionMovement : MonoBehaviour {
    public float jumpForce = 50;
    public float speed;
    public Transform checkJumpOrigin;

    Rigidbody2D rigid;
    MinionStats stats;
    bool inAir;
    void Start()
    {
        stats = GetComponent<MinionStats>();
        rigid = GetComponent<Rigidbody2D>();
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
}
