using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class aofoaifj : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
            GameObject.Find("debugTxt").GetComponent<Text>().text = "" + Input.touches[0].position + "\n" + Input.mousePosition + "\n" + PlayerPrefs.GetInt("Sensitivity");
	}
}
