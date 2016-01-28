using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateUITextScript : MonoBehaviour {

    public string KeyToUse;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Text>().text = ""+PlayerPrefs.GetInt(KeyToUse);
	}
}
