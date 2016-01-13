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
            ChangeSceneTo(1);
        }
	}

    void ChangeSceneTo(int SceneToChange)
    {
        Application.LoadLevel(SceneToChange);
    }
}
