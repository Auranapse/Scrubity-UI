using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateVolumeTextScript : MonoBehaviour {

    public string KeyToUse;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.GetComponent<Text>().text = PlayerPrefs.GetInt(KeyToUse) + "%";
	}
}
