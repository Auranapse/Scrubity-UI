using UnityEngine;
using System.Collections;

public class HelpScreenToMainMenu : MonoBehaviour {

    bool StartAnimation;

    private GameObject Entity,FadeOutBox;
    // Use this for initialization
    void Start () {
        StartAnimation = false;
        Entity = GameObject.Find("HelpPageAnimations");
        FadeOutBox = GameObject.Find("FadeOutBox");
    }
	
	// Update is called once per frame
	void Update () {
        if (StartAnimation == true)
        {
            Entity.GetComponent<Translation>().enabled = true;
            

            Debug.Log("h");

        }
	}

    public void RePositionForNextScene(bool Execute)
    {
        GameObject.Find("GlobalFunctions").GetComponent<HelpScreenToMainMenu>().StartAnimation = Execute;
    }
}
