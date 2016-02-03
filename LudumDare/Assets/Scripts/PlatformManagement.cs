using UnityEngine;
using System.Collections;

public class PlatformManagement : MonoBehaviour {
    public const int RIGHT = 0;
    public const int LEFT = 1;

    public Transform bridge;
    //private Vector3 startingPos;
    //private Quaternion startingRot;
    //private Vector3 startingScale;

    public Transform[] ropeTransforms;
    public Transform[] ropePositions;
    public float ropeSpeed = 15;
    public bool isMobile;

    public HingeJoint2D leftRopeEnd;
    public HingeJoint2D rightRopeEnd;

    public UImanager uiManager;

    SoundManager sManager;
    Vector3 bridgeOrigin;

    int[] currentPositions;
    public bool[] moveUp;

    void Start()
    {
        //RecordBoneInitialTransform();
        sManager = GetComponent<SoundManager>();
        moveUp = new bool[ropeTransforms.Length];
        currentPositions = new int[ropePositions.Length];
        isMobile = Application.isMobilePlatform;
        

    }

    //void RecordBoneInitialTransform()
    //{
    //    startingPos = bridge.localPosition;
    //    startingRot = bridge.localRotation;
    //    startingScale = bridge.localScale;
    //}

    void Update()
    {	
        if (uiManager.currentState == UImanager.UIState.mainMenu)
        {
            int move = Random.Range(0, 200);
            if (move < 1)
            {
                if(Random.Range(0, 2) == 0)
                {
                    moveRope(RIGHT);
                }
                else
                {
                    moveRope(LEFT);
                }
            }
        }
        else if (isMobile)
        {
            UpdateMobileInput();

        }
        else
        {
			UpdateMobileInput();
            updateInput();
        }
        updateRopePosition(LEFT);
        updateRopePosition(RIGHT);
    }

    void updateInput()
    {
        if (Input.GetButtonDown("LeftButton"))
        {
            moveRope(LEFT);
        }
        if (Input.GetButtonDown("RightButton"))
        {
            moveRope(RIGHT);
        }
    }

	void UpdateMobileInput(){
		foreach(Touch touch in Input.touches){
			if(touch.phase == TouchPhase.Began){
				//Left Touch
				if (touch.position.x < Screen.width / 2f) {
					moveRope(LEFT);
					//Debug.Log("left end");
				}
				//Right Touch
				else {
					moveRope(RIGHT);
					//Debug.Log("right end");
				}
			}
		}
	}

    void updateRopePosition(int id)
    {
        Transform rope = ropeTransforms[id];
        Vector3 current =rope.position;
        Vector3 goal = new Vector3(current.x, ropePositions[currentPositions[id]].position.y, current.z);
        rope.position = Vector3.MoveTowards(rope.position, goal, Time.deltaTime * ropeSpeed);
    }

    public void moveRope(int id)
    {
        sManager.setRandomClip();
        sManager.setRandomPitch();
        sManager.setRandomVolume();
        sManager.playSound();   
        int currentPos = currentPositions[id];
        if (moveUp[id] && currentPos <= 0)
        {
            moveUp[id] = false;
        }
        else if (!moveUp[id] && currentPos >= ropePositions.Length - 1)
        {
            moveUp[id] = true;
        }

        if (moveUp[id])
        {
            currentPositions[id]--;
        }
        else
        {
            currentPositions[id]++;
        }
    }

    public void DetachRope()
    {
        //need to move rope to top first before detaching
        leftRopeEnd.enabled = false;
        rightRopeEnd.enabled = false;
    }

    public void ResetPlatform()
    {
        /*
        for (int i = 0; i < moveUp.Length; i++)
        {
            if (!moveUp[i])
            {
                moveRope(i);
            }
        }
        bridge.localPosition = startingPos;
        bridge.localRotation = startingRot;
        bridge.localScale = startingScale;
        */

        leftRopeEnd.enabled = true;
        rightRopeEnd.enabled = true;
        currentPositions[0] = 0;
        currentPositions[1] = 0;
        GetComponent<PlatformReset>().resetToOrigin();
    }
}
