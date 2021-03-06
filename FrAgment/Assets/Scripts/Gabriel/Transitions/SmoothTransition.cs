﻿using UnityEngine;
using System.Collections;

public class SmoothTransition : MonoBehaviour
{
    bool b_istransitiondone;
    public float f_snappingdist;
    // Use this for initialization
    void Start()
    {
        b_istransitiondone = false;
    }
    /*
    // Update is called once per frame
    void Update ()
    {
	
    }*/

    public Vector3 S_Transition(Vector3 v3_curPos, Vector3 v3_endPos, float f_Speed, float f_deltaTime)
    {
        if (v3_curPos != v3_endPos)
        {
            b_istransitiondone = false;

            Vector3 diff = v3_endPos - v3_curPos;

            v3_curPos += diff * f_deltaTime * f_Speed;

            if (v3_curPos.x + f_snappingdist > v3_endPos.x && v3_curPos.x - f_snappingdist < v3_endPos.x)
            {
                if (v3_curPos.y + f_snappingdist > v3_endPos.y && v3_curPos.y - f_snappingdist < v3_endPos.y)
                {
                    v3_curPos = v3_endPos;
                    b_istransitiondone = true;
                }
            }
        }

        return v3_curPos;
    }

    public bool S_TransitionIsDone()
    {
        return b_istransitiondone;
    }

    public void S_TransitionRedo()
    {
        b_istransitiondone = false;
    }
}