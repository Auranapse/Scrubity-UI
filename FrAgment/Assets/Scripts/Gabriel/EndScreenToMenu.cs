using UnityEngine;
using System.Collections;

public class EndScreenToMenu : MonoBehaviour
{
    float f_timer;
    bool b_execute;
    // Use this for initialization
    void Start()
    {
        b_execute = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(b_execute)
        {
            GameObject.Find("User Interface").GetComponent<Translation>().enabled = true;

            if (f_timer > 0.8)
            {
                Application.LoadLevel("MenuScreen");
            }
            else
            {
                f_timer += Time.deltaTime;
            }
        }
    }

    public void ChangeclickedState()
    {
        b_execute = true;
    }
}
