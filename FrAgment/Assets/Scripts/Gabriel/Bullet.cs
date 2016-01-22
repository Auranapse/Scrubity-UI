using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isOutofworld())
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
}
