using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {

    public float StartAnimation;
    public Vector3 RotateBy;
    public float RotationSpeed;
    Vector3 EndRotate;

    private RectTransform BlackBoxTop,BlackBoxBot;

    bool isCompleted;
    float Timer;


	// Use this for initialization
	void Start () {
        isCompleted = false;
        Timer = 0;
        BlackBoxTop = GameObject.Find("BlackBox_Top").GetComponent<RectTransform>();

        BlackBoxBot = GameObject.Find("BlackBox_Bottom").GetComponent<RectTransform>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isCompleted == false)
        {
            Timer += Time.deltaTime;

            if (Timer > StartAnimation)
            {
                if (BlackBoxBot.localEulerAngles.z < 200)
                {
                    BlackBoxBot.localEulerAngles += RotateBy * RotationSpeed * Time.deltaTime;
                }
                else
                {
                    EndRotate.Set(0, 0, 200);
                    BlackBoxBot.localEulerAngles = EndRotate;
                    isCompleted = true;
                }

                if (BlackBoxTop.localEulerAngles.z > 160)
                {
                    BlackBoxTop.localEulerAngles -= RotateBy * RotationSpeed * Time.deltaTime;
                }
                else
                {
                    EndRotate.Set(0, 0, 160);
                    BlackBoxTop.localEulerAngles = EndRotate;
                    isCompleted = true;
                }
            }
        }
	}
}
