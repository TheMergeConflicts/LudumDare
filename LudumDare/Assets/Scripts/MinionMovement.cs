using UnityEngine;
using System.Collections;

public class MinionMovement : MonoBehaviour {
    public float jumpForce = 50;
    public float speed;
    public Transform checkJumpOrigin;

    Rigidbody2D rigid;
    MinionStats stats;

    void Start()
    {
        stats = GetComponent<MinionStats>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigid.velocity = stats.direction * speed + Vector2.up * rigid.velocity.y;
        Debug.DrawLine(checkJumpOrigin.position, checkJumpOrigin.position + new Vector3(stats.direction.x, stats.direction.y, 0));
        if (Physics2D.Raycast(checkJumpOrigin.position, stats.direction, 1f, 1))
        {
            jump();
        }

    }

    void jump()
    {
        rigid.AddForce(Vector2.up * jumpForce);
        //gameObject.layer = 1;
    }
}
