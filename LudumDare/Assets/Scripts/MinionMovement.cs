using UnityEngine;
using System.Collections;

public class MinionMovement : MonoBehaviour {
    Rigidbody2D rigid;
    MinionStats stats;

    void Start()
    {
        stats = GetComponent<MinionStats>();
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigid.velocity = stats.direction * stats.speed + Vector2.up * rigid.velocity.y;

    }


}
