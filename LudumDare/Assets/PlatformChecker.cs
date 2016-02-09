using UnityEngine;
using System.Collections;

public class PlatformChecker : MonoBehaviour {

    //1 for left, 0 for right
    public int platformNum;
    public BalanceScript balance;
    public PlatformManagement platform;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Minion")
        {
            //Debug.Log(platform);
            //Debug.Log(platform.moveUp[0]);
            if (platform.moveUp.Length > 0)
            {
                //As for platform ends, 1 for left, 0 for right
                if (platform.moveUp[platformNum])
                {

                    if (platformNum == 1)
                    {
                        //Check minion movement direction, 1 for left to right, -1 fro right to left
                        if (col.gameObject.GetComponent<MinionStats>().direction.x == -1)
                        {
                            balance.LockSpawner(platformNum + 1);
                        }
                        
                    }

                    else if (platformNum == 0)
                    {
                        if (col.gameObject.GetComponent<MinionStats>().direction.x == 1)
                        {
                            balance.LockSpawner(platformNum + 3);
                        }
                        
                    }
                    
                }
            }
        }
    }
}
