using UnityEngine;
using System.Collections;

public class UISliderScript : MonoBehaviour{

    public string keyToUse;
    public GameObject slider;
    private RectTransform sliderPos;
    public int cursorY;

    bool beingDragged;

	// Use this for initialization
	void Start () {
        sliderPos = slider.GetComponent<RectTransform>();
        beingDragged = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!Input.GetMouseButton(0) && beingDragged)
        {
            beingDragged = false;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Mathf.Abs(Input.mousePosition.y-cursorY)<5 && Input.mousePosition.x < 155)
                beingDragged = true;
        }

        if (beingDragged)
        {
            float tmp = (Input.mousePosition.x - 5) * 1.711409395973154f;
            if (tmp < 0)
                tmp = 0;
            if (tmp > 255)
                tmp = 255;

            PlayerPrefs.SetInt(keyToUse, Mathf.RoundToInt(tmp));
            setColorsUI.UpdateColor = true;
        }

        Vector3 translate = sliderPos.localPosition;
        if (keyToUse == "UI_Rv")
            translate.x = -373 + (PlayerPrefs.GetInt("UI_Rv") * 1.545098f);
        else if (keyToUse == "UI_Gv")
            translate.x = -373 + (PlayerPrefs.GetInt("UI_Gv") * 1.545098f);
        else if (keyToUse == "UI_Bv")
            translate.x = -373 + (PlayerPrefs.GetInt("UI_Bv") * 1.545098f);
        sliderPos.localPosition = translate;
	}
}
