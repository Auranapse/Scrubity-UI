﻿using UnityEngine;
using System.Collections;

public class handleCHLGSwipe : MonoBehaviour {

    private Vector2 curDownPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            curDownPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            UpdateCHLGScreen.updateStuff = true;
            if (tracker.IsSwipeLeft(curDownPos, Input.mousePosition))
                UpdateCHLGScreen.challengePage += 1;
            else if (tracker.IsSwipeRight(curDownPos, Input.mousePosition))
                UpdateCHLGScreen.challengePage -= 1;
        }
	}
}
