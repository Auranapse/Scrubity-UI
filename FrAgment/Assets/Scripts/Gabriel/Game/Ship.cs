using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour
{
    public float f_Transition_Speed;
    Vector3 v3_Ship_Velocity;
    public int i_Health;
    int i_Health_Max;
    public float f_Max_Ship_Speed;
    public float f_Ship_Speed_Sensitivity;
    public float f_Max_Vertical_Movement;
    public float f_firerate;
    public Vector2 v2_fireVelocity;
    float f_firebullet;
    public Vector3 v3_StartPos;
    public Vector3 v3_EndPos;
    Vector3 v3_InitInputPos;

    bool b_Ability1Active;
    public float f_Ability1Duration;
    public float f_Ability1Recharge;
    float f_Ability1;

    bool b_Ability2Active;
    public float f_Ability2Duration;
    public float f_Ability2Recharge;
    float f_Ability2;

    public GameObject Bullet;
    public GameObject FunctionCall;

    Color C_SETTER;

    // Use this for initialization
    void Start()
    {
        i_Health_Max = i_Health;
        f_Ability1 = 0f;
        b_Ability1Active = false;
        f_Ability2 = 0f;
        b_Ability2Active = false;

        this.GetComponent<Rigidbody2D>().freezeRotation = true;

        C_SETTER.r = 0f;
        C_SETTER.g = 0f;
        C_SETTER.b = 0f;
        C_SETTER.a = 1f;
        this.GetComponent<SpriteRenderer>().color = C_SETTER;

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
                    if (this.GetComponent<G_Translator>().isComplete())
                    {
                        FunctionCall.GetComponent<GameRuntimeHandler>().setReadytobegin();
                    }
                }
                break;
            case GameRuntimeHandler.GAME_STATES.PLAYING:
                {
                    UpdateAbilities();
                    //Shooting
                    f_firebullet += Time.deltaTime;
                    if (f_firebullet > f_firerate)
                    {
                        f_firebullet = 0f;


                        GameObject temp = (GameObject)Instantiate(Bullet, this.transform.position + new Vector3(0, 100, 0), this.transform.rotation);
                        temp.GetComponent<Rigidbody2D>().velocity = v2_fireVelocity;// + this.GetComponent<Rigidbody2D>().velocity;

                        if (b_Ability1Active)
                        {
                            GameObject temp2 = (GameObject)Instantiate(Bullet, this.transform.position + new Vector3(-40, 100, 0), this.transform.rotation);
                            temp2.GetComponent<Rigidbody2D>().velocity = v2_fireVelocity;// + this.GetComponent<Rigidbody2D>().velocity;

                            GameObject temp3 = (GameObject)Instantiate(Bullet, this.transform.position + new Vector3(40, 100, 0), this.transform.rotation);
                            temp3.GetComponent<Rigidbody2D>().velocity = v2_fireVelocity;// + this.GetComponent<Rigidbody2D>().velocity;
                        }
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

    void UpdateAbilities()
    {
        if (b_Ability1Active)
        {
            f_Ability1 += Time.deltaTime;
            if (f_Ability1Duration < f_Ability1)
            {
                b_Ability1Active = false;
                f_Ability1 = 0f;
            }
        }
        else
        {
            if (f_Ability1 < f_Ability1Recharge)
            {
                f_Ability1 += Time.deltaTime;
            }
        }

        if (b_Ability2Active)
        {
            f_Ability2 += Time.deltaTime;
            if (f_Ability2Duration < f_Ability2)
            {
                b_Ability2Active = false;
                f_Ability2 = 0f;
            }

            if (C_SETTER.r == 0f)
            {
                C_SETTER.r = 1f;
                this.GetComponent<SpriteRenderer>().color = C_SETTER;
            }
        }
        else
        {
            if (f_Ability2 < f_Ability2Recharge)
            {
                f_Ability2 += Time.deltaTime;
            }

            if (C_SETTER.r == 1f)
            {
                C_SETTER.r = 0f;
                this.GetComponent<SpriteRenderer>().color = C_SETTER;
            }
        }
    }

    public float getAbility1()
    {
        return f_Ability1;
    }

    public bool getAbility1IsActive()
    {
        return b_Ability1Active;
    }

    public float getAbility2()
    {
        return f_Ability2;
    }

    public bool getAbility2IsActive()
    {
        return b_Ability2Active;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (b_Ability2Active)
        {
            if (i_Health_Max > i_Health)
            {
                ++i_Health;
            }
        }
        else
        {
            --i_Health;
        }

        if (i_Health <= 0)
        {
            FunctionCall.GetComponent<GameRuntimeHandler>().GAME_STATE = GameRuntimeHandler.GAME_STATES.DEATH;
        }
    }

    public void Ability1()
    {
        if (!b_Ability1Active)
        {
            if (f_Ability1 > f_Ability1Recharge)
            {
                b_Ability1Active = true;
                f_Ability1 = 0f;
            }
        }
    }

    public void Ability2()
    {
        if (!b_Ability2Active)
        {
            if (f_Ability2 > f_Ability2Recharge)
            {
                b_Ability2Active = true;
                f_Ability2 = 0f;
            }
        }
    }

}
