using UnityEngine;
using System.Collections;

public class FallDamage : MonoBehaviour {
    public float lethalHeight;
    public Vector3 positionBeforeFall;

    void OnCollisionExit2D(Collision2D collider)
    {
        positionBeforeFall = transform.position;
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        float checkFallDamage = Mathf.Abs(transform.position.y - positionBeforeFall.y);
        if (checkFallDamage > 6.1f)
        {
            Destroy(this.gameObject);
        }
    }
}
