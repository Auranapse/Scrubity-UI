using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class tracker : MonoBehaviour {

    public static string SceneToChangeTo;
    public static int CurrentChallengeScreen;

    private static float minSwipeDistance = 100;
    private static float maxSwipeOffset = 400;

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("ControlScheme")) {
            Debug.Log("???");
            PlayerPrefs.SetInt("ControlScheme", 1);
        }
        if (!PlayerPrefs.HasKey("Sensitivity")) {
            PlayerPrefs.SetInt("Sensitivity", 50);
        }
        if (!PlayerPrefs.HasKey("MusicType")) {
            PlayerPrefs.SetInt("MusicType", 1);
        }
        if (!PlayerPrefs.HasKey("MusicVolume")) {
            PlayerPrefs.SetInt("MusicVolume", 100);
        }
        if (!PlayerPrefs.HasKey("SoundVolume")) {
            PlayerPrefs.SetInt("SoundVolume", 100);
        }
	}
	
	// Update is called once per frame
    void Update() {
    }

    public static bool IsSwipeLeft(Vector3 curDownPos, Vector2 curUpPos)
    {
        float swipeDist = curDownPos.x - curUpPos.x;
        if (swipeDist > minSwipeDistance && Mathf.Abs(curDownPos.y - curUpPos.y) < maxSwipeOffset)
        {
            Debug.Log("Swipe left");
            return true;
        }

        return false;
    }

    public static bool IsSwipeRight(Vector3 curDownPos, Vector2 curUpPos)
    {
        float swipeDist = curUpPos.x - curDownPos.x;
        if (swipeDist > minSwipeDistance && Mathf.Abs(curDownPos.y - curUpPos.y) < maxSwipeOffset)
        {
            Debug.Log("Swipe right");
            return true;
        }

        return false;
    }

    public static bool IsSwipeUp(Vector3 curDownPos, Vector2 curUpPos)
    {
        float swipeDist = curUpPos.y - curDownPos.y;
        if (swipeDist > minSwipeDistance && Mathf.Abs(curDownPos.x - curUpPos.x) < maxSwipeOffset)
        {
            Debug.Log("Swipe up");
            return true;
        }

        return false;
    }

    public static bool IsSwipeDown(Vector3 curDownPos, Vector2 curUpPos)
    {
        float swipeDist = curDownPos.y - curUpPos.y;
        if (swipeDist > minSwipeDistance && Mathf.Abs(curDownPos.x - curUpPos.x) < maxSwipeOffset)
        {
            Debug.Log("Swipe down");
            return true;
        }

        return false;
    }
}
