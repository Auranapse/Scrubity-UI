using UnityEngine;
using System.Collections;

public class Translation : MonoBehaviour
{

    public float TimeStartForAnimation;
    public bool isInertiaEnter;
    public bool isInertiaLeave;
    public Vector3 EndPos;
    public Vector3 Direction;
    public float Movement_Speed;

    float Speed;

    float Timer;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (Timer > TimeStartForAnimation)
        {
            if (isInertiaEnter == true)
            {
                Movement_Speed = Inertia(this.transform.position, EndPos, Movement_Speed * 10);
            }
            if (isInertiaLeave == true)
            {
                Movement_Speed += 10;
            }


            if (Mathf.Round((this.transform.position - EndPos).magnitude) < 5)
            {
                Direction.Set(0, 0, 0);
            }

            this.transform.position = Move(this.transform.position, Direction, Movement_Speed, Time.deltaTime);
        }
    }

    Vector3 Move(Vector3 CurrentPos, Vector3 Direction, float Speed, float dt)
    {
        CurrentPos += Direction * Speed * dt;

        return CurrentPos;
    }

    float Inertia(Vector3 Start, Vector3 End, float MaxSpeed)
    {
        return Mathf.Clamp((Start - End).magnitude, 1f, MaxSpeed);
    }
}
