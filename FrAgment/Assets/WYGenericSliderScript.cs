using UnityEngine;
using System.Collections;

public class WYGenericSliderScript : MonoBehaviour {

    public GameObject slider;
    private RectTransform sliderPos;

    public float Screen_SliderMouseYPos;
    public float Screen_SliderOffsetY;

    public float Screen_SliderStartX;
    public float Screen_SliderEndX;

    public string KeyAffected;
    public int keyLowerLimit;
    public int keyUpperLimit;

    public float SliderStartXPos;
    public float SliderEndXPos;

    bool beingDragged;
	// Use this for initialization
	void Start () {
        sliderPos = slider.GetComponent<RectTransform>();
        beingDragged = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!Input.GetMouseButton(0) && beingDragged) {
            beingDragged = false;
        }

        if (Input.GetMouseButtonDown(0)) {
            if (Mathf.Abs(Input.mousePosition.y - Screen_SliderMouseYPos) < Screen_SliderOffsetY && Input.mousePosition.x < Screen_SliderEndX+1)
                beingDragged = true;
        }

        if (beingDragged) {
            float tmp = (Input.mousePosition.x - Screen_SliderStartX) * (keyUpperLimit - keyLowerLimit) / (Screen_SliderEndX - Screen_SliderStartX);
            if (tmp < keyLowerLimit)
                tmp = keyLowerLimit;
            if (tmp > keyUpperLimit)
                tmp = keyUpperLimit;

            PlayerPrefs.SetInt(KeyAffected, Mathf.RoundToInt(tmp));
        }

        /* Special cases */
        if (KeyAffected == "UI_Rv" || KeyAffected == "UI_Gv" || KeyAffected == "UI_Bv")
        {
            setColorsUI.UpdateColor = true;
        }

        Vector3 translate = sliderPos.localPosition;
        translate.x = SliderStartXPos + PlayerPrefs.GetInt(KeyAffected) * (SliderEndXPos-SliderStartXPos)/(keyUpperLimit-keyLowerLimit);
        sliderPos.localPosition = translate;
	}
}
