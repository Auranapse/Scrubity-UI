using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour
{
    public int Health;
    public GameObject CrackedEnemy;
    public GameObject ScoreHandle;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Health -= 1;

        if(Health <= 0)
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
