using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour
{
    Vector2 v2_Destination;
    bool arriveatDestination;

    public Vector2 v2_MaxPos;
    public Vector2 v2_MinPos;

    public int i_Health;
    public float f_movementSpeed;
    public float f_firerate;
    public Vector2 v2_fireVelocity;

    public GameObject CrackedEnemy;
    public GameObject Bullet;
    public GameObject ScoreHandle;
    public GameObject FunctionCall;


    float f_firebullet;

    // Use this for initialization
    void Start()
    {
        arriveatDestination = true;
        f_firebullet = Random.Range(-f_firerate, f_firerate);
    }

    // Update is called once per frame
    void Update()
    {
        switch (FunctionCall.GetComponent<GameRuntimeHandler>().GAME_STATE)
        {
            case GameRuntimeHandler.GAME_STATES.PLAYING:
                {
                    //Shooting
                    f_firebullet += Time.deltaTime;
                    if (f_firebullet > f_firerate)
                    {
                        f_firebullet = 0f;

                        GameObject temp = (GameObject)Instantiate(Bullet, this.transform.position + new Vector3(0, -100, 0), Quaternion.Euler(0, 0, Random.Range(-360, 360)));
                        temp.GetComponent<Rigidbody2D>().velocity = v2_fireVelocity;// + this.GetComponent<Rigidbody2D>().velocity;
                        temp.GetComponent<Rigidbody2D>().angularVelocity = Random.Range(-360, 360);
                    }

                    if (!arriveatDestination)
                    {
                        Vector2 v2_direction = v2_Destination - new Vector2(this.transform.position.x, this.transform.position.y);

                        this.GetComponent<Rigidbody2D>().velocity = f_movementSpeed * v2_direction.normalized * Time.deltaTime;

                        if (v2_direction.magnitude < 10)
                        {
                            arriveatDestination = true;
                        }

                    }
                    else
                    {
                        v2_Destination.Set(Random.Range(v2_MinPos.x, v2_MaxPos.x), Random.Range(v2_MinPos.y, v2_MaxPos.y));
                        arriveatDestination = false;
                    }

                    this.GetComponent<Rigidbody2D>().MoveRotation(0);
                }
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        i_Health -= 1;

        if (i_Health <= 0)
        {
            GameObject temp = (GameObject)Instantiate(CrackedEnemy, this.transform.position, this.transform.rotation);

            ScoreHandle.GetComponent<ScoreHandler>().AddScore(50);

            for (int i = 0; i < temp.transform.childCount; ++i)
            {
                temp.transform.GetChild(i).GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity;
                temp.transform.GetChild(i).GetComponent<Rigidbody2D>().angularVelocity = this.GetComponent<Rigidbody2D>().angularVelocity;
            }

            Destroy(this.gameObject);
        }
        else
        {
            ScoreHandle.GetComponent<ScoreHandler>().AddScore(5);
        }
    }
}
