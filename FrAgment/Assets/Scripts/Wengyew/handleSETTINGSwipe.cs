﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class handleSETTINGSwipe : MonoBehaviour {

    private Vector2 curDownPos;
    public Button swipeDownInvoke;
    public Button swipeUpInvoke;

    private bool validPositionStart;
    private float minXToSwipe = 265;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Input.mousePosition.x > minXToSwipe)
                validPositionStart = true;
            else
                validPositionStart = false;

            curDownPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (validPositionStart && Input.mousePosition.x > minXToSwipe)
            {
                if (tracker.IsSwipeUp(curDownPos, Input.mousePosition))
                {
                    if (swipeUpInvoke != null)
                        swipeUpInvoke.onClick.Invoke();
                }
                else if (tracker.IsSwipeDown(curDownPos, Input.mousePosition))
                {
                    if (swipeDownInvoke != null)
                        swipeDownInvoke.onClick.Invoke();
                }
            }
        }
    }
}