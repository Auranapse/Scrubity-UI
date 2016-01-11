using UnityEngine;
using System.Collections;

public class ForeGroundAnimation : MonoBehaviour {
    //Speed of Tranlation
    float Movement_Speed;

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

        TimeToStartAnimation = 1f;

        Movement_Speed = 300f;
        EndPos = Origin;
        
        //Move From Left To Right
        Direction = new Vector3(1, 0, 0);
        
    }
	
	// Update is called once per frame
	void Update () {
        TimeSinceBegin += Time.deltaTime;

        if (this.gameObject.tag == "SplashScreenFG")
        {
            if (TimeSinceBegin > TimeToStartAnimation)
            {
                if (Move(transform.position, Direction).x < EndPos.x)
                {
                    this.transform.position = Move(transform.position, Direction);
                }
            }
        }
    }

    Vector3 Move(Vector3 CurrentPos, Vector3 Direction)
    {
        CurrentPos += Direction * Movement_Speed * Time.deltaTime;
        return CurrentPos;
    }
}
