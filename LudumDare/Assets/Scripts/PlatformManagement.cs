﻿using UnityEngine;
using System.Collections;

public class PlatformManagement : MonoBehaviour {
    public const int RIGHT = 0;
    public const int LEFT = 1;

    public Transform[] ropeTransforms;
    public Transform[] ropePositions;
    public float ropeSpeed = 15;

    int[] currentPositions;
    bool[] moveUp;

    void Start()
    {
        moveUp = new bool[ropeTransforms.Length];
        currentPositions = new int[ropePositions.Length];

    }

    void Update()
    {
        if (Input.GetButtonDown("LeftButton"))
        {
            moveRope(LEFT);
        }
        if (Input.GetButtonDown("RightButton"))
        {
            moveRope(RIGHT);
        }

        updateRopePosition(RIGHT);
        updateRopePosition(LEFT);
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
