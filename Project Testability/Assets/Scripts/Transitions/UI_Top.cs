using UnityEngine;
using System.Collections;

public class UI_Top : MonoBehaviour
{
	float f_Movement_Speed;
	Vector3 v3_StartPos;
	Vector3 v3_EndPos;

	// Use this for initialization
	void Start ()
	{
		f_Movement_Speed = 3f;
		v3_StartPos.Set (0, 6f, 0);
		v3_EndPos.Set (0, 4.64f, 0);

		this.transform.position = v3_StartPos;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.transform.position != v3_EndPos)
		{
			Vector3 diff = v3_EndPos - this.transform.position;

			this.transform.position += diff * Time.deltaTime * f_Movement_Speed;

			if(this.transform.position.y + 0.01f > v3_EndPos.y && this.transform.position.y - 0.01f < v3_EndPos.y)
			{
				this.transform.position = v3_EndPos;
			}
		}
	}
}
