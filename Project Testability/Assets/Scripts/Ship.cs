using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
    public float f_Transition_Speed;
    Vector3 v3_Ship_Velocity;
    float f_Max_Ship_Speed;
    Vector3 v3_StartPos;
    Vector3 v3_EndPos;
    Vector3 v3_InitInputPos;

    public GameObject FunctionCall;

    // Use this for initialization
    void Start()
    {
        f_Max_Ship_Speed = 100f;
        v3_StartPos.Set(0, -6f, 0);
        v3_EndPos.Set(0, -3.5f, 0);
        v3_InitInputPos.Set(0, 0, 0);
        v3_Ship_Velocity.Set(0, 0, 0);

        this.transform.position = v3_StartPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (!FunctionCall.GetComponent<SmoothTransition>().S_TransitionIsDone())
        {
            this.transform.position = FunctionCall.GetComponent<SmoothTransition>().S_Transition(this.transform.position, v3_EndPos, f_Transition_Speed, Time.deltaTime);
        }
        else
        {
            Vector3 inputPosition = Input.mousePosition;

            //this.transform.position += new Vector3(f_Ship_Speed * Time.deltaTime,0,0);			
            //Vector3 ray = Camera.main.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, 0));

            if (Input.GetMouseButtonDown(0))
            {
                v3_InitInputPos = inputPosition;
                //Debug.Log(v3_InitInputPos);
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 diff = inputPosition - v3_InitInputPos;
                if (diff.x > f_Max_Ship_Speed)
                {
                    diff.x = f_Max_Ship_Speed;
                }

                if (diff.x < -f_Max_Ship_Speed)
                {
                    diff.x = -f_Max_Ship_Speed;
                }

                v3_Ship_Velocity.x += diff.x * Time.deltaTime;
            }

            if (v3_Ship_Velocity != new Vector3(0, 0, 0))
            {
                v3_Ship_Velocity += -v3_Ship_Velocity * Time.deltaTime * 10f;
            }

            if (this.transform.position.x > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x)
            {
                if(v3_Ship_Velocity.x > 0)
                {
                    v3_Ship_Velocity.x = 0;
                }
            }

            if (this.transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x)
            {
                if (v3_Ship_Velocity.x < 0)
                {
                    v3_Ship_Velocity.x = 0;
                }
            }

            this.transform.position += v3_Ship_Velocity * Time.deltaTime;
        }
    }
}
