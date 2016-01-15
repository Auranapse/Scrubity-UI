using UnityEngine;
using System.Collections;

public class changeControlScheme : MonoBehaviour {

    public int changeTo;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RectTransform cursorPos = GameObject.Find("Spaceship Cursor").GetComponent<RectTransform>();
        Vector3 translate = cursorPos.localPosition;

        if (PlayerPrefs.GetInt("ControlScheme") == 1)
            translate.x = -297;
        else if (PlayerPrefs.GetInt("ControlScheme") == 2)
            translate.x = -185;

        cursorPos.localPosition = translate;
	}

    public void changeScheme()
    {
        PlayerPrefs.SetInt("ControlScheme", changeTo);
    }
}
