using UnityEngine;
using System.Collections;

public class BubblePop : MonoBehaviour {
    public float minScale = .8f;
    public float maxScale = 2.3f;
    public float minTime = 3;
    public float maxTime = 4.5f;

    float activeTimer;
    bool isPopped;
    Animator anim;


    void Start()
    {
        float scaleX = Random.Range(minScale, maxScale);
        transform.localScale = new Vector3(scaleX, scaleX, 1);
        activeTimer = Random.Range(minTime, maxTime);
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        activeTimer = Mathf.MoveTowards(activeTimer, 0, Time.deltaTime);
        if (activeTimer <= 0)
        {
            if (isPopped)
            {
                Destroy(this.gameObject);
            }
            else
            {
                activeTimer = 4f;
                isPopped = true;
                anim.SetTrigger("BubblePop");
            }
        }
        if (!isPopped)
        {
            transform.position += Vector3.up * Time.deltaTime * 2;

        }
    }
}
