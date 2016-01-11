using UnityEngine;
using System.Collections;

public class StartButtonAnimation : MonoBehaviour {

    float Movement_Speed;
    float ScaleSpeed;
    float TimeToStartAnimation;
    float TimeSinceBegin;

    bool StartScale;

    Vector3 Origin;
    Vector3 Direction;
    Vector3 EndPos;
    Vector3 ScaleBy;
    Vector3 EndScale;

    // Use this for initialization
    void Start()
    {
        Movement_Speed = 10f;
        ScaleSpeed = 0.01f;
        TimeToStartAnimation = 0.5f;
        TimeSinceBegin = 0f;

        StartScale = false;

        Origin.Set(84.5f, 135.5f, 0);
        Direction.Set(1, 0, 0);
        EndPos.Set(Origin.x + -30f, Origin.y + 5f, 0);
        ScaleBy.Set(ScaleSpeed, ScaleSpeed, 0);
        EndScale.Set(0.2f, 0.2f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        TimeSinceBegin += Time.deltaTime;

        if (TimeSinceBegin > TimeToStartAnimation)
        {
            Movement_Speed = (this.transform.position - EndPos).magnitude * 4;


            if (Move(this.transform.position, Direction).x < EndPos.x)
            {
                this.transform.position = Move(this.transform.position, Direction);

            }
            else
            {
                StartScale = true;

            }
            if (StartScale == true)
            {
                if (this.transform.localScale.x < EndScale.x && this.transform.localScale.y < EndScale.y)
                {
                    this.transform.localScale += ScaleBy;
                }
            }
        }
    }

    Vector3 Move(Vector3 CurrentPos, Vector3 Direction)
    {
        CurrentPos += Direction * Mathf.Clamp(Movement_Speed, 10f, Movement_Speed) * Time.deltaTime;
        return CurrentPos;
    }
}
