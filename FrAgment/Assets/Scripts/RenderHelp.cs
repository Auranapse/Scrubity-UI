using UnityEngine;
using System.Collections;

public class RenderHelp : MonoBehaviour {

    private bool renderHelp = true;
	// Use this for initialization
	void Start () {
        PlayerPrefs.DeleteAll();
        renderHelp = (PlayerPrefs.GetInt("renderHelp?") == 0);
	}
	
	// Update is called once per frame
	void Update () {
        
        if (renderHelp != (PlayerPrefs.GetInt("renderHelp?") == 0))
        {
            renderHelp = (PlayerPrefs.GetInt("renderHelp?") == 0);
            GameObject optTut = GameObject.Find("Options Tutorial");
            optTut.SetActive(false);
        }
	}
}
