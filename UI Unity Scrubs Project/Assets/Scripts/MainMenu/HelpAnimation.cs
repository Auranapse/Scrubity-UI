using UnityEngine;
using System.Collections;

public class HelpAnimation : MonoBehaviour
{

    float Movement_Speed;
    float ScaleSpeed;
    float TimeToStartAnimation;
    float TimeSinceBegin;
   
    Vector3 Origin;
    Vector3 Direction;
    Vector3 EndPos;
    Vector3 rotateBy;


    // Use this for initialization
    void Start()
    {
        Movement_Speed = 100f;
        ScaleSpeed = 0.01f;
        TimeToStartAnimation = 0.5f;
        TimeSinceBegin = 0f;

        Origin.Set(84.5f, 135.5f, 0);
        Direction.Set(1, 0, 0);
        EndPos.Set(Origin.x + 70f, Origin.y + 120f, 0);
        rotateBy.Set(0,0,-5);
    }

    // Update is called once per frame
    void Update()
    {
        TimeSinceBegin += Time.deltaTime;

        if (TimeSinceBegin > TimeToStartAnimation)
        {

            if (Move(this.transform.position, Direction).x < EndPos.x)
            {

                Debug.Log(this.transform.rotation);
                this.transform.position = Move(this.transform.position, Direction);

                this.transform.Rotate(rotateBy.x, rotateBy.y, rotateBy.z);

            }
            else
            {
            }
        }
    }

    Vector3 Move(Vector3 CurrentPos, Vector3 Direction)
    {
        CurrentPos += Direction * Mathf.Clamp(Movement_Speed, 10f, Movement_Speed) * Time.deltaTime;
        return CurrentPos;
    }
}
