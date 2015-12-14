using UnityEngine;
using System.Collections;

public class MinionStats : MonoBehaviour {
    //public string name;
    public Vector2 direction;
    public int healthPoints;
    public bool goalDown;
    public SpriteRenderer arrowThought;

    void Start()
    {
       arrowThought.flipY = goalDown;
        transform.localScale = new Vector3(-direction.x * transform.localScale.x, transform.localScale.y, 1);

    }

    void Update()
    {
    }

    public void setGoalDown()
    {
        goalDown = Random.Range(0f, 1f) > .5f;
    }
}
