using UnityEngine;
using System.Collections;

public class UI_Bottom : MonoBehaviour
{
    public float f_Transition_Speed;
    Vector3 v3_StartPos;
    Vector3 v3_EndPos;

    public GameObject FunctionCall;
    // Use this for initialization
    void Start()
    {
        v3_StartPos.Set(0, -6f, 0);
        v3_EndPos.Set(0, -4.6f, 0);

        this.transform.position = v3_StartPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (!FunctionCall.GetComponent<SmoothTransition>().S_TransitionIsDone())
        {
            this.transform.position = FunctionCall.GetComponent<SmoothTransition>().S_Transition(this.transform.position, v3_EndPos, f_Transition_Speed, Time.deltaTime);
        }
    }
}
