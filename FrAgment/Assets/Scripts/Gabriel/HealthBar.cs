using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    public GameObject Ship;

    int i_Health_Max;

    float f_MaxBarScale;
    float f_MinBarScale;

    // Use this for initialization
    void Start()
    {
        i_Health_Max = Ship.GetComponent<Ship>().i_Health;
        f_MaxBarScale = 360;
        f_MinBarScale = 80;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Ship") != null)
        {
            float percentage = ((float)GameObject.Find("Ship").GetComponent<Ship>().i_Health / (float)i_Health_Max);
            float temp = ((percentage) * (f_MaxBarScale - f_MinBarScale)) + f_MinBarScale;
            this.transform.localScale = new Vector3(temp, this.transform.localScale.y, 1);
        }
        else
        {
            this.transform.localScale = new Vector3(f_MinBarScale, this.transform.localScale.y, 1);
        }

    }
}