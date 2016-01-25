using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{
    public GameObject particle;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isOutofworld())
        {
            Destroy(this.gameObject);
        }
    }

    bool isOutofworld()
    {
        if (this.transform.position.y > Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y)
        {
            return true;
        }
        else if (this.transform.position.y < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y)
        {
            return true;
        }

        if (this.transform.position.x > Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x)
        {
            return true;
        }
        else if (this.transform.position.x < Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x)
        {
            return true;
        }

        return false;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        for (int i = 0; i < 5; ++i)
        {
            GameObject temp = (GameObject)Instantiate(particle, this.transform.position, Random.rotation);
            Vector2 v2_temp = new Vector2(Random.Range(-70, 70), Random.Range(-100, -10));
            temp.GetComponent<Rigidbody2D>().AddForce(v2_temp);
            temp.GetComponent<Rigidbody2D>().AddTorque(Random.Range(-100, 100));
        }

        Destroy(this.gameObject);
    }
}
