using UnityEngine;
using System.Collections;

public class TitleAnimation : MonoBehaviour {

    Vector3 EndPos;
    Vector3 Direction;
    Vector3 Origin;
    float Movement_Speed;

    // Use this for initialization
    void Start()
    {
        Origin = new Vector3(84.5f, 135.5f, 0);
        if (this.gameObject.tag == "Title")
        {
            EndPos.Set(35f + Origin.x, 116.5f + Origin.y, 0f + Origin.z);
            Direction.Set(-1, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Title")
        {
            Movement_Speed = (this.transform.position - EndPos).magnitude * 4;

            if (Move(transform.position, Direction).x > EndPos.x)
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
