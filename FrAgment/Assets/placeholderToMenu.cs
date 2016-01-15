using UnityEngine;
using System.Collections;

public class placeholderToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadMenu()
    {
        Application.LoadLevel("OptionScreen_Control");
    }

    public void loadChlg()
    {
        Application.LoadLevel("ChallengeScreen");
    }
}
