using UnityEngine;
using System.Collections;

public class SceneLoader : MonoBehaviour {

    public bool doLoad;

    float Timer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (doLoad == true)
        {
            ChangeSceneTo("MenuScreen");
        }
	}

    public void ChangeSceneTo(string SceneToChange)
    {
        Application.LoadLevel(SceneToChange);
    }
}
