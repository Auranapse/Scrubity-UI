using UnityEngine;
using System.Collections;

public class ShipAnimation : MonoBehaviour {

    //Speed of Tranlation
    public float Movement_Speed;

    //Middle Of The Screen
    Vector3 Origin;

    //Ending Position
    Vector3 EndPos;

    //Direction To Move Towards
    Vector3 Direction;

    //Gravity
    Vector3 Gravity;

    //Variable to store deltaTime
    float TimeSinceBegin;

    //Variable to store time for animation to start
    float TimeToStartAnimation;

    // Use this for initialization
    void Start () {
        Origin = new Vector3(84.5f, 135.5f, 0);
        TimeSinceBegin = 0f;
        Gravity = new Vector3(0, -9.8f, 0);

        TimeToStartAnimation = 4f;
        Movement_Speed = 50f;
        EndPos = Origin;
        //Move From Left To Right
        Direction = new Vector3(0, 1, 0);


    }
	
	// Update is called once per frame
	void Update () {
        TimeSinceBegin += Time.deltaTime;

        if (TimeSinceBegin > TimeToStartAnimation)
            {
                Movement_Speed = (this.transform.position - EndPos).magnitude * 2;

                if (Move(transform.position, Direction).y < EndPos.y)
                {
                    this.transform.position = Move(transform.position, Direction);
                }
            }
    }
    Vector3 Move(Vector3 CurrentPos, Vector3 Direction)
    {
        CurrentPos += Direction * Movement_Speed * Time.deltaTime;
        return CurrentPos;
    }


}
