﻿using UnityEngine;
using System.Collections;

public class G_Translator : MonoBehaviour
{
    public float f_Transition_Speed;
    public Vector3 v3_StartPos;
    public Vector3 v3_EndPos;
    public float timeToStart;
    float timer;

    public GameObject FunctionCall;
    bool setPos;

    // Use this for initialization
    void Start()
    {
        timer = 0f;
        setPos = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!FunctionCall.GetComponent<SmoothTransition>().S_TransitionIsDone())
        {
            if (timer > timeToStart)
            {
                if (!setPos)
                {
                    this.transform.position = v3_StartPos;
                    setPos = true;
                }

                this.transform.position = FunctionCall.GetComponent<SmoothTransition>().S_Transition(this.transform.position, v3_EndPos, f_Transition_Speed, Time.deltaTime);
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }
}