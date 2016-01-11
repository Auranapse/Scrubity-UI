using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
	float f_Transition_Speed;
	float f_Ship_Speed;
	float f_Max_Ship_Speed;
	Vector3 v3_StartPos;
	Vector3 v3_EndPos;
	bool b_transitionDone;

	Vector3 v3_InitInputPos;
	float f_test;
	
	// Use this for initialization
	void Start ()
	{
		b_transitionDone = false;
		f_Transition_Speed = 3f;
		f_Ship_Speed = 0.02f;
		f_Max_Ship_Speed = 100f;
		v3_StartPos.Set (0, -6f, 0);
		v3_EndPos.Set (0, -3.5f, 0);
		v3_InitInputPos.Set (0, 0, 0);

		this.transform.position = v3_StartPos;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!b_transitionDone)
		{
			Vector3 diff = v3_EndPos - this.transform.position;
			
			this.transform.position += diff * Time.deltaTime * f_Transition_Speed;
			
			if (this.transform.position.y + 0.01f > v3_EndPos.y && this.transform.position.y - 0.01f < v3_EndPos.y)
			{
				this.transform.position = v3_EndPos;
				b_transitionDone = true;
			}
		}
		else
		{
			Vector3 inputPosition = Input.mousePosition;

			//this.transform.position += new Vector3(f_Ship_Speed * Time.deltaTime,0,0);			
			//Vector3 ray = Camera.main.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, 0));

			if(Input.GetMouseButtonDown(0))
			{
				v3_InitInputPos = inputPosition;
				Debug.Log(v3_InitInputPos);
			}

			if(Input.GetMouseButton(0))
			{
				Vector3 diff = inputPosition - v3_InitInputPos;
				if(diff.x > f_Max_Ship_Speed)
				{
					diff.x = f_Max_Ship_Speed;
				}

				if(diff.x < -f_Max_Ship_Speed)
				{
					diff.x = -f_Max_Ship_Speed;
				}

				this.transform.position += new Vector3(diff.x * Time.deltaTime * f_Ship_Speed, 0, 0);
			}
		}
	}
}
