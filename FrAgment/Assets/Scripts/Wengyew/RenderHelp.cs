using UnityEngine;
using System.Collections;

public class RenderHelp : MonoBehaviour {

    private bool renderHelp;
	// Use this for initialization
	void Start () {
        renderHelp = false;
	}
	
	// Update is called once per frame
	void Update () {
        renderHelp = (PlayerPrefs.GetInt("renderHelp?") == 0);
        if (!renderHelp)
        {
            GameObject optTut = GameObject.Find("Options Tutorial");
            optTut.GetComponent<CanvasGroup>().alpha = 0;
        }
	}
}
