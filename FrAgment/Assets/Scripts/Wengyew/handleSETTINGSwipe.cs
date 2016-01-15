using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class handleSETTINGSwipe : MonoBehaviour {

    private Vector2 curDownPos;
    public Button swipeDownInvoke;
    public Button swipeUpInvoke;

    private bool validPositionStart;
    private float minXToSwipe = 400;
    private float minYToSwipe = 200;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x > minXToSwipe || Input.mousePosition.y > minYToSwipe)
                validPositionStart = true;
            else
                validPositionStart = false;

            curDownPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (validPositionStart)
            {
                Debug.Log("check swipe");
                if (swipeUpInvoke != null && tracker.IsSwipeUp(curDownPos, Input.mousePosition))
                {
                        swipeUpInvoke.onClick.Invoke();
                }
                else if (swipeDownInvoke != null && tracker.IsSwipeDown(curDownPos, Input.mousePosition))
                {
                        swipeDownInvoke.onClick.Invoke();
                }
            }
        }
    }
}
