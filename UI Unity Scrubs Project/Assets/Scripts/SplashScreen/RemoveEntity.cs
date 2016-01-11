using UnityEngine;
using System.Collections;

public class RemoveEntity : MonoBehaviour {


    //Speed of Tranlation
    float Movement_Speed;

    //Variable to store deltaTime
    float TimeSinceBegin;

    //Variable to store time for next scene
    float TimeForNextScene;

    //Direction for Entities to Exit
    Vector3 DirectionToExit;

    // Use this for initialization
    void Start () {
        TimeSinceBegin = 0f;
        TimeForNextScene = 6f;
        Movement_Speed = 10;
        DirectionToExit = new Vector3(-1, 0, 0);
    }
	
	// Update is called once per frame
	void Update () {
        TimeSinceBegin += Time.deltaTime;
        
        if (TimeSinceBegin > TimeForNextScene)
        {
            Movement_Speed += 10;
            this.transform.position = Move(this.transform.position, DirectionToExit);
            if (TimeSinceBegin > TimeForNextScene + 1)
            {
                Application.LoadLevel(1);
            }
        }
    }

    Vector3 Move(Vector3 CurrentPos, Vector3 Direction)
    {
        CurrentPos += Direction * Movement_Speed * Time.deltaTime;
        return CurrentPos;
    }
}
