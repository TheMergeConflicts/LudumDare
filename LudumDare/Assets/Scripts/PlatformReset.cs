using UnityEngine;
using System.Collections;

public class PlatformReset : MonoBehaviour {
    Vector3[] originPositions;
    GameObject[] platformObjects;

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Platform");
        originPositions = new Vector3[objs.Length];
        int i = 0;
        foreach (GameObject obj in objs)
        {
            originPositions[i] = obj.transform.position;
            i++;
        }
        platformObjects = objs;
    }

    public void resetToOrigin()
    {
        int i = 0;
        foreach(GameObject obj in platformObjects)
        {
            obj.transform.position = originPositions[i];
            i++;
        }
    }
}
