using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class affectedByColor : MonoBehaviour {

    private Image mat;
    private Text text;

    public bool isText;
	// Use this for initialization
	void Start () {
        if (!isText)
            mat = this.gameObject.GetComponent<Image>();
        else
            text = this.gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!isText)
            mat.color = setColorsUI.UIColor;
        else
            text.color = setColorsUI.UIColor;
	}
}
