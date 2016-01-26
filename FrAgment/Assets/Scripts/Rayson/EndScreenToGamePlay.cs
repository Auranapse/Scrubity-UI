using UnityEngine;
using System.Collections;

public class EndScreenToGamePlay : MonoBehaviour
{

    float Timer;
    bool Execute;
    bool isRotateCompleted;
    Vector3 EndRotate;
    private RectTransform BlackBoxT, BlackBoxB;
    public float RotationSpeed;
    Vector3 RotateBy;

    // Use this for initialization
    void Start()
    {
        isRotateCompleted = false;
        RotateBy.Set(0, 0, 1);
        BlackBoxT = GameObject.Find("BlackBox_Top").GetComponent<RectTransform>();
        Execute = false;
        BlackBoxB = GameObject.Find("BlackBox_Bottom").GetComponent<RectTransform>();
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Execute == true)
        {
            Timer += Time.deltaTime;
            if (Timer > 0)
            {
                if (isRotateCompleted == false)
                {
                    if (BlackBoxT.localEulerAngles.z < 180)
                    {
                        BlackBoxT.localEulerAngles += RotateBy * RotationSpeed * Time.deltaTime;
                    }
                    else
                    {
                        EndRotate.Set(0, 0, 180);
                        BlackBoxT.localEulerAngles = EndRotate;

                        isRotateCompleted = true;
                    }

                    if (BlackBoxB.localEulerAngles.z > 180)
                    {
                        BlackBoxB.localEulerAngles -= RotateBy * RotationSpeed * Time.deltaTime;
                    }
                    else
                    {
                        EndRotate.Set(0, 0, 180);
                        BlackBoxB.localEulerAngles = EndRotate;
                        isRotateCompleted = true;
                    }
                }

                GameObject.Find("User Interface").GetComponent<Translation>().enabled = true;

            }
            if (Timer > 0.5)
            {
                GameObject.Find("BlackBox_Top").GetComponent<Translation>().EndPos = GameObject.Find("BlackBox_Top").GetComponent<Translation>().InitialPos;

                GameObject.Find("BlackBox_Bottom").GetComponent<Translation>().EndPos = GameObject.Find("BlackBox_Bottom").GetComponent<Translation>().InitialPos;

            }
            if (Timer > 2)
            {
                Application.LoadLevel("GameScene");
            }
        }
    }

    public void ChangeclickedState()
    {
        Execute = true;
    }
}
