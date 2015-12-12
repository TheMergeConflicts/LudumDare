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
    }

    void Update()
    {
        transform.localScale = new Vector3(direction.x, 1, 1);
    }

    public void setGoalDown()
    {
        goalDown = Random.Range(0f, 1f) > .5f;
    }
}
