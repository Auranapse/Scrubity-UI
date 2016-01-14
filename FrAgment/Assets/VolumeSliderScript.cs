using UnityEngine;
using System.Collections;

public class VolumeSliderScript : MonoBehaviour {

    public string keyToUse;
    public GameObject slider;
    private RectTransform sliderPos;
    public int cursorY;

    bool beingDragged;

    // Use this for initialization
    void Start()
    {
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
            Debug.Log(Input.mousePosition);
            if (Mathf.Abs(Input.mousePosition.y - cursorY) < 5 && Input.mousePosition.x < 137)
                beingDragged = true;
        }

        if (beingDragged)
        {
            float tmp = (Input.mousePosition.x - 6) * 0.7751937984496124f;
            if (tmp < 0)
                tmp = 0;
            if (tmp > 100)
                tmp = 100;

            Debug.Log(tmp);
            PlayerPrefs.SetInt(keyToUse, Mathf.RoundToInt(tmp));
        }

        Vector3 translate = sliderPos.localPosition;
        translate.x = -372 + (PlayerPrefs.GetInt(keyToUse) * 3.44f);
        sliderPos.localPosition = translate;
	}
}
