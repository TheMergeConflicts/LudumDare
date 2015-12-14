using UnityEngine;
using System.Collections;

public class MinionStats : MonoBehaviour {
    //public string name;
    public Vector2 direction;
    public int healthPoints;
    public bool goalDown;
    public SpriteRenderer arrowThought;
    public PlatformScoring goal;
    SpriteRenderer render;
    public Color[] colors = new Color[4]; 

    void Start()
    {
       arrowThought.flipY = goalDown;
        transform.localScale = new Vector3(-direction.x * transform.localScale.x, transform.localScale.y, 1);
        render = GetComponent<SpriteRenderer>();

    }

    void Update()
    {
        render.color = colors[goal.id];
    }

    public void setGoalDown()
    {
        goalDown = Random.Range(0f, 1f) > .5f;
    }
}
