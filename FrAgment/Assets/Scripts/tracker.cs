using UnityEngine;
using System.Collections;

public class tracker : MonoBehaviour {

    public static string SceneToChangeTo;
    public static int CurrentChallengeScreen;

    private static float maxSwipeTime = 5.0f;
    private static float minSwipeDistance = 100;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
    void Update() {
       
    }

    public static bool IsSwipeLeft(Vector3 curDownPos, Vector2 curUpPos)
    {
        float swipeDist = curDownPos.x - curUpPos.x;
        if (swipeDist > minSwipeDistance)
        {
            Debug.Log("Swipe left");
            return true;
        }

        return false;
    }

    public static bool IsSwipeRight(Vector3 curDownPos, Vector2 curUpPos)
    {
        float swipeDist = curUpPos.x - curDownPos.x;
        if (swipeDist > minSwipeDistance)
        {
            Debug.Log("Swipe right");
            return true;
        }

        return false;
    }

    public static bool IsSwipeUp(Vector3 curDownPos, Vector2 curUpPos)
    {
        float swipeDist = curUpPos.y - curDownPos.y;
        if (swipeDist > minSwipeDistance)
        {
            Debug.Log("Swipe up");
            return true;
        }

        return false;
    }

    public static bool IsSwipeDown(Vector3 curDownPos, Vector2 curUpPos)
    {
        float swipeDist = curDownPos.y - curUpPos.y;
        if (swipeDist > minSwipeDistance)
        {
            Debug.Log("Swipe down");
            return true;
        }

        return false;
    }
}
