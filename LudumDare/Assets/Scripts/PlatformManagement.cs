using UnityEngine;
using System.Collections;

public class PlatformManagement : MonoBehaviour {
    public const int RIGHT = 0;
    public const int LEFT = 1;

    public Transform[] ropeTransforms;
    public Transform[] ropePositions;
    public float ropeSpeed = 15;
    public bool isMobile;

    public UImanager uiManager;

    SoundManager sManager;

    int[] currentPositions;
    bool[] moveUp;

    void Start()
    {
        sManager = GetComponent<SoundManager>();
        moveUp = new bool[ropeTransforms.Length];
        currentPositions = new int[ropePositions.Length];
        isMobile = Application.isMobilePlatform;

    }

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
			if(touch.phase == TouchPhase.Ended){
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

    void moveRope(int id)
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
}
