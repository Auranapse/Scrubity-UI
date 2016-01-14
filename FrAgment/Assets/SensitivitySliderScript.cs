using UnityEngine;
using System.Collections;

public class SensitivitySliderScript : MonoBehaviour
{
    public GameObject slider;
    private RectTransform sliderPos;

    bool beingDragged;

    // Use this for initialization
    void Start()
    {
        sliderPos = slider.GetComponent<RectTransform>();
        beingDragged = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0) && beingDragged)
        {
            beingDragged = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Mathf.Abs(Input.mousePosition.y-18) < 5 && Input.mousePosition.x < 154)
                beingDragged = true;
        }

        if (beingDragged)
        {
            float tmp = (Input.mousePosition.x - 5) * 0.68027f;
            if (tmp < 0)
                tmp = 0;
            if (tmp > 100)
                tmp = 100;

            PlayerPrefs.SetInt("Sensitivity", Mathf.RoundToInt(tmp));
        }

        Vector3 translate = sliderPos.localPosition;
        translate.x = -373 + PlayerPrefs.GetInt("Sensitivity")*3.94f;
        sliderPos.localPosition = translate;
    }

    public void increaseS()
    {
        PlayerPrefs.SetInt("Sensitivity", PlayerPrefs.GetInt("Sensitivity") - 1);
    }

    public void decreaseS()
    {
        PlayerPrefs.SetInt("Sensitivity", PlayerPrefs.GetInt("Sensitivity") - 1);
    }
}
