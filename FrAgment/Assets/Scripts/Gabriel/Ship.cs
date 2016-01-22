using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
    public float f_Transition_Speed;
    Vector3 v3_Ship_Velocity;
    public float f_Max_Ship_Speed;
    public float f_Ship_Speed_Sensitivity;
    public float f_Max_Vertical_Movement;
    public float f_firerate;
    public Vector2 v2_fireVelocity;
    float f_firebullet;
    public Vector3 v3_StartPos;
    public Vector3 v3_EndPos;
    Vector3 v3_InitInputPos;

    public GameObject Bullet;
    public GameObject FunctionCall;

    // Use this for initialization
    void Start()
    {
        this.GetComponent<Rigidbody2D>().freezeRotation = true;

        v3_InitInputPos.Set(0, 0, 0);
        v3_Ship_Velocity.Set(0, 0, 0);
        f_firebullet = 0f;

        this.transform.position = v3_StartPos;
    }

    // Update is called once per frame
    void Update()
    {
        switch (FunctionCall.GetComponent<GameRuntimeHandler>().GAME_STATE)
        {
            case GameRuntimeHandler.GAME_STATES.INTRO:
                {
                    if (!FunctionCall.GetComponent<SmoothTransition>().S_TransitionIsDone())
                    {
                        this.transform.position = FunctionCall.GetComponent<SmoothTransition>().S_Transition(this.transform.position, v3_EndPos, f_Transition_Speed, Time.deltaTime);
                    }
                    else
                    {
                        FunctionCall.GetComponent<GameRuntimeHandler>().setReadytobegin();
                    }
                }
                break;
            case GameRuntimeHandler.GAME_STATES.PLAYING:
                {
                    //Shooting
                    f_firebullet += Time.deltaTime;
                    if(f_firebullet > f_firerate)
                    {
                        f_firebullet = 0f;

                        
                        GameObject temp = (GameObject)Instantiate(Bullet, this.transform.position + new Vector3(0, 100, 0), this.transform.rotation);
                        temp.GetComponent<Rigidbody2D>().velocity = v2_fireVelocity + this.GetComponent<Rigidbody2D>().velocity;
                    }


                    Vector3 inputPosition = Input.mousePosition;

                    //this.transform.position += new Vector3(f_Ship_Speed * Time.deltaTime,0,0);			
                    //Vector3 ray = Camera.main.ScreenToWorldPoint(new Vector3(inputPosition.x, inputPosition.y, 0));

                    if (Input.GetMouseButtonDown(0))
                    {
                        v3_InitInputPos = inputPosition;
                        //Debug.Log(v3_InitInputPos);
                    }

                    if (Input.GetMouseButton(0))
                    {
                        Vector3 temp = inputPosition - v3_InitInputPos;

                        temp = temp * f_Ship_Speed_Sensitivity;

                        if (temp.x > f_Max_Ship_Speed)
                        {
                            temp.x = f_Max_Ship_Speed;
                        }

                        if (temp.x < -f_Max_Ship_Speed)
                        {
                            temp.x = -f_Max_Ship_Speed;
                        }

                        if (temp.y > f_Max_Ship_Speed)
                        {
                            temp.y = f_Max_Ship_Speed;
                        }

                        if (temp.y < -f_Max_Ship_Speed)
                        {
                            temp.y = -f_Max_Ship_Speed;
                        }

                        temp.z = 0f;

                        v3_Ship_Velocity += temp * Time.deltaTime;
                    }

                    if (v3_Ship_Velocity != new Vector3(0, 0, 0))
                    {
                        v3_Ship_Velocity += -v3_Ship_Velocity * Time.deltaTime * 10f;
                    }

                    if (this.transform.position.x > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x)
                    {
                        if (v3_Ship_Velocity.x > 0)
                        {
                            v3_Ship_Velocity.x = 0;
                        }
                    }
                    else if (this.transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x)
                    {
                        if (v3_Ship_Velocity.x < 0)
                        {
                            v3_Ship_Velocity.x = 0;
                        }
                    }

                    if (this.transform.position.y > f_Max_Vertical_Movement + v3_EndPos.y)
                    {
                        if (v3_Ship_Velocity.y > 0)
                        {
                            v3_Ship_Velocity.y = 0;
                        }
                    }
                    else if (this.transform.position.y < v3_EndPos.y)
                    {
                        if (v3_Ship_Velocity.y < 0)
                        {
                            v3_Ship_Velocity.y = 0;
                        }
                    }
                    
                    this.GetComponent<Rigidbody2D>().velocity = (v3_Ship_Velocity);
                }
                break;
        }
    }
}
